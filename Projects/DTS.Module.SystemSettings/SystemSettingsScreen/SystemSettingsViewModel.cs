using System.Windows.Media;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;
using DSA.Module.PersonalData.OptionsMenu;

namespace DTS.Module.SystemSettings.SystemSettingsScreen
{
    public class SystemSettingsViewModel : ViewModelBase
    {
        #region Constructor

        public SystemSettingsViewModel()
        {
            
        }
    
        #endregion Constructor

        #region Properties

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

        #endregion Properties

        #region Methods


        #endregion Methods
    }
}
