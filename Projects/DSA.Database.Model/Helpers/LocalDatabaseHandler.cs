using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DSA.Common.Infrastructure.Helpers;
using DSA.Common.Infrastructure.Login;
using DSA.Common.Infrastructure.Styles;
using DSA.Database.Model.EfSQlLite;
using DTS.Common.DatabaseServer;
using DTS.Common.DatabaseServer.EntitiesModel;
using DTS.Common.DatabaseServer.EntitiesModel.Local;

namespace DSA.Database.Model.Helpers
{
    public class LocalDatabaseHandler : IDatabasehandler
    {
        
        public List<LocalPatient> GetPatients(int userId)
        {
            using (dsaEntities coreModel = new dsaEntities())
            {
                return coreModel.Patients.Where(item => item.UserId == userId).OrderBy(p => p.surname).ToLocalPatients();
            }
        }

        public List<InterventionModel> GetInterventions(int userId, DateTime dateToReturnFrom, InterventionsLoadType interventionsLoadType)
        {
            using (dsaEntities dsaEntities = new dsaEntities())
            {
                var interventions = dsaEntities.Interventions.Where(item => item.UserId == userId);

                switch (interventionsLoadType)
                {
                    case InterventionsLoadType.All:
                        return interventions.ToInterventionModels();
                    case InterventionsLoadType.ByDate:
                        var interventionToReturn = new List<InterventionModel>();
                        foreach (var intervention in interventions)
                        {
                            if (intervention.DateHourDetail.Date >= dateToReturnFrom)
                            {
                                interventionToReturn.Add(intervention.ToInterventionModel());
                            }
                        }
                        return interventionToReturn;
                    default:
                        return interventions.ToInterventionModels();

                }
            }
        }

        public async Task<int> SaveIntervention(InterventionModel localIntervention, int userId)
        {
            return await Task.Run(() =>
            {
                using (dsaEntities model = new dsaEntities())
                {
                    var year =
                             model.Years.FirstOrDefault(
                                 item => item.YearNb == localIntervention.Date.Year);
                    if (year == null)
                    {
                        year = new Year()
                        {
                            YearNb = localIntervention.Date.Year
                        };
                        model.Years.AddObject(year);
                        model.SaveChanges();
                    }

                    var intervention = new Intervention();
                    intervention.Year = year;
                    intervention.Month =
                        model.Months.FirstOrDefault(
                            item => item.MOnthNumber == localIntervention.Date.Month);
                    intervention.DateHourDetail = new DateHourDetail();
                    intervention.Revenue = localIntervention.Revenue;
                    intervention.Percent = localIntervention.Percent;
                    intervention.DateHourDetail.StartHour = localIntervention.Start;
                    intervention.DateHourDetail.EndingHour = localIntervention.End;
                    intervention.Work = model.Works.FirstOrDefault(item => item.Id == localIntervention.WorkId);
                    intervention.Location = model.Locations.FirstOrDefault(item => item.Id == localIntervention.LocationId);
                    intervention.DateHourDetail.Date = localIntervention.Date;
                    intervention.IsSelected = localIntervention.IsSelected;
                    intervention.Patient = model.Patients.FirstOrDefault(item => item.id == localIntervention.PatientId);
                    intervention.DateHourDetail.Duration = (localIntervention.End - localIntervention.Start).Ticks;
                    intervention.Area = model.Areas.FirstOrDefault(item => item.Id == localIntervention.AreaId);
                    intervention.Remainder = localIntervention.Remainder;
                    intervention.IsSelected = localIntervention.IsSelected;
                    intervention.MaterialCost = localIntervention.MaterialCost;
                    model.Interventions.AddObject(intervention);
                    intervention.UserId = userId;

                    model.SaveChanges();
                    return intervention.Id;
                }
            });
        }

        public async Task EditIntervention(InterventionModel localIntervention)
        {
            using (dsaEntities model = new dsaEntities())
            {
                var intervention = model.Interventions.FirstOrDefault(item => item.Id == localIntervention.Id);
                if (intervention != null)
                {
                    intervention.Revenue = localIntervention.Revenue;
                    intervention.Percent = localIntervention.Percent;
                    intervention.DateHourDetail.StartHour = localIntervention.Start;
                    intervention.DateHourDetail.EndingHour = localIntervention.End;
                    intervention.Work = model.Works.FirstOrDefault(item => item.Id == localIntervention.WorkId);
                    intervention.Location =
                        model.Locations.FirstOrDefault(item => item.Id == localIntervention.LocationId);
                    intervention.DateHourDetail.Date = localIntervention.Date;
                    intervention.Patient = model.Patients.FirstOrDefault(item => item.id == localIntervention.PatientId);
                    intervention.DateHourDetail.Duration = (localIntervention.End - localIntervention.Start).Ticks;
                    intervention.Area = model.Areas.FirstOrDefault(item => item.Id == localIntervention.AreaId);
                    intervention.Remainder = localIntervention.Remainder;
                    intervention.WasPayedByDental = localIntervention.WasPayed;
                    intervention.MaterialCost = localIntervention.MaterialCost;
                    model.SaveChanges();
                }
            }
        }

