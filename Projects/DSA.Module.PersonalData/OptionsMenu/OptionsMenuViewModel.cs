using System;
using System.Windows;
using System.Windows.Media;
using DSA.Common.Controls.Buttons.OptionButton;
using DSA.Common.Infrastructure;
using DSA.Common.Infrastructure.Icos;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;
using DSA.Module.PersonalData.SettingsColumns.SettingsTileList;
using DSA.Module.PersonalData.SettingsDataScreen;
using Microsoft.Practices.Prism.Commands;
using TULIP.Common.Controls.Icons;

namespace DSA.Module.PersonalData.OptionsMenu
{
    public class OptionsMenuViewModel : ViewModelBase
    {

        #region Properties

        public SettingsScreenViewModel Parent { get; set; }

        public OptionButtonViewModel WorksButtonViewModel { get; private set; }
        public OptionButtonViewModel MaterialsButtonViewModel { get; private set; }
        public OptionButtonViewModel LocationButtonViewModel { get; private set; }
        public OptionButtonViewModel AreaButtonViewModel { get; private set; }
        public OptionButtonViewModel SelectedButton { get; private set; }

        private Brush contentBackground;
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

        #endregion

        #region Constructor

        public OptionsMenuViewModel(SettingsScreenViewModel parent)
        {
            Parent = parent;
            SelectedButton = new OptionButtonViewModel();
            InitButtons();
        }

        #endregion

        #region Methods

        private void InitButtons()
        {
            WorksButtonViewModel = new OptionButtonViewModel
            {
                ImagePath = ImagePath.Work,
                OnClick = new DelegateCommand(OnWorks),
                Name = "Manopere"
            };

            MaterialsButtonViewModel = new OptionButtonViewModel
            {
                ImagePath = ImagePath.Materiale,
                OnClick = new DelegateCommand(OnMaterials),
                Name = "Materiale",
            };

            LocationButtonViewModel = new OptionButtonViewModel
            {
                ImagePath = ImagePath.Location,
                OnClick = new DelegateCommand(OnLocation),
                Name = "Locatie",
            };

            AreaButtonViewModel = new OptionButtonViewModel
            {
                ImagePath = ImagePath.Zona,
                OnClick = new DelegateCommand(OnArea),
                Name = "Zona",
            };
        }

        public void OnWorks()
        {
            SelectedButton.IsSelected = false;
            WorksButtonViewModel.IsSelected = true;
            SelectedButton = WorksButtonViewModel;
            Parent.SettingsTileListViewModel = Parent.WorksTileListViewModel;
            Parent.CurrentType = SettingType.Work;            
        }

        private void OnMaterials()
        {
            SelectedButton.IsSelected = false;
            MaterialsButtonViewModel.IsSelected = true;
            SelectedButton = MaterialsButtonViewModel;
            SetVisibility(true);            
        }

        private void OnLocation()
        {
            SelectedButton.IsSelected = false;
            LocationButtonViewModel.IsSelected = true;
            SelectedButton = LocationButtonViewModel;
            Parent.SettingsTileListViewModel = Parent.LocationTileListViewModel;
            Parent.CurrentType = SettingType.Locaiton;            
        }

        private void OnArea()
        {
            SelectedButton.IsSelected = false;
            AreaButtonViewModel.IsSelected = true;
            SelectedButton = AreaButtonViewModel;
            Parent.SettingsTileListViewModel = Parent.AreasTileListViewModel;
            Parent.CurrentType = SettingType.Area;
        }

        private void SetVisibility(bool isTechnician)
        {
            if (isTechnician)
            {
                Parent.SettingsListVisibility = Visibility.Collapsed;
                Parent.WorksVisibility = Visibility.Collapsed;
                Parent.TechnicianListVisibility = Visibility.Visible;
            }
            else
            {
                Parent.SettingsListVisibility = Visibility.Visible;
                Parent.TechnicianListVisibility = Visibility.Collapsed;
                Parent.WorksVisibility = Visibility.Collapsed;
            }
        }

        private void SetWorkVis()
        {
            Parent.SettingsListVisibility = Visibility.Collapsed;
            Parent.WorksVisibility = Visibility.Visible;
            Parent.TechnicianListVisibility = Visibility.Collapsed;
        }

        #endregion

    }
}
