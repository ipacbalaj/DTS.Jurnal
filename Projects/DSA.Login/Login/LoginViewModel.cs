using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DSA.Common.Controls.Buttons;
using DSA.Common.Controls.LoginControls.ForgotPassword;
using DSA.Common.Controls.LoginControls.PasswordBar;
using DSA.Common.Controls.LoginControls.UsernameBar;
using DSA.Common.Infrastructure.Helpers;
using DSA.Common.Infrastructure.Login;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;
using DSA.Database.Model;
using DSA.Database.Model.Helpers;
using DSA.Module.PersonalData.FTP_Settings;
using DTS.Jurnal.V3.Database.Module;
using DTS.Jurnal.V3.Database.Module.Entities.Local;
using DTS.Jurnal.V3.Database.Module.Helpers;
using log4net;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;

namespace DSA.Login.Login
{
    /// <summary>
    /// contains all data needed to model the LoginView
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        ///  IEventAggregator Defines an interface to get instances of an event.
        /// </summary>
        private IEventAggregator eventAgg;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// We also create new instances of :<see cref="UsernameBarViewModel"/>,<see cref="PasswordBarViewModel"/>,
        ///                                  <see cref="ForgotPasswordViewModel"/>
        /// set initial values for Background,ControlsBackground
        /// subscribe an event handler for an event of type UpdateConnectionStatusEvent 
        /// 
        /// </summary>
        public LoginViewModel()
        {
            eventAgg = ServiceLocator.Current.GetInstance<IEventAggregator>();
            ForgotPasswordCommand = new DelegateCommand(ChangeForgotPasswordVisibility);

            UsernameBarViewModel = new UsernameBarViewModel();
            //            UsernameBarViewModel.Username = LocalAppSettings.GetBySettings(LocalAppSettings.Settings.Username);
            //            UsernameBarViewModel.Description = LocalAppSettings.GetBySettings(LocalAppSettings.Settings.UserRole); 

            PasswordBarViewModel = new PasswordBarViewModel();
            ForgotPasswordViewModel = new ForgotPasswordViewModel();
            PasswordBarViewModel.LoginCommand = new DelegateCommand(Login);
            //ForgotPasswordViewModel.ResetPasswordCommand = new DelegateCommand(ResetPassword);

            Background = BackgroundColors.BackgroundDarkColor;
            ControlsBackground = BackgroundColors.BackgroundLightColor;
            ChangeUserFromFile();
            SetUsername();
            DownLoadDatabaseFromFtp();
            //            eventAgg.GetEvent<UpdateConnectionStatusEvent>().Subscribe(OnUpdateConnectionStatus);
            //            OnUpdateConnectionStatus(BusinessStructure.Instance.ConnectionStatus);
        }

        #region Properties

