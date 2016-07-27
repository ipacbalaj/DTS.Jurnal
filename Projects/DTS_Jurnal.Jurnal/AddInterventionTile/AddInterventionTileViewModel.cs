using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using DevExpress.XtraSplashScreen;
using DSA.Common.Controls.Buttons;
using DSA.Common.Infrastructure;
using DSA.Common.Infrastructure.Entities;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;
using DSA.Database.Model;
using DSA.Database.Model.Entities.Local;
using DSA.Database.Model.Helpers;
using DTS.Jurnal.Database.Model.Entities.Local;
using DTS.Jurnal.V3.Database.Module;
using DTS.Jurnal.V3.Database.Module.Entities;
using DTS.Jurnal.V3.Database.Module.Entities.Local;
using DTS.Jurnal.V3.Database.Module.Helpers;
using DTS_Jurnal.Jurnal.Helpers;
using DTS_Jurnal.Jurnal.JurnalScreen;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;

namespace DTS_Jurnal.Jurnal.AddInterventionTile
{
    public class AddInterventionTileViewModel : ViewModelBase
    {
        #region Constructor

        public AddInterventionTileViewModel(JurnalViewModel parent)
        {
            Parent = parent;
            IsPatientComboFocused = true;
            SaveIntevertionButton = new ActionButtonViewModel("Salveaza", new DelegateCommand(OnSave), ImagePath.SaveIconPath);
            CancelIntevertionButton = new ActionButtonViewModel("Anulare", new DelegateCommand(OnCancel), ImagePath.CancelIconPath);
        }

        #endregion Constructor

        #region Properties

        public JurnalViewModel Parent { get; set; }

        private readonly IEventAggregator eventAggregator;

        private ActionButtonViewModel saveIntevertionButton;

        public ActionButtonViewModel SaveIntevertionButton
        {
            get { return saveIntevertionButton; }
            set
            {
                if (value == saveIntevertionButton)
                    return;
                saveIntevertionButton = value;
                OnPropertyChanged();
            }
        }

        private ActionButtonViewModel cancelIntevertionButton;

        public ActionButtonViewModel CancelIntevertionButton
        {
            get { return cancelIntevertionButton; }
            set
            {
                if (value == cancelIntevertionButton)
                    return;
                cancelIntevertionButton = value;
                OnPropertyChanged();
            }
        }

        private Brush contentBackground = BackgroundColors.AddInterventionTileColor;

        public Brush ContentBackground
        {
            get { return contentBackground; }
            set
            {
                if (value == contentBackground)
                    return;
                contentBackground = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LocalPatient> patientsList;
        public ObservableCollection<LocalPatient> PatientList
        {
            get { return patientsList; }
            set
            {
                if (value == patientsList)
                    return;
                patientsList = value;
                OnPropertyChanged();
            }
        }

        private LocalPatient selectedPatient;
        public LocalPatient SelectedPatient
        {
            get { return selectedPatient; }
            set
            {
                if (value == selectedPatient)
                    return;
                selectedPatient = value;
                OnPropertyChanged();
            }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value == id)
                    return;
                id = value;
                OnPropertyChanged();
            }
        }

