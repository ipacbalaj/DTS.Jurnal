using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InstallerUI
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(BootstrapperApplication bootstrapper)
        {
            this.Bootstrapper = bootstrapper;

            //detect
            this.Bootstrapper.DetectPackageComplete += this.OnDetectPackageComplete;
            this.Bootstrapper.DetectBegin += this.OnDetectBegin;
            this.Bootstrapper.DetectComplete += this.OnDetectComplete;
            //plan
            this.Bootstrapper.PlanPackageBegin += SetPackagePlannedState;
            this.Bootstrapper.PlanMsiFeature += SetFeaturePlannedState;
            this.Bootstrapper.PlanComplete += this.OnPlanComplete;
            //apply
            this.Bootstrapper.ExecutePackageBegin += EventProviderOnExecutePackageBegin;
            this.Bootstrapper.ExecutePackageComplete += EventProviderOnExecutePackageComplete;
            this.Bootstrapper.ApplyComplete += this.OnApplyComplete;

        }

        #region Properties

        public BootstrapperApplication Bootstrapper { get; private set; }

        private bool isThinking;
        public bool IsThinking
        {
            get { return isThinking; }
            set
            {
                if (isThinking == value)
                    return;
                isThinking = value;
                OnPropertyChanged();
            }
        }

        private bool installEnabled;
        public bool InstallEnabled
        {
            get { return installEnabled; }
            set
            {
                if (installEnabled == value)
                    return;
                installEnabled = value;
                OnPropertyChanged();
            }
        }

        private bool uninstallEnabled;
        public bool UninstallEnabled
        {
            get { return uninstallEnabled; }
            set
            {
                if (uninstallEnabled == value)
                    return;
                uninstallEnabled = value;
                OnPropertyChanged();
            }
        }

        private InstallAction CurrentAction = InstallAction.Install;

        #endregion Properties

        //https://www.wrightfully.com/part-4-of-writing-your-own-net-based-installer-with-wix-handling-current-and-future-state

        private ApplicationName AppToInstall = ApplicationName.InstallDemo1;

        #region InstallEventCallbacks

        #region Detect 

        /// <summary>
        /// Method that gets invoked when the Bootstrapper DetectPackageComplete event is fired.
        /// Checks the PackageId and sets the installation scenario. The PackageId is the ID
        /// specified in one of the package elements (msipackage, exepackage, msppackage,
        /// msupackage) in the WiX bundle.
        /// </summary>
        private void OnDetectPackageComplete(object sender, DetectPackageCompleteEventArgs e)
        {

        }

        private void OnDetectBegin(object sender, DetectBeginEventArgs e)
        {
        }

        private void OnDetectComplete(object sender, DetectCompleteEventArgs e)
        {
        }

        #endregion Detect

        #region Plan

        /// <summary>
        /// Method that gets invoked when the Bootstrapper PlanComplete event is fired.
        /// If the planning was successful, it instructs the Bootstrapper Engine to
        /// install the packages.
        /// </summary>
        private void OnPlanComplete(object sender, PlanCompleteEventArgs e)
        {
            if (e.Status >= 0)
                Bootstrapper.Engine.Apply(System.IntPtr.Zero);
        }

        private void SetFeaturePlannedState(object sender, PlanMsiFeatureEventArgs e)
        {

        }

        private void SetPackagePlannedState(object sender, PlanPackageBeginEventArgs e)
        {
            //var packageId = e.PackageId;
            
            //if (packageId != AppToInstall.ToString())
            //{
            //    e.State = RequestState.None;
            //}
            //switch (CurrentAction)
            //{
            //    case InstallAction.Install:
            //        if (packageId != AppToInstall.ToString())
            //        {
            //            e.State = RequestState.None;
            //        }
            //        break;
            //    case InstallAction.Uninstall:
            //        e.State = RequestState.None;
            //        break;
            //}
        }

        #endregion Plan

        #region Apply

        /// <summary>
        /// Method that gets invoked when the Bootstrapper ApplyComplete event is fired.
        /// This is called after a bundle installation has completed. Make sure we updated the view.
        /// </summary>
        private void OnApplyComplete(object sender, ApplyCompleteEventArgs e)
        {

        }

        private void EventProviderOnExecutePackageComplete(object sender, ExecutePackageCompleteEventArgs e)
        {
            var packId = e.PackageId;
        }

        private void EventProviderOnExecutePackageBegin(object sender, ExecutePackageBeginEventArgs e)
        {
            var packId = e.PackageId;
        }

        #endregion Apply

        #endregion InstallEventCallbacks

        #region Commands

        private ICommand installCommand;
        public ICommand InstallCommand
        {
            get
            {
                return installCommand ?? (installCommand = new BaseCommand(() => OnInstall(), true));
            }
        }

        private void OnInstall()
        {
            Bootstrapper.Engine.Plan(LaunchAction.Install);
        }
        private ICommand uninstallCommand;

        public ICommand UninstallCommand
        {
            get
            {
                return uninstallCommand ?? (uninstallCommand = new BaseCommand(() => OnUninstall(), true));
            }
        }
        private void OnUninstall()
        {
            CurrentAction = InstallAction.Uninstall;
            //trigger anothe chain process            
            //this.Bootstrapper.Engine.Detect();
            Bootstrapper.Engine.Plan(LaunchAction.Uninstall);
            //Bootstrapper.Engine.Apply(System.IntPtr.Zero);
        }

        private ICommand nextCommand;
        public ICommand NextCommand
        {
            get
            {
                return nextCommand ?? (nextCommand = new BaseCommand(() => OnNext(), true));
            }
        }

        private void OnNext()
        {
            AppToInstall = ApplicationName.InstallDemo2;

            //trigger anothe chain process            
            this.Bootstrapper.Engine.Detect();
            //this.Bootstrapper.Engine.Plan(LaunchAction.Install);
        }

        private ICommand exitCommand;
        public ICommand ExitCommand
        {
            get
            {
                return exitCommand ?? (exitCommand = new BaseCommand(() => OnExit(), true));
            }
        }

        private void OnExit()
        {

        }

        #endregion Commands
    }

    public enum ApplicationName { InstallDemo1, InstallDemo2 }
    public enum InstallAction { Install, Uninstall }
}