        private List<String> serverAddresses;
        public List<String> ServerAddresses
        {
            get { return serverAddresses; }
            set
            {
                if (serverAddresses == value)
                    return;
                serverAddresses = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the username bar view model.
        /// </summary>
        /// <value>
        /// The username bar view model.
        /// </value>
        public UsernameBarViewModel UsernameBarViewModel { get; set; }
        /// <summary>
        /// Gets or sets the password bar view model.
        /// </summary>
        /// <value>
        /// The password bar view model.
        /// </value>
        public PasswordBarViewModel PasswordBarViewModel { get; set; }
        /// <summary>
        /// Gets or sets the forgot password view model.
        /// </summary>
        /// <value>
        /// The forgot password view model.
        /// </value>
        public ForgotPasswordViewModel ForgotPasswordViewModel { get; set; }

        public Brush Background { get; set; }
        public Brush ControlsBackground { get; set; }

        public ICommand ForgotPasswordCommand { get; set; }

        private Visibility invalidPasswordMessageVisibility = Visibility.Collapsed;
        public Visibility InvalidPasswordMessageVisibility
        {
            get { return invalidPasswordMessageVisibility; }
            set
            {
                if (invalidPasswordMessageVisibility != value)
                {
                    invalidPasswordMessageVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility responseVisibility = Visibility.Collapsed;
        public Visibility ResponseVisibility
        {
            get { return responseVisibility; }
            set
            {
                if (responseVisibility != value)
                {
                    responseVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private string responseStatusTitle;
        public string ResponseStatusTitle
        {
            get { return responseStatusTitle; }
            set
            {
                if (responseStatusTitle != value)
                {
                    responseStatusTitle = value;
                    OnPropertyChanged();
                }
            }
        }

        private string responseStatusDetails;
        public string ResponseStatusDetails
        {
            get { return responseStatusDetails; }
            set
            {
                if (responseStatusDetails != value)
                {
                    responseStatusDetails = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The login visibility.
        /// </summary>
        private Visibility loginVisibility = Visibility.Visible;
        public Visibility LoginVisibility
        {
            get { return loginVisibility; }
            set
            {
                if (loginVisibility != value)
                {
                    loginVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private string imagePath;//=Common.Infrastructure.ImagePath.DentistProfile;
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if (value == imagePath)
                    return;
                imagePath = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The forgot password visibility.
        /// </summary>
        private Visibility forgotPasswordVisibility = Visibility.Collapsed;
        public Visibility ForgotPasswordVisibility
        {
            get { return forgotPasswordVisibility; }
            set
            {
                if (forgotPasswordVisibility != value)
                {
                    forgotPasswordVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Set to true if client succesfully connnected or false otherwise.
        /// </summary>
        private bool connectionSuccessful = true;
        public bool ConnectionSuccessful
        {
            get { return connectionSuccessful; }
            set
            {
                if (connectionSuccessful != value)
                {
                    connectionSuccessful = value;

                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Changes the forgot password visibility.
        /// In case it is visible it is set to Collapsed and vice versa
        /// </summary>
        private void ChangeForgotPasswordVisibility()
        {
            if (ForgotPasswordVisibility == Visibility.Collapsed)
            {
                LoginVisibility = Visibility.Collapsed;
                ForgotPasswordVisibility = Visibility.Visible;
            }
            else
            {
                LoginVisibility = Visibility.Visible;
                ForgotPasswordVisibility = Visibility.Collapsed;
            }
        }

        #endregion

        /// <summary>
        /// Sends to server the information provided by the user
        /// sets the properties ResponseStatusTitle and ResponseStatusDetails
        /// according to server's response
        /// </summary>
        public void Login()
        {
            Log.Info("Try to login with Username = " + UsernameBarViewModel.Username);
            try
            {
                string username = UsernameBarViewModel.Username;
                LoginResponse response =
                    DatabaseHandler.Instance.Login(UsernameBarViewModel.Username,
                        SecureStringToString(PasswordBarViewModel.Password));
                if (response.Status == LoginStatus.Unsuccessful)
                {
                    ResponseStatusTitle = "Logare fara success";
                    ResponseStatusDetails = "    Detalii: " + response.Description;
                    ResponseVisibility = Visibility.Visible;
                    InvalidPasswordMessageVisibility = Visibility.Visible;
                    Log.Info("The login was unsuccessful.");
                }
                else
                {
                    ResponseVisibility = Visibility.Collapsed;
                    InvalidPasswordMessageVisibility = Visibility.Collapsed;
                    UsernameBarViewModel.ChangeTextModeVisibility();
                    eventAgg.GetEvent<UserLoginEvent>().Publish(username);
                    LocalCache.Instance.LocalUser = new LocalUser()
                    {
                        Username = response.Username,
                        Id = response.UserId
                    };
                }
            }
            catch
            {
                ResponseStatusTitle = "Eroare";
                ResponseStatusDetails = "";
                ResponseVisibility = Visibility.Visible;
                Log.Warn("Invalid login credentials.");
            }

        }

        /// <summary>
        /// Converts a secure String into an ordinary string
        /// </summary>
        /// <param name="value">an object of type SecureString</param>
        /// <returns>a string</returns>
        private String SecureStringToString(SecureString value)
        {
            IntPtr bstr = Marshal.SecureStringToBSTR(value);
            try
            {
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }
        }

        #region Connection Status

        /// <summary>
        /// The server connection status
        /// </summary>
        private string serverConnectionStatus;
        public string ServerConnectionStatus
        {
            get { return serverConnectionStatus; }
            set
            {
                if (serverConnectionStatus != value)
                {
                    serverConnectionStatus = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The connection status visibility
        /// </summary>
        private Visibility connectionStatusVisibility = Visibility.Collapsed;
        public Visibility ConnectionStatusVisibility
        {
            get { return connectionStatusVisibility; }
            set
            {
                if (connectionStatusVisibility != value)
                {
                    connectionStatusVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The status foreground color
        /// </summary>
        public Brush statusForegroundColor;
        public Brush StatusForegroundColor
        {
            get { return statusForegroundColor; }
            set
            {
                if (statusForegroundColor != value)
                {
                    statusForegroundColor = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// updates properties <see cref="ConnectionStatusVisibility"/>,<see cref="ServerConnectionStatus"/>,
        ///                     <see cref="StatusForegroundColor"/>
        /// according to the input parameter
        /// </summary>
        /// <param name="isConnectionSuccessful">if set to <c>true</c> [is connection successful].</param>
        private void OnUpdateConnectionStatus()//ConnectionStatus connectionStatus)
        {
            //            if (connectionStatus.IsConnectionSuccesfull && connectionStatus.LoansUpdated)
            //            {
            //                ConnectionStatusVisibility = Visibility.Visible;
            //                ServerConnectionStatus = "Connection Successful. Please login to proceed.";
            //                StatusForegroundColor = BackgroundColors.SuccessfulColor;
            //            }
            //            else
            //            {
            //                if (connectionStatus.IsConnectionSuccesfull && !connectionStatus.LoansUpdated)
            //                {
            //                    ServerConnectionStatus = "Connection successful. Please wait for the TULIP client to fetch the available loans.";
            //                    StatusForegroundColor = BackgroundColors.SuccessfulColor;
            //                }
            //                else
            //                {
            //                    ServerConnectionStatus = "Connection Unsuccessful. Please reload the application or contact your system's administrator.";
            //                    StatusForegroundColor = BackgroundColors.UnsuccessfulColor;
            //                }
            //                 ConnectionStatusVisibility = Visibility.Visible;
            //                
            //            }
            //            ConnectionSuccessful = connectionStatus.IsConnectionSuccesfull && connectionStatus.LoansUpdated;
        }

        #endregion

        public void ChangeUserFromFile()
        {
            //Log.Info("Changing user from file.");
            //if (LocalAppSettings.GetByName(LocalAppSettings.Settings.Username) != null)
            //{
            //    UsernameBarViewModel.Username = LocalAppSettings.GetByName(LocalAppSettings.Settings.Username);
            //}
            //else
            //{
            //    UsernameBarViewModel.Username = null;
            //}
        }

        public void SetUsername()
        {
            var currentUser = XmlSerializerHelper.GetFromXml<LocalUser>(ViewConstants.appDataPath);
            if (currentUser != null)
            {
                UsernameBarViewModel.Username = currentUser.Username;
                ImagePath = !string.IsNullOrEmpty(currentUser.ImagePath) ? currentUser.ImagePath : DSA.Common.Infrastructure.ImagePath.DentistProfile;
            }
        }

        public void DownLoadDatabaseFromFtp()
        {
            FTPConnectionHandler.DownloadFile();
        }

    }
}
