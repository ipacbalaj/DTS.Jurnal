using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;
using Microsoft.Practices.Prism.Commands;

namespace DSA.Common.Controls.LoginControls.UsernameBar
{
    /// <summary>
    /// Represent the username bar from login control.
    /// </summary>
    public class UsernameBarViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsernameBarViewModel"/> class.
        /// </summary>
        public UsernameBarViewModel()
        {
            ButtonBackground = mouseOffColor;
            UsernameChangeCommand = new DelegateCommand(ChangeTextModeVisibility);
        }

        private Visibility buttonVisibility = Visibility.Collapsed;
        public Visibility ButtonVisibility
        {
            get { return buttonVisibility; }
            set
            {
                if (buttonVisibility != value)
                {
                    buttonVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility textBlockVisibility = Visibility.Visible;
        public Visibility TextBlockVisibility
        {
            get { return textBlockVisibility; }
            set
            {
                if (textBlockVisibility != value)
                {
                    textBlockVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility textBoxVisibility = Visibility.Collapsed;
        public Visibility TextBoxVisibility
        {
            get { return textBoxVisibility; }
            set
            {
                if (textBoxVisibility != value)
                {
                    textBoxVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Changes the button visibility.
        /// </summary>
        public void ChangeButtonVisibility()
        {
            ButtonVisibility = ButtonVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <summary>
        /// Changes the text mode visibility.
        /// </summary>
        public void ChangeTextModeVisibility()
        {
            if (TextBlockVisibility == Visibility.Visible)
            {
                TextBlockVisibility = Visibility.Collapsed;
                TextBoxVisibility = Visibility.Visible;
            }
            else
            {
                TextBlockVisibility = Visibility.Visible;
                TextBoxVisibility = Visibility.Collapsed;
            }
        }

        public ICommand UsernameChangeCommand { get; set; }

        private String description = "Dentist";
        public String Description
        {
            get { return description; }
            set
            {
                if (description == value)
                    return;

                description = value;
                OnPropertyChanged();
            }
        }

        private String username = "Username";
        public String Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    if (username == null)
                    {
                        ChangeTextModeVisibility();
                    }
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
            ButtonBackground = ButtonBackground.Equals(mouseOffColor) ? mouseOnColor : mouseOffColor;
        }
    }
}
