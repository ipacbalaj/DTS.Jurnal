using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using DSA.Common.Controls.Buttons;
using DSA.Common.Controls.Loading.MetroLoading;
using DSA.Common.Infrastructure;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;
using DSA.Module.PersonalInfo.PatientInformation;
using DTS.Common.BusinessLogic;
using DTS.Common.DatabaseServer.EntitiesModel;
using DTS.Common.DatabaseServer.EntitiesModel.Local;
using DTS.Jurnal.Database.SQLServer.Module;
using DTS.Jurnal.Database.SQLServer.Module.Helpers;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Brush = System.Windows.Media.Brush;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DSA.Module.PersonalInfo.PersonalInfoScreen
{
    public class PersonalInfoScreenViewModel : ViewModelBase
    {
        #region Constructor

        public PersonalInfoScreenViewModel()
        {
            eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            eventAggregator.GetEvent<UpdatePersonalInfoEvent>().Subscribe(UpdatePersonalInfoScreen);
            //            eventAggregator.GetEvent<PatientSelectedEvent>().Subscribe(OnPatientSelected);
            //            eventAggregator.GetEvent<PatientDoubleClickedEvent>().Subscribe(OnPatientSelected);
            SaveBtn = new ActionButtonViewModel("Salveaza", new DelegateCommand(OnSave), ImagePath.SaveIconPath);
            EditButton = new ActionButtonViewModel("Editeaza", new DelegateCommand(OnEdit), ImagePath.PatientEditPath);
            CancelButton = new ActionButtonViewModel("Renunta", new DelegateCommand(OnCancel), ImagePath.CancelIconPath);
            DeletePatientButton = new ActionButtonViewModel("Șterge Pacient", new DelegateCommand(OnDelete), ImagePath.CancelIconPath);
        }

        #endregion Constructor

        #region Properties

        private Visibility patientDetailsVisibility = Visibility.Collapsed;

        public Visibility PatientDetailsVisibility
        {
            get { return patientDetailsVisibility; }
            set
            {
                if (value == patientDetailsVisibility)
                    return;
                patientDetailsVisibility = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LocalPatient> patients;

        public ObservableCollection<LocalPatient> Patients
        {
            get { return patients; }
            set
            {
                if (value == patients)
                    return;
                patients = value;
                OnPropertyChanged();
            }
        }

        private List<LocalPatient> seleLocalPatients;

        public List<LocalPatient> SelectedLocalPatients
        {
            get { return seleLocalPatients; }
            set
            {
                if (value == seleLocalPatients)
                    return;
                seleLocalPatients = value;
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
                if (selectedPatient != null)
                {
                    PatientDetailsVisibility = Visibility.Visible;
                    PatientInformationViewModel = selectedPatient.ToPatientInformationViewModel(this);
                    Interventions = new ObservableCollection<InterventionModel>(BusinessLogic.Instance.Databasehandler.GetPatientInterventions(selectedPatient.Id));
                        //new ObservableCollection<InterventionModel>(LocalCache.Instance.Interventions.Where(item => item.PatientId == selectedPatient.Id));
                }
                else
                {
                    PatientDetailsVisibility = Visibility.Collapsed;
                }
                OnPropertyChanged();
            }
        }

        private Task backgroundTask;
        private Task uiTask;

        public PersonalInfoScreenView ViewReference { get; set; }

        private bool initialized;

        private MetroLoadingViewModel metroLoadingViewModel;

        public MetroLoadingViewModel MetroLoadingViewModel
        {
            get { return metroLoadingViewModel; }
            set
            {
                if (value == metroLoadingViewModel)
                    return;
                metroLoadingViewModel = value;
                OnPropertyChanged();
            }
        }

        private Brush contentBackground = BackgroundColors.JurnalColor;

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

        private Visibility editVisibility = Visibility.Collapsed;

        public Visibility EditVisibility
        {
            get { return editVisibility; }
            set
            {
                if (value == editVisibility)
                    return;
                editVisibility = value;
                OnPropertyChanged();
            }
        }

        private ActionButtonViewModel editButton;
        public ActionButtonViewModel EditButton
        {
            get { return editButton; }
            set
            {
                if (value == editButton)
                    return;
                editButton = value;
                OnPropertyChanged();
            }
        }

        private ActionButtonViewModel cancelButton;

        public ActionButtonViewModel CancelButton
        {
            get { return cancelButton; }
            set
            {
                if (value == cancelButton)
                    return;
                cancelButton = value;
                OnPropertyChanged();
            }
        }

        private ActionButtonViewModel saveBtn;

        public ActionButtonViewModel SaveBtn
        {
            get { return saveBtn; }
            set
            {
                if (value == saveBtn)
                    return;
                saveBtn = value;
                OnPropertyChanged();
            }
        }

        private ActionButtonViewModel _deletePatientButton;

        public ActionButtonViewModel DeletePatientButton
        {
            get { return _deletePatientButton; }
            set
            {
                if (value == _deletePatientButton)
                    return;
                _deletePatientButton = value;
                OnPropertyChanged();
            }
        }

        private Visibility regularVisibility = Visibility.Visible;

        public Visibility RegularVisibility
        {
            get { return regularVisibility; }
            set
            {
                if (value == regularVisibility)
                    return;
                regularVisibility = value;
                OnPropertyChanged();
            }
        }

        private bool isEdited;

        public bool IsEdit
        {
            get { return isEdited; }
            set
            {
                if (value == isEdited)
                    return;
                isEdited = value;
                if (isEdited)
                {
                    EditVisibility = Visibility.Visible;
                    RegularVisibility = Visibility.Collapsed;
                }
                else
                {
                    EditVisibility = Visibility.Collapsed;
                    RegularVisibility = Visibility.Visible;
                }
                OnPropertyChanged();
            }
        }

        private readonly IEventAggregator eventAggregator;
        private readonly IUnityContainer unityContainer;

        private PatientInformationViewModel patientInformationViewModel;
        public PatientInformationViewModel PatientInformationViewModel
        {
            get { return patientInformationViewModel; }
            set
            {
                if (value == patientInformationViewModel)
                    return;
                patientInformationViewModel = value;
                OnPropertyChanged();
            }
        }

        private ActionButtonViewModel _editSaveButton;
        public ActionButtonViewModel EditSaveButton
        {
            get { return _editSaveButton; }
            set
            {
                if (_editSaveButton == value)
                    return;
                _editSaveButton = value;
                OnPropertyChanged();
            }
        }

        private int patientId;
        public int PatientId
        {
            get { return patientId; }
            set
            {
                if (value == patientId)
                    return;
                patientId = value;
                OnPropertyChanged();
            }
        }

        private string expanderRotation = "90";
        public string ExpanderRotation
        {
            get { return expanderRotation; }
            set
            {
                if (expanderRotation != value)
                {
                    expanderRotation = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility interventionsVisibility = Visibility.Visible;
        public Visibility InterventionsVisibility
        {
            get { return interventionsVisibility; }
            set
            {
                if (value == interventionsVisibility)
                    return;
                interventionsVisibility = value;
                OnPropertyChanged();
            }
        }

        private Brush interventionTabColor = BackgroundColors.JurnalColor;
        public Brush InterventionTabColor
        {
            get { return interventionTabColor; }
            set
            {
                if (interventionTabColor != value)
                {
                    interventionTabColor = value;
                    OnPropertyChanged();
                }
            }
        }

        private UIElement editIcon;

        public UIElement EditICon
        {
            get { return editIcon; }
            set
            {
                if (value == editIcon)
                    return;
                editIcon = value;
                OnPropertyChanged();
            }
        }

        private UIElement saveIcon;

        public UIElement SaveIcon
        {
            get { return saveIcon; }
            set
            {
                if (value == saveIcon)
                    return;
                saveIcon = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<InterventionModel> interventions;

        public ObservableCollection<InterventionModel> Interventions
        {
            get { return interventions; }
            set
            {
                if (value == interventions)
                    return;
                interventions = value;
                OnPropertyChanged();
            }
        }
        #endregion Properties

        #region Methods

        private void UpdatePersonalInfoScreen(Object anObj)
        {
            if (!initialized)
            {
                InterventionsVisibility = Visibility.Visible;
                initialized = true;
            }
            Patients = new ObservableCollection<LocalPatient>(LocalCache.Instance.Patients);
        }

        public void OnShowInterventions()
        {
            if (PatientId != 0)
            {
                //                Interventions = new ObservableCollection<InterventionDetails>( BusinessLogic.Instance.Databasehandler.GetPatientInterventions(PatientId).Select(item => item.ToInterventionDetails()));
                InterventionsVisibility = InterventionsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                ExpanderRotation = ExpanderRotation == "270" ? "90" : "270";
            }
            else
            {
                MessageBox.Show("Nicu un pacient Selectat");
            }
        }

        public void MouseOn()
        {
            InterventionTabColor = BackgroundColors.PatientsListColorOver;
        }

        public void MouseOff()
        {

            InterventionTabColor = BackgroundColors.PatientsListColor;
        }

        private void OnEdit()
        {
            if (!IsEdit)
            {
                IsEdit = true;

            }
            else
            {

                IsEdit = false;
            }

        }

        private void OnCancel()
        {
            RegularVisibility = Visibility.Visible;
            EditVisibility = Visibility.Collapsed;
            //            if(CurrentPatinent!=null)
            //            PatientInformationViewModel = CurrentPatinent.ToPatientInformationViewModel(this);
            IsEdit = false;
        }

        private void OnSave()
        {
            try
            {
                RegularVisibility = Visibility.Visible;
                EditVisibility = Visibility.Collapsed;
                var editedPatient = LocalCache.Instance.Patients.FirstOrDefault(item => item.Id == SelectedPatient.Id);
                editedPatient.CopyToLocalPatient(PatientInformationViewModel);
                Patients=new ObservableCollection<LocalPatient>(LocalCache.Instance.Patients);
                BusinessLogic.Instance.Databasehandler.EditPatient(editedPatient);
                IsEdit = false;
            }
            catch (Exception)
            {

                MessageBox.Show("A intervenit o eroare la salvare.");
            }
        }

        public void MergePatients()
        {
            if (SelectedLocalPatients==null ||SelectedLocalPatients.Count<2)
            {
                MessageBox.Show("Cel puțin 2 pacienți trebuie selectați pentru a folosi funcția de îmbinare");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Doriți sa îmbinați pacienții:" + string.Join(",",SelectedLocalPatients.Select(item=>item.FirstName+" "+item.LastName)) + " ?", "Atentie", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    BusinessLogic.Instance.Databasehandler.MergePatients(SelectedLocalPatients.Select(item => item.Id).ToList());
                    var patientsToRemove = SelectedLocalPatients.Skip(1).ToList();
                    SelectedPatient = SelectedLocalPatients.FirstOrDefault();
                    foreach (var localPatient in patientsToRemove)
                    {
                        Patients.Remove(localPatient);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("A intervenit o eroare.Intervenția nu a fost ștearsă!");
                }

            }
        }

        private async void OnDelete()
        {
            try
            {
                await BusinessLogic.Instance.Databasehandler.DeletePatient(SelectedPatient.Id);
                LocalCache.Instance.DeletePatient(SelectedPatient.Id);
                Patients.Remove(SelectedPatient);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pacientul nu a fost șters!Selectați pacientul si reîncercați sa il ștergeți.");
            }
        }
        #endregion Methods
    }
}
