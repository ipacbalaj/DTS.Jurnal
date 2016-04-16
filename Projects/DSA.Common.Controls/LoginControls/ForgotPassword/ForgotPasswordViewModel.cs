using System;
using System.Windows;
using System.Windows.Input;
using DSA.Common.Infrastructure.ViewModel;

namespace DSA.Common.Controls.LoginControls.ForgotPassword
{
    /// <summary>
    /// Represent the forgot password control from login control.
    /// </summary>
    public class ForgotPasswordViewModel : ViewModelBase
    {
        private String code;
        public String Code
        {
            get { return code; }
            set
            {
                if (code != value)
                {
                    code = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility invalidCodeVisibility = Visibility.Collapsed;
        public Visibility InvalidCodeVisibility
        {
            get { return invalidCodeVisibility; }
            set
            {
                if (invalidCodeVisibility  != value)
                {
                    invalidCodeVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ResetPasswordCommand { get; set; }
    }
}
