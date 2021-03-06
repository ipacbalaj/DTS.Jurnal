﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using DSA.Common.Controls.Buttons;
using DSA.Common.Infrastructure;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;
using DSA.FileUpload.ExcelFile;
using DTS.Common.BusinessLogic;
using DTS.Common.DatabaseServer;
using DTS.Common.DatabaseServer.EntitiesModel;
using DTS.Jurnal.Database.SQLServer.Module;
using DTS_Jurnal.Jurnal.AddInterventionTile;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace DTS_Jurnal.Jurnal.JurnalScreen
{
    public class JurnalViewModel : ViewModelBase
    {
        #region Constructor

        public JurnalViewModel(JurnalView gridControl)
        {
            eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            AddInterventionTileViewModel = new AddInterventionTileViewModel(this);
            ExportButton = new ActionButtonViewModel("Exportă Tot", new DelegateCommand(OnExport), ImagePath.GenerateWord);
            DeleteDataButton = new ActionButtonViewModel("Șterge", new DelegateCommand(OnDeletee), ImagePath.CancelIconPath);
            ExportSelectedButton = new ActionButtonViewModel("Exportă Selectate", new DelegateCommand(OnExportSelected), ImagePath.GenerateWord);
            ExportPatientsButton = new ActionButtonViewModel("Exportă Pacienți", new DelegateCommand(OnExportPatients), ImagePath.ContabiliitateIconPath);
            GetAllInterventionsButton = new ActionButtonViewModel("Incarcă toate intervențiile", new DelegateCommand(OnLoadAllInterventions), ImagePath.RapoarteIconPath);
            eventAggregator.GetEvent<UpdateDentalRecordsEvent>().Subscribe(UpdateJurnalScreen);
            GridControl = gridControl;
            DeleteRowCommand = new DelegateCommand<InterventionModel>(OnDelete);
        }

        #endregion Constructor

        #region Properties

        public ICommand DeleteRowCommand { get; private set; }

        private JurnalView GridControl { get; set; }

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

        private readonly IEventAggregator eventAggregator;
        private readonly IUnityContainer unityContainer;

        #region Buttons

        private ActionButtonViewModel deleteDataButton;

        public ActionButtonViewModel DeleteDataButton
        {
            get { return deleteDataButton; }
            set
            {
                if (value == deleteDataButton)
                    return;
                deleteDataButton = value;
                OnPropertyChanged();
            }
        }

        private ActionButtonViewModel exportButton;

        public ActionButtonViewModel ExportButton
        {
            get { return exportButton; }
            set
            {
                if (value == exportButton)
                    return;
                exportButton = value;
                OnPropertyChanged();
            }
        }

        private ActionButtonViewModel exportPatientsButton;

        public ActionButtonViewModel ExportPatientsButton
        {
            get { return exportPatientsButton; }
            set
            {
                if (value == exportPatientsButton)
                    return;
                exportPatientsButton = value;
                OnPropertyChanged();
            }
        }

        private ActionButtonViewModel getAllInterventionsButton;

        public ActionButtonViewModel GetAllInterventionsButton
        {
            get { return getAllInterventionsButton; }
            set
            {
                if (value == getAllInterventionsButton)
                    return;
                getAllInterventionsButton = value;
                OnPropertyChanged();
            }
        }

        private ActionButtonViewModel exportSelectedButton;
        public ActionButtonViewModel ExportSelectedButton
        {
            get { return exportSelectedButton; }
            set
            {
                if (value == exportSelectedButton)
                    return;
                exportSelectedButton = value;
                OnPropertyChanged();
            }
        }

        #endregion Buttons

        #region Lists

        private List<InterventionModel> selectedInterventions;
        public List<InterventionModel> SelectedInterventions
        {
            get { return selectedInterventions; }
            set
            {
                if (value == selectedInterventions)
                    return;
                selectedInterventions = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<InterventionModel> interventions = new ObservableCollection<InterventionModel>();
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

        private AddInterventionTileViewModel addInterventionTileViewModel;
        public AddInterventionTileViewModel AddInterventionTileViewModel
        {
            get { return addInterventionTileViewModel; }
            set
            {
                if (value == addInterventionTileViewModel)
                    return;
                addInterventionTileViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion Lists

        private InterventionModel selectedInterventionModel;

        public InterventionModel SelectedInterventionModel
        {
            get { return selectedInterventionModel; }
            set
            {

                if (value == selectedInterventionModel)
                    return;
                selectedInterventionModel = value;
                OnPropertyChanged();
            }
        }

        private bool showLoadingPanel = true;
        public bool ShowLoadingPanel
        {
            get { return showLoadingPanel; }
            set
            {
                if (value == showLoadingPanel)
                    return;
                showLoadingPanel = value;
                OnPropertyChanged();
            }
        }

        private double totalSelected;
        public double TotalSelected
        {
            get { return totalSelected; }
            set
            {
                if (value == totalSelected)
                    return;
                totalSelected = value;
                OnPropertyChanged();
            }
        }

        private double total;
        public double Total
        {
            get { return total; }
            set
            {
                if (value == total)
                    return;
                total = value;
                OnPropertyChanged();
            }
        }

        private double totalActive;

        public double TotalActive
        {
            get { return totalActive; }
            set
            {
                if (value == totalActive)
                    return;
                totalActive = value;
                OnPropertyChanged();
            }
        }

        private DateTime startingDate = DateTime.Now.AddMonths(-3);
        public DateTime StartingDate
        {
            get { return startingDate; }
            set
            {
                if (value == startingDate)
                    return;
                startingDate = value;
                LoadInterventionsFromDate(startingDate, InterventionsLoadType.ByDate);
                OnPropertyChanged();
            }
        }

        #endregion Properties

        #region Methods

        #region load

        private void LoadInterventionsFromDate(DateTime date, InterventionsLoadType interventionsLoadType)
        {
            GetInterventionsByDate(date, interventionsLoadType);
            SelectedInterventionModel = Interventions.LastOrDefault();
        }

        private async void GetInterventionsByDate(DateTime date, InterventionsLoadType interventionsLoadType)
        {
            ShowLoadingPanel = true;
            await LocalCache.Instance.InitInterventionsStartTask(date, interventionsLoadType);
            Interventions = new ObservableCollection<InterventionModel>(LocalCache.Instance.Interventions);
            SetTotals();
            ShowLoadingPanel = false;
            SelectedInterventionModel = Interventions.LastOrDefault();
        }

        private void OnLoadAllInterventions()
        {
            GetInterventionsByDate(new DateTime(), InterventionsLoadType.All);
        }

        private void SetTotals()
        {
            double totalSelected = 0;
            double total = 0;
            foreach (var interventionModel in Interventions)
            {
                if (interventionModel.IsSelected)
                {
                    totalSelected += interventionModel.Percent;
                }
                total += interventionModel.Revenue;
            }
            TotalSelected = totalSelected;
            Total = total;
        }

        private void InitData()
        {
            Interventions = new ObservableCollection<InterventionModel>(LocalCache.Instance.Interventions);
            SelectedInterventionModel = Interventions.LastOrDefault();
            SetTotals();
            LocalCache.Instance.InterventionLoaded = true;
            ShowLoadingPanel = false;
        }

        #endregion load

        #region actions

        public void AddIntervention(InterventionModel intervention)
        {
            Total += intervention.Revenue;
            TotalSelected += intervention.Percent;
            Interventions.Add(intervention);
            SelectedInterventionModel = intervention;
            SetTimer();
        }

        private void OnExport()
        {
            var sortedInterventions = Interventions.OrderBy(item => item.Date).ThenBy(item => item.Start);
            ExcelExporter.ExportExcelFile(sortedInterventions.ToList());
        }

        private async void OnExportPatients()
        {
            await ExcelExporter.ExportPatients(LocalCache.Instance.Patients.Where(item => (!item.WasExported.HasValue || (item.WasExported.HasValue && !item.WasExported.Value))).ToList());
        }

        private void OnExportSelected()
        {
            var selectedInterventions = Interventions.Where(item => item.IsSelected).OrderBy(item => item.Date).ThenBy(item => item.Start).ToList();
            ExcelExporter.ExportExcelFile(selectedInterventions);
        }

        private void OnDeletee()
        {
            DialogResult result1 = MessageBox.Show("Doriţi sa goliți lista de manopere?", "Atentie", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                BusinessLogic.Instance.Databasehandler.DeleteInterventions();
                Interventions = new ObservableCollection<InterventionModel>();
            }
        }

        public void ModifySelectedTotal(bool shouldAdd, double valueToAdd, int interventionId)
        {
            if (shouldAdd)
            {
                TotalSelected += valueToAdd;
            }
            else
            {
                TotalSelected -= valueToAdd;
            }
            var intModel = Interventions.FirstOrDefault(item => item.Id == interventionId);
            intModel.IsSelected = shouldAdd;
            BusinessLogic.Instance.Databasehandler.SetInterventionSelectionStatus(interventionId, shouldAdd);
        }

        public void EditIntervention()
        {
            AddInterventionTileViewModel.EditIntervention(SelectedInterventionModel);
        }

        public void ClearSelection()
        {
            if (AddInterventionTileViewModel.PreviouslyAddedIntervention != null)
            {
                if (AddInterventionTileViewModel.PreviouslyAddedIntervention.WasPayed)
                {
                    AddInterventionTileViewModel.PreviouslyAddedIntervention.RowColorBrush = null;
                }
                else
                {
                    AddInterventionTileViewModel.PreviouslyAddedIntervention.RowColorBrush = BackgroundColors.GridNotPayedColor;
                }
            }
        }

        public void ClearSelectedRow()
        {
            if (!AddInterventionTileViewModel.IsEditMode)
            {
                SelectedInterventionModel = null;
            }
        }

        public void ModifyPaymentStatus(InterventionModel rowintervention)
        {
            //            var currentIntervention = Interventions.FirstOrDefault(item => item.Id == rowintervention.Id);
            //if (rowintervention.Remainder > 0 && !rowintervention.WasPayed)
            //{
            //    DialogResult dialogResult = MessageBox.Show("Pacientul mai are de platit " + rowintervention.Remainder + " lei. Doriti sa setati manopera platita?", "Atentie", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        currentIntervention.ShouldSetPayed = true;
            //        currentIntervention.WasPayed = !rowintervention.WasPayed;
            //        currentIntervention.Remainder = 0;
            //        currentIntervention.ShouldSetPayed = false;
            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {

            //    }
            //}
            //else
            //{
            //    currentIntervention.ShouldSetPayed = true;
            //    currentIntervention.WasPayed = !rowintervention.WasPayed;
            //    currentIntervention.ShouldSetPayed = false;
            //}
            BusinessLogic.Instance.Databasehandler.SetInterventionPayed(rowintervention.Id, !rowintervention.WasPayed);
        }

        private async void OnDelete(InterventionModel interventionModel)
        {
            DialogResult dialogResult = MessageBox.Show("Doriți sî ștergeți manopera?", "Atentie", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    await BusinessLogic.Instance.Databasehandler.DeleteIntervention(interventionModel.Id);
                    Interventions.Remove(interventionModel);
                    LocalCache.Instance.Interventions.Remove(interventionModel);
                    Total -= interventionModel.Revenue;
                    TotalSelected -= interventionModel.Percent;
                }
                catch (Exception)
                {
                    MessageBox.Show("A intervenit o eroare.Intervenția nu a fost ștearsă!");
                }

            }
        }

        #endregion actions

        private bool initialized = false;

        private void UpdateJurnalScreen(Object anObj)
        {
            if (!initialized)
            {
                InitData();
                ClearSelection();
                initialized = true;
            }
            AddInterventionTileViewModel.InitData();
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            var aTimer = new System.Timers.Timer(5000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            ClearSelection();
        }

        public async void SetSelectedInverventionsPaymentStatus()
        {
            var interventionsToModify = new List<int>();
            try
            {
                var firstOrDefault = SelectedInterventions.FirstOrDefault();
                bool wasPayed = firstOrDefault != null && !firstOrDefault.WasPayed;
                foreach (var selectedIntervention in SelectedInterventions)
                {
                    if (wasPayed && selectedIntervention.Remainder > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Pacientul " + selectedIntervention.PatientName + " mai are de plătit " + selectedIntervention.Remainder + " lei. Doriți sa setați manopera platită?", "Atentie", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            selectedIntervention.ShouldSetPayed = true;
                            selectedIntervention.WasPayed = true;
                            selectedIntervention.Remainder = 0;
                            selectedIntervention.ShouldSetPayed = false;
                            interventionsToModify.Add(selectedIntervention.Id);
                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                    }
                    else
                    {
                        selectedIntervention.WasPayed = wasPayed;
                        interventionsToModify.Add(selectedIntervention.Id);
                    }
                }
                await BusinessLogic.Instance.Databasehandler.SetInterventionsPaymentStatus(interventionsToModify, wasPayed);
            }
            catch (Exception)
            {
                MessageBox.Show("A intervenit o eroare la salvare.Timpul alocat de procesare a fost depasit");
            }
        }

        public async void SetSelectedInterventionsSelectedStatus()
        {
            try
            {
                var firstOrDefault = SelectedInterventions.FirstOrDefault();
                bool isSelected = firstOrDefault != null && !firstOrDefault.IsSelected;
                await BusinessLogic.Instance.Databasehandler.SetInterventionsSelectionStatus(SelectedInterventions.Select(item => item.Id).ToList(), isSelected);
                foreach (var selectedIntervention in SelectedInterventions)
                {
                    selectedIntervention.IsSelected = isSelected;
                    if (isSelected)
                    {
                        TotalSelected += selectedIntervention.Percent;
                    }
                    else
                    {
                        TotalSelected -= selectedIntervention.Percent;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("A intervenit o eroare la salvare.Timpul alocat de procesare a fost depasit");
            }
        }

        #endregion Methods
    }
}
