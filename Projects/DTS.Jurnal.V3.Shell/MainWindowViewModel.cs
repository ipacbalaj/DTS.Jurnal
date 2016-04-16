using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClientShell.Views.Tabs.HorizontalTabs;
using DSA.Common.Controls.Buttons;
using DSA.Common.Controls.Loading.MetroLoading;
using DSA.Common.Controls.LoginControls.ChangePassword;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.ViewModel;
using DSA.Database.Model;
using DTS.Jurnal.V3.Database.Module;
using DTS.Jurnal.V3.Shell.Properties;
using DTS_Jurnal.Main.Bootstrapper;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace DTS.Jurnal.V3.Shell
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Constructor

        public MainWindowViewModel(IEventAggregator eventAggregator, IUnityContainer unityContainer, IRegionManager regionManager)
        {
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<UserNameChangedEvent>().Subscribe(UpdateUserName);
            RegionHandlers = new RegionHandlers(eventAggregator, unityContainer, regionManager);
            RegionHandlers.Parent = this;
            eventAggregator.GetEvent<UserLoginEvent>().Subscribe(OnUserLogin);
            HorizontalTabsViewModel = new HorizontalTabsViewModel();
            ImagePath = DSA.Common.Infrastructure.ImagePath.SigleIconPath;
            ChangeCredentialsButton = new ActionButtonViewModel("", new DelegateCommand(OnChangeCredentials), DSA.Common.Infrastructure.ImagePath.DentistProfile);
            LocalCache.Instance.NetworkPath = Settings.Default.NetworkPath;
        }

        #endregion Constructor

        #region Properties


        #region Visibility


        private readonly IEventAggregator eventAggregator;

        private Visibility isLoginVisible = Visibility.Visible;
        public Visibility IsLoginVisible
        {
            get { return isLoginVisible; }
            set
            {
                if (isLoginVisible != value)
                {
                    isLoginVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility isContentVisible = Visibility.Collapsed;
        public Visibility IsContentVisible
        {
            get { return isContentVisible; }
            set
            {
                if (isContentVisible != value)
                {
                    isContentVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion Visibility

        private RegionHandlers regionHandlers;
        public RegionHandlers RegionHandlers
        {
            get { return regionHandlers; }
            set
            {
                if (regionHandlers != value)
                {
                    regionHandlers = value;
                    OnPropertyChanged();
                }
            }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                if (value == userName)
                    return;
                userName = value;
                OnPropertyChanged();
            }
        }

        private ActionButtonViewModel changeCredentialsButton;

        public ActionButtonViewModel ChangeCredentialsButton
        {
            get { return changeCredentialsButton; }
            set
            {
                if (value == changeCredentialsButton)
                    return;
                changeCredentialsButton = value;
                OnPropertyChanged();
            }
        }

        private HorizontalTabsViewModel horizontalTabsViewModel;
        public HorizontalTabsViewModel HorizontalTabsViewModel
        {
            get { return horizontalTabsViewModel; }
            set
            {
                if (horizontalTabsViewModel != value)
                {
                    horizontalTabsViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        private string imagePath;

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

        #endregion Properties

        #region Methods

        private void OnUserLogin(string user)
        {
            IsLoginVisible = Visibility.Collapsed;
            IsContentVisible = Visibility.Visible;
            UserName = user;
            AnimateWhenLoading();
        }

        public async void AnimateWhenLoading()
        {
            TaskScheduler _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Action DoInBackground = new Action(() =>
            {

                LocalCache.Instance.Initialize();
                HorizontalTabsViewModel.OnSelectTab("Jurnal");
            });

            Action DoOnUiThread = new Action(() =>
            {
                //               MetroLoadingViewModel.ShouldContinueAnimation = false;
            });

            // start the background task
            var t1 = Task.Factory.StartNew(() => DoInBackground());
            // when t1 is done run t1..on the Ui thread.
            var t2 = t1.ContinueWith(t => DoOnUiThread(), _uiScheduler);
        }

        private void OnChangeCredentials()
        {
            ChangePasswordView changePasswordView = new ChangePasswordView(UserName);
            changePasswordView.ShowDialog();
        }

        private void UpdateUserName(string newUserName)
        {
            UserName = newUserName;
        }

        #endregion Methods
    }
}
