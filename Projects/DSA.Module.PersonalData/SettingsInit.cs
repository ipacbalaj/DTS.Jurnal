
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Prism.Regions;
using DSA.Common.Infrastructure.Prism.Regions.ViewsInterfaces;
using DSA.Module.PersonalData.SettingsDataScreen;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace DSA.Module.PersonalData
{
    public class SettingsInit:IModule
    {
          #region Constructor
        [InjectionConstructor]
        public SettingsInit(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.unityContainer = unityContainer;
        }
        #endregion Constructor

        #region Properties

        private readonly IUnityContainer unityContainer;
        private readonly IRegionManager regionManager;

        #endregion Properties

        #region Methods
        public void Initialize()
        {
            if (unityContainer == null) return;
            unityContainer.RegisterInstance(typeof(SettingsScreenViewModel));
            unityContainer.RegisterType<IWorkAreaView, SettingsScreenView>(ShellState.Settings.ToString());
            RegisterMeWithRegions.RegisterWithRegionAndState<IWorkAreaView>(MainScreenRegions.WorkRegion, ShellState.Settings);
        }
        #endregion Methods
    }
}
