using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallerUI
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(BootstrapperApplication bootstrapper)
        {

            this.IsThinking = false;

            this.Bootstrapper = bootstrapper;
            this.Bootstrapper.ApplyComplete += this.OnApplyComplete;
            this.Bootstrapper.DetectPackageComplete += this.OnDetectPackageComplete;
            this.Bootstrapper.PlanComplete += this.OnPlanComplete;
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



        #endregion Properties

        #region Methods

        /// <summary>
        /// Method that gets invoked when the Bootstrapper ApplyComplete event is fired.
        /// This is called after a bundle installation has completed. Make sure we updated the view.
        /// </summary>
        private void OnApplyComplete(object sender, ApplyCompleteEventArgs e)
        {
            IsThinking = false;
            InstallEnabled = false;
            UninstallEnabled = false;
        }
        /// <summary>
        /// Method that gets invoked when the Bootstrapper DetectPackageComplete event is fired.
        /// Checks the PackageId and sets the installation scenario. The PackageId is the ID
        /// specified in one of the package elements (msipackage, exepackage, msppackage,
        /// msupackage) in the WiX bundle.
        /// </summary>
        private void OnDetectPackageComplete(object sender, DetectPackageCompleteEventArgs e)
        {
            if (e.PackageId == "DummyInstallationPackageId")
            {
                if (e.State == PackageState.Absent)
                    InstallEnabled = true;
                else if (e.State == PackageState.Present)
                    UninstallEnabled = true;
            }
        }
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
        #endregion //Methods
    }
}
