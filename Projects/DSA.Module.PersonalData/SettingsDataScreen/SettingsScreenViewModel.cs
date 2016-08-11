using System;
using System.Windows;
using System.Windows.Media;
using DSA.Common.Controls.Buttons.OptionButton;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;
using DSA.Module.PersonalData.OptionsMenu;
using DSA.Module.PersonalData.SettingsColumns.SettingsTileList;
using DSA.Module.PersonalData.UserDetails;
using DTS.Jurnal.Database.SQLServer.Module;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace DSA.Module.PersonalData.SettingsDataScreen
{
    public class SettingsScreenViewModel : ViewModelBase
    {
        #region Constructor
        public SettingsScreenViewModel()
        {
            eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            eventAggregator.GetEvent<UpdateSettingsEvent>().Subscribe(UpdatePersonalDataScreen);
            OptionsMenuViewModel = new OptionsMenuViewModel(this);
        }
        #endregion Constructor

        #region Properties

        private bool initialized;

        private readonly IEventAggregator eventAggregator;
        private readonly IUnityContainer unityContainer;


        private UserDetailsViewModel userDetailsViewModel;
        public UserDetailsViewModel UserDetailsViewModel
        {
            get { return userDetailsViewModel; }
            set
            {
                if (userDetailsViewModel != value)
                {
                    userDetailsViewModel = value;
                    OnPropertyChanged();
                }
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

 
        private SettingsTileListViewModel settingsTileListViewModel;
        public SettingsTileListViewModel SettingsTileListViewModel
        {
            get { return settingsTileListViewModel; }
            set
            {
                if (value == settingsTileListViewModel)
                    return;
                settingsTileListViewModel = value;
                OnPropertyChanged();
            }
        }

        private SettingsTileListViewModel worksTileListViewModel;

        public SettingsTileListViewModel WorksTileListViewModel
        {
            get { return worksTileListViewModel; }
            set
            {
                if (value == worksTileListViewModel)
                    return;
                worksTileListViewModel = value;
                OnPropertyChanged();
            }
        }

        private SettingsTileListViewModel areasTileListViewModel;

        public SettingsTileListViewModel AreasTileListViewModel
        {
            get { return areasTileListViewModel; }
            set
            {
                if (value == areasTileListViewModel)
                    return;
                areasTileListViewModel = value;
                OnPropertyChanged();
            }
        }

        private SettingsTileListViewModel locationTileListViewModel;

        public SettingsTileListViewModel LocationTileListViewModel
        {
            get { return locationTileListViewModel; }
            set
            {
                if (value == locationTileListViewModel)
                    return;
                locationTileListViewModel = value;
                OnPropertyChanged();
            }
        }

        public SettingType CurrentType { get; set; }

        private OptionButtonViewModel worksButton;
        public OptionButtonViewModel WorksButton
        {
            get { return worksButton; }
            set
            {
                if (value == worksButton)
                    return;
                worksButton = value;
                OnPropertyChanged();
            }
        }

        private OptionButtonViewModel materialsButton;
        public OptionButtonViewModel MaterialsButton
        {
            get { return materialsButton; }
            set
            {
                if (value == materialsButton)
                    return;
                materialsButton = value;
                OnPropertyChanged();
            }
        }

        private OptionsMenuViewModel optionsMenuViewModel;
        public OptionsMenuViewModel OptionsMenuViewModel
        {
            get { return optionsMenuViewModel; }
            set
            {
                if (value == optionsMenuViewModel)
                    return;
                optionsMenuViewModel = value;
                OnPropertyChanged();
            }
        }

        private Visibility settingsListVisibility = Visibility.Collapsed;

        public Visibility SettingsListVisibility
        {
            get { return settingsListVisibility; }
            set
            {
                if (value == settingsListVisibility)
                    return;
                settingsListVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility technicianListVisibility = Visibility.Visible;

        public Visibility TechnicianListVisibility
        {
            get { return technicianListVisibility; }
            set
            {
                if (value == technicianListVisibility)
                    return;
                technicianListVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility worksVisibility;

        public Visibility WorksVisibility
        {
            get { return worksVisibility; }
            set
            {
                if (value == worksVisibility)
                    return;
                worksVisibility = value;
                OnPropertyChanged();
            }
        }


        //       private SettingsItemViewModel settingsItemViewModel;
        //
        //       public SettingsItemViewModel SettingsItemViewModel
        //       {
        //           get { return settingsItemViewModel; }
        //           set
        //           {
        //               if (value == settingsItemViewModel)
        //                   return;
        //               settingsItemViewModel = value;
        //               OnPropertyChanged();
        //           }
        //       }

        #endregion Properties

        #region Methods

        private void UpdatePersonalDataScreen(Object anObj)
        {
            if (!initialized)
            {
                initialized = true;
                OptionsMenuViewModel.OnWorks();
                InitSettings();
            }
        }

        private void InitSettings()
        {
            WorksTileListViewModel = new SettingsTileListViewModel(LocalCache.Instance.Works, this);
            LocationTileListViewModel = new SettingsTileListViewModel(LocalCache.Instance.Locations, this);
            AreasTileListViewModel = new SettingsTileListViewModel(LocalCache.Instance.Areas, this);
            OptionsMenuViewModel.OnWorks();
        }

        #endregion Methods

    }
}
