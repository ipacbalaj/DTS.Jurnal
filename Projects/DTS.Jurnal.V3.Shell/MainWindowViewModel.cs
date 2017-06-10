using System;
using System.Threading.Tasks;
using System.Windows;
using ClientShell.Views.Tabs.HorizontalTabs;
using DSA.Common.Controls.Buttons;
using DSA.Common.Controls.LoginControls.ChangePassword;
using DSA.Common.Controls.Message;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.ViewModel;
using DTS.Jurnal.Database.SQLServer.Module;
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
            DownLoadDatabaseFromFtp();
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

        private Visibility saveProcessingVisibility = Visibility.Collapsed;
        public Visibility SaveProcessingVisibility
        {
            get { return saveProcessingVisibility; }
            set
            {
                if (value == saveProcessingVisibility)
                    return;
                saveProcessingVisibility = value;
                OnPropertyChanged();
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

        public async void SaveDatabaseFileToFtp()
        {
            MessageDialog dialog = new MessageDialog("Baza de date se salveaza pe serverul FTP. Vă rugam astepati.");
            dialog.Show();
            CopyFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\DTS", Settings.Default.Databasepath);

            dialog.Close();
        }

        public void DownLoadDatabaseFromFtp()
        {
            //CopyFile(Settings.Default.Databasepath, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\DTS");
        }

        private void CopyFile(string sourcePath, string targetPath)
        {
            string fileName = "dsa.sdf";
            //string sourcePath = Settings.Default.Databasepath;
            //string targetPath = Environment.SpecialFolder.ApplicationData.ToString();

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);

            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                MessageBox.Show("Eroare la copierea bazei de date");
            }
        }

        public void SaveDatabaseBackUp()
        {
            string fileName = DateTime.Now.ToShortDateString() + DateTime.Now.Ticks + ".sdf";
            string sourcePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DTS\";
            string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DTS\BackUp";

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, "dsa.sdf");
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);
        }

        #endregion Methods

    }
}