        public async void DeleteInterventions()
        {
            using (dsaEntities jurnalModel = new dsaEntities())
            {
                var ids = jurnalModel.Interventions.Select(item => item.Id);
                foreach (var id in ids)
                {
                    jurnalModel.Interventions.DeleteObject(jurnalModel.Interventions.FirstOrDefault(item => item.Id == id));

                }
                jurnalModel.SaveChanges();
            }
        }

        public async Task SetInterventionSelectionStatus(int interventionId, bool selectionStatus)
        {
            using (dsaEntities model = new dsaEntities())
            {
                var interventionToEditStatus = model.Interventions.FirstOrDefault(item => item.Id == interventionId);
                interventionToEditStatus.IsSelected = selectionStatus;
                model.SaveChanges();
            }
        }

        public Task SetInterventionsSelectionStatus(List<int> interventionsIds, bool status)
        {
            return Task.Run(() =>
             {
                 using (dsaEntities model = new dsaEntities())
                 {
                     foreach (var interventionsId in interventionsIds)
                     {
                         var intervention = model.Interventions.FirstOrDefault(item => item.Id == interventionsId);
                         intervention.IsSelected = status;
                     }
                     model.SaveChanges();
                 }
             });
        }

        public Task SetInterventionsPaymentStatus(List<int> interventionIds, bool wasPayed)
        {
            return Task.Run(() =>
            {
                using (dsaEntities model = new dsaEntities())
                {
                    foreach (var interventionsId in interventionIds)
                    {
                        var intervention = model.Interventions.FirstOrDefault(item => item.Id == interventionsId);
                        intervention.WasPayedByDental = wasPayed;
                        if (wasPayed)
                        {
                            intervention.Remainder = 0;
                        }
                    }
                    model.SaveChanges();
                }
            });
        }

        public async Task SetInterventionPayed(int interventionId, bool wasPayed)
        {
            using (dsaEntities dsaEntities = new dsaEntities())
            {
                var interventionToEdit = dsaEntities.Interventions.FirstOrDefault(item => item.Id == interventionId);

                interventionToEdit.WasPayedByDental = wasPayed;
                if (wasPayed) interventionToEdit.Remainder = 0;
                dsaEntities.SaveChanges();
            }
        }

        public async Task DeleteIntervention(int interventionId)
        {
            using (dsaEntities dsaEntities = new dsaEntities())
            {
                var interventionToDelete = dsaEntities.Interventions.FirstOrDefault(item => item.Id == interventionId);
                dsaEntities.Interventions.DeleteObject(interventionToDelete);
                dsaEntities.SaveChanges();
            }
        }

        public List<InterventionModel> GetPatientInterventions(int patientId)
        {
            using (dsaEntities dsaEntities = new dsaEntities())
            {
                return dsaEntities.Interventions.Where(item => item.Patient.id == patientId).ToInterventionModels();
            }
        }


        #region Login


        public LoginResponse Login(string username, string password)
        {
            LoginResponse loginResponse = new LoginResponse();
            using (dsaEntities dsaModel = new dsaEntities())
            {
                var currentUser = dsaModel.Users.FirstOrDefault(item => item.username == username);
                if (currentUser != null)
                {
                    bool shouldContinue = false;
                    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                    {
                        if (nic.NetworkInterfaceType.ToString() == "Ethernet" ||
                            nic.NetworkInterfaceType.ToString().ToLower().Contains("wireless"))
                        {
                            string ecryptedMac = EncryptString(nic.GetPhysicalAddress().ToString());
                            if (currentUser.MACs.Any(item => item.macId == ecryptedMac))
                            {
                                shouldContinue = true;
                                break;
                            }
                        }
                    }
                    if (shouldContinue)
                    {
                        if (currentUser.password == EncryptString(password))
                        {
                            loginResponse.Description = "";
                            loginResponse.Status = LoginStatus.Successful;
                            loginResponse.UserId = currentUser.Id;
                            loginResponse.Username = currentUser.username;
                            XmlSerializerHelper.SaveToXml(ViewConstants.appDataPath, new LocalUser()
                            {
                                Username = username
                            });
                        }
                        else
                        {
                            loginResponse.Description = "Parola Gresita!";
                            loginResponse.Status = LoginStatus.Unsuccessful;
                        }
                    }
                    else
                    {
                        loginResponse.Description = "Pentru a folosi aplicatia aveti nevoie de licenta!";
                        loginResponse.Status = LoginStatus.Unsuccessful;
                        return loginResponse;
                    }
                }
                else
                {
                    loginResponse.Description = "Nume Utilizator gresit!";
                    loginResponse.Status = LoginStatus.Unsuccessful;
                }
            }
            return loginResponse;
        }

