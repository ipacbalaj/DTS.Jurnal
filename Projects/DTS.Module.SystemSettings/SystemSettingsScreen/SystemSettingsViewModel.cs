using System.Windows.Media;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;

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

        #endregion Properties


        #region Methods


        #endregion Methods
    }
}
