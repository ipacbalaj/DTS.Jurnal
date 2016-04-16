using System.Windows;
using DSA.Login;
using DSA.Module.PersonalData;
using DSA.Module.PersonalInfo;
using DTS_Jurnal.Jurnal;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;

namespace DTS.Jurnal.V3.Shell.Bootstrapper
{
    public class DSAClientBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Add the modules that we use in the Catalog in order to be accesed when needed.
        /// Configures the <see cref="T:Microsoft.Practices.Prism.Modularity.IModuleCatalog" /> used by Prism.
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            //Login module
            var myLogin = typeof(LoginModuleInit);
            ModuleCatalog.AddModule(new ModuleInfo(myLogin.Name, myLogin.AssemblyQualifiedName));
            var myJurnal = typeof(JurnalInit);
            ModuleCatalog.AddModule(new ModuleInfo(myJurnal.Name, myJurnal.AssemblyQualifiedName));
            var mySettings = typeof(SettingsInit);
            ModuleCatalog.AddModule(new ModuleInfo(mySettings.Name, mySettings.AssemblyQualifiedName));
            var myPatients = typeof(PersonalInfoInit);
            ModuleCatalog.AddModule(new ModuleInfo(myPatients.Name, myPatients.AssemblyQualifiedName));
        }
    }
}