        public string EncryptString(string ClearText)
        {
            byte[] clearTextBytes = Encoding.UTF8.GetBytes(ClearText);

            System.Security.Cryptography.SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
            MemoryStream ms = new MemoryStream();
            byte[] rgbIV = Encoding.ASCII.GetBytes("ryojvlzffalyglrj");
            byte[] key = Encoding.ASCII.GetBytes("hcxilkqbbffffeultgbskdmaunivmfuo");
            CryptoStream cs = new CryptoStream(ms, rijn.CreateEncryptor(key, rgbIV),
                CryptoStreamMode.Write);

            cs.Write(clearTextBytes, 0, clearTextBytes.Length);
            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        public void EditUser(LocalUser localUser)
        {
            using (dsaEntities dsaModel = new dsaEntities())
            {
                try
                {
                    var user = dsaModel.Users.FirstOrDefault(item => item.Id == localUser.Id);
                    if (user != null)
                    {
                        user.username = localUser.Username;
                        user.password = EncryptString(localUser.Password);
                    }
                    dsaModel.SaveChanges();
                    //    MessageBox.Show("Numele Utilizator si parola au fost moficate");
                }
                catch (Exception)
                {
                    MessageBox.Show("Eroare la salvare");
                }
            }
        }

        public List<LocalUser> GetUsers()
        {
            using (dsaEntities dsaModel = new dsaEntities())
            {
                var users = new List<LocalUser>();
                foreach (var user in dsaModel.Users)
                {
                    users.Add(new LocalUser()
                    {
                        Id = user.Id,
                        Username = user.username
                    });
                }
                return users;
            }
        }

        #endregion Login

        #region settings

        public List<SettingItem> GetWorks()
        {
            using (dsaEntities coreModel = new dsaEntities())
            {
                return coreModel.Works.OrderBy(item => item.Name).ToLocalWorks();
            }
        }

        public List<SettingItem> GetLocations()
        {
            using (dsaEntities coreModEntities = new dsaEntities())
            {
                return coreModEntities.Locations.OrderBy(item => item.Name).ToLocalLocations();
            }
        }

        public List<SettingItem> GetAreas()
        {
            using (dsaEntities coreModEntities = new dsaEntities())
            {
                return coreModEntities.Areas.OrderBy(item => item.Name).ToLocalAreass();
            }
        }

        public async Task<List<SettingItem>> AddEditAreas(List<SettingItem> areas)
        {
            try
            {
                using (dsaEntities je = new dsaEntities())
                {
                    foreach (var area in areas)
                    {
                        var areaEntity = je.Areas.FirstOrDefault(item => item.Id == area.Id);
                        if (areaEntity != null)
                        {
                            areaEntity.Name = area.Name;

                        }
                        else
                        {
                            je.Areas.AddObject(new Area()
                            {
                                Name = area.Name,
                                WasDeleted = false
                            });
                        }
                    }
                    je.SaveChanges();
                    return je.Areas.OrderBy(item => item.Name).ToLocalAreass();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("A intervenit O eroare!");
                return null;
            }

        }

        public async Task<List<SettingItem>> AddEditWorks(List<SettingItem> works)
        {
            try
            {
                using (dsaEntities je = new dsaEntities())
                {
                    foreach (var work in works)
                    {
                        var workEntity = je.Works.FirstOrDefault(item => item.Id == work.Id);
                        if (workEntity != null)
                        {
                            workEntity.Name = work.Name;
                            workEntity.Cost = work.Cost;

                        }
                        else
                        {
                            je.Works.AddObject(new Work()
                            {
                                Name = work.Name,
                                Cost = work.Cost,
                                WasDeleted = false
                            });
                        }
                    }
                    je.SaveChanges();
                    return je.Works.OrderBy(item => item.Name).ToLocalWorks();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("A intervenit O eroare!");
                return null;
            }

        }

        public async Task<List<SettingItem>> AddEditLocationss(List<SettingItem> locations)
        {
            try
            {
                using (dsaEntities je = new dsaEntities())
                {
                    foreach (var loc in locations)
                    {
                        var workEntity = je.Locations.FirstOrDefault(item => item.Id == loc.Id);
                        if (workEntity != null)
                        {
                            workEntity.Name = loc.Name;

                        }
                        else
                        {
                            je.Locations.AddObject(new Location()
                            {
                                Name = loc.Name,
                                WasDeleted = false
                            });
                        }
                    }
                    je.SaveChanges();
                    return je.Locations.OrderBy(item => item.Name).ToLocalLocations();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("A intervenit o eroare!");
                return null;
            }
        }


        public async Task DeleteAreas(List<int> areaIds)
        {
            using (dsaEntities junradsaEntities = new dsaEntities())
            {
                foreach (var areaId in areaIds)
                {
                    var areaToDelete = junradsaEntities.Areas.FirstOrDefault(item => item.Id == areaId);
                    if (areaToDelete != null) areaToDelete.WasDeleted = true;
                }
                junradsaEntities.SaveChanges();
            }
        }

        public async Task DeleteLocations(List<int> locationsIds)
        {
            using (dsaEntities junradsaEntities = new dsaEntities())
            {
                foreach (var locationsId in locationsIds)
                {
                    var locToDelete = junradsaEntities.Locations.FirstOrDefault(item => item.Id == locationsId);
                    if (locToDelete != null) locToDelete.WasDeleted = true;
                }
                junradsaEntities.SaveChanges();
            }
        }

        public async Task DeleteWorks(List<int> worksIds)
        {
            using (dsaEntities junradsaEntities = new dsaEntities())
            {
                foreach (var wId in worksIds)
                {
                    var wtd = junradsaEntities.Works.FirstOrDefault(item => item.Id == wId);
                    if (wtd != null) wtd.WasDeleted = true;
                }
                junradsaEntities.SaveChanges();
            }
        }

        #endregion settings

        #region Patients

        public async Task<int> SavePatient(LocalPatient localPatient, int userId)
        {
            using (dsaEntities model = new dsaEntities())
            {
                var patient = new Patient()
                {
                    name = localPatient.LastName,
                    surname = localPatient.FirstName,
                    BirthDate = localPatient.BirthDate,
                    UserId = userId
                };
                model.Patients.AddObject(patient);
                model.SaveChanges();
                return patient.id;
            }
        }

        public async Task EditPatient(LocalPatient localPatient)
        {
            using (dsaEntities dsaEntities = new dsaEntities())
            {
                var patientToEdit = dsaEntities.Patients.FirstOrDefault(item => item.id == localPatient.Id);
                patientToEdit.name = localPatient.FirstName;
                patientToEdit.surname = localPatient.LastName;
                patientToEdit.Address = localPatient.Address;
                patientToEdit.BirthDate = localPatient.BirthDate;
                patientToEdit.City = localPatient.City;
                patientToEdit.Country = localPatient.Country;
                patientToEdit.Street = localPatient.Street;
                patientToEdit.Block = localPatient.Block;
                patientToEdit.StreetNumber = localPatient.StreetNumber;
                patientToEdit.Job = localPatient.Job;
                patientToEdit.Ocupation = localPatient.Ocupation;
                patientToEdit.Phone = localPatient.Phone;
                patientToEdit.Email = localPatient.Email;
                dsaEntities.SaveChanges();
            }
        }

        public async Task SetAsExported()
        {
            using (dsaEntities je = new dsaEntities())
            {
                var pats = je.Patients;
                foreach (var p in pats)
                {
                    //                    p.WasExported = true;
                }
                je.SaveChanges();
            }
        }

        public async Task MergePatients(List<int> patientsIds)
        {
            using (dsaEntities dsaEntities = new dsaEntities())
            {
                var patientsToMerge = new List<Patient>();
                foreach (var patient in dsaEntities.Patients)
                {
                    if (patientsIds.Contains(patient.id))
                    {
                        patientsToMerge.Add(patient);
                    }
                }

                var patientThatRemains = patientsToMerge.FirstOrDefault(item => item.id == patientsIds.First());
                patientsToMerge.Remove(patientThatRemains);
                var inderventionsIds = new List<int>();
                foreach (var patient in patientsToMerge)
                {
                    inderventionsIds.AddRange(patient.Interventions.Select(item => item.Id).ToList());
                }

                foreach (var inderventionId in inderventionsIds)
                {
                    var interventionToMove = dsaEntities.Interventions.FirstOrDefault(item => item.Id == inderventionId);
                    interventionToMove.Patient = patientThatRemains;
                }

                foreach (var patient in patientsToMerge)
                {
                    dsaEntities.Patients.DeleteObject(patient);
                }

                dsaEntities.SaveChanges();
            }
        }

        public async Task DeletePatient(int patientId)
        {
            using (dsaEntities dsaEntities = new dsaEntities())
            {
                var patientToDelete = dsaEntities.Patients.FirstOrDefault(item => item.id == patientId);
                var ids = patientToDelete.Interventions.Select(item => item.Id).ToList();
                foreach (var id in ids)
                {
                    var interventionToDelete = dsaEntities.Interventions.FirstOrDefault(item => item.Id == id);
                    dsaEntities.Interventions.DeleteObject(interventionToDelete);
                }

                patientToDelete.Interventions = null;
                dsaEntities.Patients.DeleteObject(patientToDelete);
                dsaEntities.SaveChanges();
            }
        }

        #endregion Patients
    }


}