        private DateTime date = DateTime.Now;
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value == date)
                    return;
                date = value;
                OnPropertyChanged();
            }
        }

        private SettingItem selectedWork;
        public SettingItem SelectedWork
        {
            get { return selectedWork; }
            set
            {
                if (value == selectedWork)
                    return;
                selectedWork = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SettingItem> works;
        public ObservableCollection<SettingItem> Works
        {
            get { return works; }
            set
            {
                if (value == works)
                    return;
                works = value;
                OnPropertyChanged();
            }
        }

        private SettingItem selectedLocation;
        public SettingItem SelectedLocation
        {
            get { return selectedLocation; }
            set
            {
                if (value == selectedLocation)
                    return;
                selectedLocation = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SettingItem> areas;
        public ObservableCollection<SettingItem> Areas
        {
            get { return areas; }
            set
            {
                if (value == areas)
                    return;
                areas = value;
                OnPropertyChanged();
            }
        }

        private SettingItem selectedArea;
        public SettingItem SelectedArea
        {
            get { return selectedArea; }
            set
            {
                if (value == selectedArea)
                    return;
                selectedArea = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SettingItem> locations;
        public ObservableCollection<SettingItem> Locations
        {
            get { return locations; }
            set
            {
                if (value == locations)
                    return;
                locations = value;
                OnPropertyChanged();
            }
        }

        private DateTime startingHour = DateTime.Now;
        public DateTime StartingHour
        {
            get { return startingHour; }
            set
            {
                if (value == startingHour)
                    return;
                startingHour = value;
                OnPropertyChanged();
            }
        }

        private double? durata;
        public double? Durata
        {
            get { return durata; }
            set
            {
                if (value == durata)
                    return;
                durata = value;
                OnPropertyChanged();
            }
        }

        private double? revenue;
        public double? Revenue
        {
            get { return revenue; }
            set
            {
                if (value == revenue)
                    return;
                revenue = value;

                OnPropertyChanged();
            }
        }

        private double remainder;
        public double Remainder
        {
            get { return remainder; }
            set
            {
                if (value == remainder)
                    return;
                remainder = value;
                OnPropertyChanged();
            }
        }

        private double? currentRevenue;
        public double? CurrentRevenue
        {
            get { return currentRevenue; }
            set
            {
                if (value == currentRevenue)
                    return;
                currentRevenue = value;
                OnPropertyChanged();
            }
        }

        private InterventionModel previouslyAddedIntervention;
        public InterventionModel PreviouslyAddedIntervention
        {
            get { return previouslyAddedIntervention; }
            set
            {
                if (value == previouslyAddedIntervention)
                    return;
                previouslyAddedIntervention = value;
                OnPropertyChanged();
            }
        }

        private bool isPatientComboFocused;
        public bool IsPatientComboFocused
        {
            get { return isPatientComboFocused; }
            set
            {
                isPatientComboFocused = value;
                OnPropertyChanged();
            }
        }

        private bool isEditMode;
        public bool IsEditMode
        {
            get { return isEditMode; }
            set
            {
                if (value == isEditMode)
                    return;
                isEditMode = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Percent> percentages;
        public ObservableCollection<Percent> Percentages
        {
            get { return percentages; }
            set
            {
                if (value == percentages)
                    return;
                percentages = value;
                OnPropertyChanged();
            }
        }

        private Percent selectedPercentage;
        public Percent SelectedPercentage
        {
            get { return selectedPercentage; }
            set
            {
                if (value == selectedPercentage)
                    return;
                selectedPercentage = value;
                OnPropertyChanged();
            }
        }

        private double? materialCost;
        public double? MaterialCost
        {
            get { return materialCost; }
            set
            {
                if (value == materialCost)
                    return;
                materialCost = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties

        #region Methods

        public void InitData()
        {
            Works = new ObservableCollection<SettingItem>(LocalCache.Instance.Works);
            Locations = new ObservableCollection<SettingItem>(LocalCache.Instance.Locations);
            Areas = new ObservableCollection<SettingItem>(LocalCache.Instance.Areas);
            PatientList = new ObservableCollection<LocalPatient>(LocalCache.Instance.Patients);
            IsEditMode = false;
            InitPercentage();
        }

        public async void OnSave()
        {
            if (CurrentRevenue > Revenue)
            {
                MessageBox.Show("Incasarea curenta nu poate fi mai mica decat cea totala");
                return;
            }
            try
            {
                double percentage = SelectedPercentage != null ? SelectedPercentage.Percentage / 100 : 1;

                if (PreviouslyAddedIntervention != null)
                {

                    PreviouslyAddedIntervention.RowColorBrush = PreviouslyAddedIntervention.WasPayed ? null : BackgroundColors.GridNotPayedColor;
                }
                var materialCost = MaterialCost.HasValue ? MaterialCost.Value : 0;
                if (IsEditMode)
                {
                    if (SelectedLocation != null)
                    {
                        Parent.SelectedInterventionModel.Location = SelectedLocation.Name;
                        Parent.SelectedInterventionModel.LocationId = SelectedLocation.Id;
                    }
                    var revenue = Revenue.HasValue ? Revenue.Value : 0;
                    Parent.SelectedInterventionModel.Revenue = revenue;
                    Parent.SelectedInterventionModel.Percent = Convert.ToDouble((revenue - materialCost) * percentage);
                    Parent.SelectedInterventionModel.Start = StartingHour;
                    Parent.SelectedInterventionModel.Duration = TimeSpan.FromMinutes(Durata.HasValue ? Durata.Value : 0);
                    Parent.SelectedInterventionModel.Date = Date;
                    Parent.SelectedInterventionModel.Work = SelectedWork.Name;
                    Parent.SelectedInterventionModel.RowColorBrush = BackgroundColors.BackgroundFilled;
                    Parent.SelectedInterventionModel.End = StartingHour.AddMinutes(Durata.HasValue ? Durata.Value : 0);
                    Parent.SelectedInterventionModel.PatientName = SelectedPatient.AllName;
                    Parent.SelectedInterventionModel.PatientId = SelectedPatient.Id;
                    Parent.SelectedInterventionModel.WorkId = SelectedWork.Id;
                    Parent.SelectedInterventionModel.MaterialCost = materialCost;

                    if (CurrentRevenue.HasValue)
                    {
                        Parent.SelectedInterventionModel.ShouldSetPayed = true;
                        if (Parent.SelectedInterventionModel.revenueChanged)
                        {
                            Parent.SelectedInterventionModel.Remainder = revenue - CurrentRevenue.Value;
                        }
                        else
                        {
                            Parent.SelectedInterventionModel.Remainder = Parent.SelectedInterventionModel.Remainder - CurrentRevenue.Value;
                        }
                        Parent.SelectedInterventionModel.ShouldSetPayed = false;
                    }
                    if (SelectedArea != null)
                    {
                        Parent.SelectedInterventionModel.AreaId = SelectedArea.Id;
                        Parent.SelectedInterventionModel.Area = SelectedArea.Name;
                    }
                    PreviouslyAddedIntervention = Parent.SelectedInterventionModel;
                    await DatabaseHandler.Instance.EditIntervention(Parent.SelectedInterventionModel);
                    StartingHour = DateTime.Now;
                }
                else
                {
                    var revenue = Revenue.HasValue ? Revenue.Value : 0;
                    var modelIntervention = new InterventionModel();
                    modelIntervention.Id = Id;
                    modelIntervention.Location = SelectedLocation != null ? SelectedLocation.Name : "";
                    modelIntervention.Revenue = revenue;
                    modelIntervention.Percent = Convert.ToDouble((revenue - materialCost) * percentage);
                    modelIntervention.Start = StartingHour;
                    modelIntervention.Duration = TimeSpan.FromMinutes(Durata.HasValue ? Durata.Value : 0);
                    modelIntervention.Date = Date;
                    modelIntervention.Work = SelectedWork.Name;
                    modelIntervention.RowColorBrush = BackgroundColors.BackgroundFilled;
                    modelIntervention.End = StartingHour.AddMinutes(Durata.HasValue ? Durata.Value : 0);
                    modelIntervention.PatientName = SelectedPatient.AllName;
                    modelIntervention.PatientId = SelectedPatient.Id;
                    modelIntervention.WorkId = SelectedWork.Id;
                    modelIntervention.LocationId = SelectedLocation != null ? SelectedLocation.Id : 0;
                    modelIntervention.WasPayed = false;
                    modelIntervention.MaterialCost = materialCost;
                    if (CurrentRevenue.HasValue)
                    {
                        modelIntervention.ShouldSetPayed = true;
                        modelIntervention.Remainder = revenue - CurrentRevenue.Value;
                        modelIntervention.ShouldSetPayed = false;
                    }
                    else
                    {
                        modelIntervention.Remainder = 0;
                    }
                    if (SelectedArea != null)
                    {
                        modelIntervention.AreaId = SelectedArea.Id;
                        modelIntervention.Area = SelectedArea.Name;
                    }
                    PreviouslyAddedIntervention = modelIntervention;
                    modelIntervention.IsSelected = true;
                    modelIntervention.Id = await DatabaseHandler.Instance.SaveIntervention(modelIntervention, LocalCache.Instance.LocalUser.Id);
                    Parent.AddIntervention(modelIntervention);
                    LocalCache.Instance.Interventions.Add(modelIntervention);
                }

                InitInputs();

            }
            catch (Exception)
            {
                MessageBox.Show("Completati campurile inainte de a salva.");
            }

        }

        private void InitInputs()
        {
            try
            {
                SelectedPatient = new LocalPatient();
                SelectedLocation = new LocalLocation();
                SelectedWork = new LocalWork();
                SelectedArea = new SettingItem();
                SelectedLocation = new LocalLocation();
                Revenue = null;
                StartingHour = StartingHour.AddMinutes(Durata.HasValue ? Durata.Value : 0);
                Durata = null;
                IsPatientComboFocused = false;
                IsPatientComboFocused = true;
                IsEditMode = false;
                CurrentRevenue = null;
                SelectedPercentage = null;
                Parent.SelectedInterventionModel.revenueChanged = false;
                MaterialCost = null;
                SelectedPercentage = null;
                Date = DateTime.Now;
            }
            catch (Exception)
            {
                MessageBox.Show("A intervenit o eroare. Reporniți aplicația!");
            }

        }

        private void OnCancel()
        {
            InitInputs();
        }

        public async void AddPatient(string patientName)
        {

            int spaceOcc = patientName.IndexOf(" ");
            var patient = new LocalPatient()
            {
                LastName = spaceOcc > 0 ? patientName.Substring(spaceOcc + 1, patientName.Length - spaceOcc - 1) : patientName,
                FirstName = spaceOcc > 0 ? patientName.Substring(0, spaceOcc) : "",
                AllName = patientName,
                BirthDate = DateTime.Now

            };
            if (!PatientList.Any(item => item.FirstName == patient.FirstName && item.LastName == patient.LastName))
            {
                patient.Id = await DatabaseHandler.Instance.SavePatient(patient, LocalCache.Instance.LocalUser.Id);

                PatientList.Add(patient);
                LocalCache.Instance.Patients.Add(patient);
                patient.LastName = patient.LastName.TrimEnd();
                patient.AllName = patient.AllName.TrimEnd();
                SelectedPatient = patient;
            }
        }

        public void EditIntervention(InterventionModel interventionModel)
        {
            if (interventionModel != null)
            {
                Date = interventionModel.Date;
                SelectedLocation = Locations.FirstOrDefault(item => item.Id == interventionModel.LocationId);
                SelectedPatient = PatientList.FirstOrDefault(item => item.Id == interventionModel.PatientId);
                SelectedWork = Works.FirstOrDefault(item => item.Id == interventionModel.WorkId);
                StartingHour = interventionModel.Start;
                SelectedArea = Areas.FirstOrDefault(item => item.Id == interventionModel.AreaId);
                Durata = interventionModel.Duration.TotalMinutes;
                Revenue = interventionModel.Revenue;
                Remainder = interventionModel.Remainder;
                Id = interventionModel.Id;
                IsEditMode = true;
                MaterialCost = interventionModel.MaterialCost;
                var percentageValue = (double)(100 * interventionModel.Percent) / interventionModel.Revenue;
                SelectedPercentage = percentages.FirstOrDefault(item => item.Percentage == percentageValue);
            }
        }

        private void InitPercentage()
        {
            var listOfP = new ObservableCollection<Percent>();
            for (int i = 0; i < 11; i++)
            {
                listOfP.Add(new Percent()
                {
                    Percentage = i * 10
                });
            }
            Percentages = listOfP;
        }

        #endregion Methods

    }
}
