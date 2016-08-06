using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using DSA.Common.Controls.Buttons;
using DSA.Common.Infrastructure;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;
using DSA.Module.PersonalData.SettingsColumns.SettingsTile;
using DSA.Module.PersonalData.SettingsColumns.SettingsTile.EditSettingsTile;
using DSA.Module.PersonalData.SettingsDataScreen;
using DTS.Common.BusinessLogic;
using DTS.Common.DatabaseServer.EntitiesModel.Local;
using DTS.Jurnal.Database.SQLServer.Module;
using DTS.Jurnal.Database.SQLServer.Module.Helpers;
using Microsoft.Practices.Prism.Commands;

namespace DSA.Module.PersonalData.SettingsColumns.SettingsTileList
{
    public class SettingsTileListViewModel : ViewModelBase
    {
        #region Constructor

        public SettingsTileListViewModel(List<SettingItem> settingItems, SettingsScreenViewModel parent)
        {
            AddSettingButton = new ActionButtonViewModel("Adauga " + Name, new DelegateCommand(OnAddSetting), ImagePath.AddPatientPath);
            SaveButton = new ActionButtonViewModel("Salveaza", new DelegateCommand(OnSave), ImagePath.SaveIconPath);
            deletedSettingsIds = new List<int>();
            PopulateSettingsItems(settingItems);
            EditSettingsTileViewModel = new EditSettingsTileViewModel(this);
            Parent = parent;
        }

        #endregion Constructor

        #region Properties

        public SettingsScreenViewModel Parent { get; set; }

        public SettingsTileListView ViewReference { get; set; }

