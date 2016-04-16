using System.Security;
using System.Windows.Input;
using System.Windows.Media;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;

namespace DSA.Common.Controls.LoginControls.PasswordBar
{
    /// <summary>
    /// Represent the password bar from login control.
    /// </summary>
    public class PasswordBarViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordBarViewModel"/> class.
        /// </summary>
        public PasswordBarViewModel()
        {
            ButtonBackground = mouseOffColor;
        }

        private SecureString password;
        public SecureString Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }

        private Brush mouseOffColor = BackgroundColors.ButtonMouseOffColor;
        private Brush mouseOnColor = BackgroundColors.ButtonMouseOnColor;
        private Brush buttonBackground;
        public Brush ButtonBackground
        {
            get { return buttonBackground; }
            set
            {
                buttonBackground = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Changes the backgroud.
        /// </summary>
        public void ChangeBackgroud()
        {
            if (ButtonBackground.Equals(mouseOffColor))
            {
                ButtonBackground = mouseOnColor;
            }
            else
            {
                ButtonBackground = mouseOffColor;
            }
        }

        public void ExecuteLoginCommand()
        {
            LoginCommand.Execute(null);
        }

        public ICommand LoginCommand { get; set; }
    }
}
