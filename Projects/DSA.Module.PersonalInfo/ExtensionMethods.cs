using System;
using DSA.Module.PersonalInfo.PatientInformation;
using DSA.Module.PersonalInfo.PersonalInfoScreen;
using DTS.Common.DatabaseServer.EntitiesModel.Local;

namespace DSA.Module.PersonalInfo
{
    public static class ExtensionMethods
    {
        public static PatientInformationViewModel ToPatientInformationViewModel(this LocalPatient localPatient, PersonalInfoScreenViewModel parent)
        {
            return new PatientInformationViewModel(parent)
            {
                Name = localPatient.LastName,
                Surname = localPatient.FirstName,
                BirthDate = localPatient.BirthDate.HasValue?localPatient.BirthDate.Value:DateTime.Now,
                Email = localPatient.Email,
                Phone = localPatient.Phone,
                Street = localPatient.Street,
                Number = localPatient.StreetNumber,
                Bloc = localPatient.Block,
                Country = localPatient.Country,
                Job = localPatient.Job,
                Ocupation = localPatient.Ocupation,
                City = localPatient.City,
            };
        }
        //
        public static bool CopyToLocalPatient(this LocalPatient localPatient, PatientInformationViewModel patientInformationViewModel)
        {
            bool toreturn = false;
            localPatient.FirstName = patientInformationViewModel.Name;
            localPatient.LastName = patientInformationViewModel.Surname;
            localPatient.BirthDate = patientInformationViewModel.BirthDate;
            localPatient.Block = patientInformationViewModel.Bloc;
            localPatient.Ocupation = patientInformationViewModel.Ocupation;
            localPatient.Phone = patientInformationViewModel.Phone;
            localPatient.Street = patientInformationViewModel.Street;
            localPatient.StreetNumber = patientInformationViewModel.Number;
            localPatient.Email = patientInformationViewModel.Email;
            localPatient.Country = patientInformationViewModel.Country;
            localPatient.City = patientInformationViewModel.City;
            localPatient.Job = patientInformationViewModel.Job;
            localPatient.AllName = patientInformationViewModel.Surname + " " + patientInformationViewModel.Name;
            return true;
        }
    }

}