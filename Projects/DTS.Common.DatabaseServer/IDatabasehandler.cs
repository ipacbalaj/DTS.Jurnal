using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.Common.Infrastructure.Login;
using DTS.Common.DatabaseServer.EntitiesModel;
using DTS.Common.DatabaseServer.EntitiesModel.Local;

namespace DTS.Common.DatabaseServer
{
    public interface IDatabasehandler
    {

        List<LocalPatient> GetPatients(int userId);

        List<InterventionModel> GetInterventions(int userId, DateTime dateToReturnFrom, InterventionsLoadType interventionsLoadType);

        Task<int> SaveIntervention(InterventionModel localIntervention, int userId);

        Task EditIntervention(InterventionModel localIntervention);

        void DeleteInterventions();

        Task SetInterventionSelectionStatus(int interventionId, bool selectionStatus);

        Task SetInterventionsSelectionStatus(List<int> interventionsIds, bool status);

        Task SetInterventionsPaymentStatus(List<int> interventionIds, bool wasPayed);

        Task SetInterventionPayed(int interventionId, bool wasPayed);

        Task DeleteIntervention(int interventionId);

        List<InterventionModel> GetPatientInterventions(int patientId);


        #region LoginUser


        LoginResponse Login(string username, string password);
        
        string EncryptString(string ClearText);

        void EditUser(LocalUser localUser);

        List<LocalUser> GetUsers();

        #endregion LoginUser

        #region settings

        List<SettingItem> GetWorks();
        List<SettingItem> GetLocations();

        List<SettingItem> GetAreas();
        Task<List<SettingItem>> AddEditAreas(List<SettingItem> areas);
        Task<List<SettingItem>> AddEditWorks(List<SettingItem> works);
        Task<List<SettingItem>> AddEditLocationss(List<SettingItem> locations);


        Task DeleteAreas(List<int> areaIds);

        Task DeleteLocations(List<int> locationsIds);

        Task DeleteWorks(List<int> worksIds);
        #endregion settings

        #region Patients

        Task<int> SavePatient(LocalPatient localPatient, int userId);
        Task EditPatient(LocalPatient localPatient);

        Task SetAsExported();

        Task MergePatients(List<int> patientsIds);

        Task DeletePatient(int patientId);

        #endregion Patients

        #region SystemSettings



        #endregion SystemSettings
    }

    public enum InterventionsLoadType
    {
        All, ByDate
    }
}