        private List<int> deletedSettingsIds;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value == name)
                    return;
                name = value;
                OnPropertyChanged();
            }
        }

        private Visibility addButtonVisibility = Visibility.Visible;

        public Visibility AddButtonVisibility
        {
            get { return addButtonVisibility; }
            set
            {
                if (value == addButtonVisibility)
                    return;
                addButtonVisibility = value;
                OnPropertyChanged();
            }
        }

        private ActionButtonViewModel saveButton;

        public ActionButtonViewModel SaveButton
        {
            get { return saveButton; }
            set
            {
                if (value == saveButton)
                    return;
                saveButton = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SettingsTileViewModel> settingsTileListModels;

        public ObservableCollection<SettingsTileViewModel> SettingsTileListModels
        {
            get { return settingsTileListModels; }
            set
            {
                if (value == settingsTileListModels)
                    return;
                settingsTileListModels = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SettingsTileViewModel> allSettingsTiles;

        public ObservableCollection<SettingsTileViewModel> AllsettingsTiles
        {
            get { return allSettingsTiles; }
            set
            {
                if (value == allSettingsTiles)
                    return;
                allSettingsTiles = value;
                OnPropertyChanged();
            }
        }

        private String searchedItem;
        public String SearchedItem
        {
            get { return searchedItem; }
            set
            {
                if (searchedItem != value)
                {
                    searchedItem = value;
                    Search(searchedItem);
                    OnPropertyChanged();
                }
            }
        }

        private EditSettingsTileViewModel editSettingsTileViewModel;
        public EditSettingsTileViewModel EditSettingsTileViewModel
        {
            get { return editSettingsTileViewModel; }
            set
            {
                if (value == editSettingsTileViewModel)
                    return;
                editSettingsTileViewModel = value;
                OnPropertyChanged();
            }
        }

        private Visibility editControlVisibility = Visibility.Collapsed;

        public Visibility EditControlVisibility
        {
            get { return editControlVisibility; }
            set
            {
                if (value == editControlVisibility)
                    return;
                editControlVisibility = value;
                OnPropertyChanged();
            }
        }

        private ActionButtonViewModel addSettingButton;

        public ActionButtonViewModel AddSettingButton
        {
            get { return addSettingButton; }
            set
            {
                if (value == addSettingButton)
                    return;
                addSettingButton = value;
                OnPropertyChanged();
            }
        }


        private bool wasChanged;

        public bool WasChanged
        {
            get { return wasChanged; }
            set
            {
                wasChanged = value;
                StackColor = wasChanged ? BackgroundColors.BackgroundFilled : null;
                OnPropertyChanged();
            }
        }

        private Brush stackColor;

        public Brush StackColor
        {
            get { return stackColor; }
            set
            {
                if (value == stackColor)
                    return;
                stackColor = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties

        #region Methods

        private void PopulateSettingsItems(List<SettingItem> settingItems)
        {
            AllsettingsTiles = new ObservableCollection<SettingsTileViewModel>();
            foreach (var settingsSubItem in settingItems)
            {
                AllsettingsTiles.Add(new SettingsTileViewModel(this)
                {
                    Id = settingsSubItem.Id,
                    Name = settingsSubItem.Name,
                    Cost = settingsSubItem.Cost,
                });
            }
            SettingsTileListModels = AllsettingsTiles;
        }

        public void RemoveItem(SettingsTileViewModel itemToDelete)
        {
            SettingsTileListModels.Remove(itemToDelete);
            AllsettingsTiles.Remove(itemToDelete);
            deletedSettingsIds.Add(itemToDelete.Id);
            WasChanged = true;
        }

        private void OnAddSetting()
        {
            var newAddedSetting = new SettingsTileViewModel(this);
            newAddedSetting.OnEdit();
            newAddedSetting.ContentBackGround = BackgroundColors.SuccessfulColor;
            AllsettingsTiles.Add(newAddedSetting);
            ViewReference.scrollViewerSettingsTileList.ScrollToBottom();
            WasChanged = true;
        }

        private void Search(string searchedWord)
        {
            searchedWord = searchedWord.ToLower();
            int wordLength = searchedWord.Length;
            // CurrentPatients = new ObservableCollection<PatientViewModel>(PatientsList.Where(item => item.Name.ToLower().Contains(searchedWord)));
            SettingsTileListModels = new ObservableCollection<SettingsTileViewModel>(AllsettingsTiles.Where(item => (item.Name != null && item.Name.Length >= wordLength && item.Name.ToLower().Substring(0, wordLength) == searchedWord)));
            //            SelectedPatient = CurrentPatients.FirstOrDefault();
        }

        private async void OnSave()
        {

            foreach (var settingsTileListModel in SettingsTileListModels)
            {
                if (!settingsTileListModel.OnSave())
                {
                    
                }
            }
            switch (Parent.CurrentType)
            {
                case SettingType.Locaiton:
                    await BusinessLogic.Instance.Databasehandler.DeleteLocations(deletedSettingsIds);
                    var locations =
                        await BusinessLogic.Instance.Databasehandler.AddEditLocationss(SettingsTileListModels.ToSettingItems());
                    if (locations != null)
                        LocalCache.Instance.Locations = locations;
                    PopulateSettingsItems(LocalCache.Instance.Locations);
                    break;
                case SettingType.Work:
                    await BusinessLogic.Instance.Databasehandler.DeleteWorks(deletedSettingsIds);
                    var works = await BusinessLogic.Instance.Databasehandler.AddEditWorks(SettingsTileListModels.ToSettingItems());
                    if (works != null)
                        LocalCache.Instance.Works = works;
                    PopulateSettingsItems(LocalCache.Instance.Works);
                    break;
                case SettingType.Area:
                    await BusinessLogic.Instance.Databasehandler.DeleteAreas(deletedSettingsIds);
                    var areas = await BusinessLogic.Instance.Databasehandler.AddEditAreas(SettingsTileListModels.ToSettingItems());
                    if (areas != null)
                        LocalCache.Instance.Areas = areas;
                    PopulateSettingsItems(LocalCache.Instance.Areas);
                    break;
                default: break;
            }

            deletedSettingsIds = new List<int>();
            WasChanged = false;
        }

        #endregion Methods

    }

    public enum SettingType { Locaiton, Work, Area }
}
