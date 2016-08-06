using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DTS.Common.BusinessLogic;
using DTS.Common.DatabaseServer;
using DTS.Common.DatabaseServer.EntitiesModel;
using DTS.Common.DatabaseServer.EntitiesModel.Local;
using DTS.Jurnal.Database.SQLServer.Module.Helpers;

namespace DTS.Jurnal.Database.SQLServer.Module
{
    public class LocalCache
    {
        private static readonly LocalCache instance = new LocalCache();

        public static LocalCache Instance
        {
            get
            {
                return instance;
            }
        }

        public List<SettingItem> Works { get; set; }
        public List<SettingItem> Locations { get; set; }
        public List<SettingItem> Areas { get; set; }
        public List<LocalPatient> Patients { get; set; }
        public List<InterventionModel> Interventions { get; set; }
        public LocalUser LocalUser { get; set; }
        public bool InterventionLoaded { get; set; }
        public string NetworkPath { get; set; }

        #region Tasks


        private Task InitInterventionsTask;
        private Task InitSettingsTask;
        private Task InitPatientsTask;

        public void Initialize()
        {
            var defaultStartingDate = DateTime.Now.AddMonths(-3);
            InitInterventionsTask = InitInterventionsTasks(defaultStartingDate, InterventionsLoadType.ByDate);
            InitSettingsTask = new Task(() =>
            {
                Thread.CurrentThread.Name = "InitSettings";
                InitSettings();
            });
            InitPatientsTask = new Task(() =>
            {
                Thread.CurrentThread.Name = "InitPatients";
                InitPatients();
            });
            InitStartTAsks();
        }

        private Task InitInterventionsTasks(DateTime defaultStartingDate, InterventionsLoadType interventionsLoadType)
        {
            return new Task(() =>
            {
                Thread.CurrentThread.Name = "InitInterventions";
                InitInterventions(defaultStartingDate, interventionsLoadType);
            });
        }

        public Task InitInterventionsStartTask(DateTime defaultStartingDate, InterventionsLoadType interventionsLoadType)
        {
            return Task.Run(() => InitInterventions(defaultStartingDate, interventionsLoadType));
        }

        public readonly Object lockObj = new object();

        private void InitInterventions(DateTime defaultStartingDate, InterventionsLoadType interventionsLoadType)
        {
            {
                Interventions = BusinessLogic.Instance.Databasehandler.GetInterventions(LocalUser.Id, defaultStartingDate, interventionsLoadType);
            }
        }

        private void InitSettings()
        {
            Works = BusinessLogic.Instance.Databasehandler.GetWorks();
            Locations = BusinessLogic.Instance.Databasehandler.GetLocations();
            Instance.Areas = BusinessLogic.Instance.Databasehandler.GetAreas();
        }

        private void InitPatients()
        {
            Patients = BusinessLogic.Instance.Databasehandler.GetPatients(LocalUser.Id);
        }

        public List<Task> StartDTSTasks;

        public void InitStartTAsks()
        {
            StartDTSTasks = new List<Task>();
            StartDTSTasks.Add(InitSettingsTask);
            StartDTSTasks.Add(InitPatientsTask);
            StartDTSTasks.Add(InitInterventionsTask);
            foreach (var startDtsTask in StartDTSTasks)
            {
                startDtsTask.Start();
            }

            Task.WaitAll(StartDTSTasks.ToArray());

        }

        #endregion Tasks

        public void SaveDatabase()
        {
            string fileName = "dsa.sdf";
            string sourcePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DTS\";
            string targetPath = NetworkPath;

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, "dsa.sdf");
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);
        }

        public void DeletePatient(int id)
        {
            var patientToDelete = Patients.FirstOrDefault(item => item.Id == id);
            Patients.Remove(patientToDelete);
        }
    }
}
