using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Prism.Regions;
using DSA.Common.Infrastructure.Prism.Regions.ViewsInterfaces;
using DSA.Module.PersonalInfo.PersonalInfoScreen;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace DSA.Module.PersonalInfo
{
   public class PersonalInfoInit:IModule
    {
        #region Constructor
        [InjectionConstructor]
        public PersonalInfoInit(IUnityContainer unityContainer, IRegionManager regionManager)
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
            unityContainer.RegisterInstance(typeof(PersonalInfoScreenViewModel));
            unityContainer.RegisterType<IWorkAreaView, PersonalInfoScreenView>(ShellState.Patient.ToString());
            RegisterMeWithRegions.RegisterWithRegionAndState<IWorkAreaView>(MainScreenRegions.WorkRegion, ShellState.Patient);
        }
        #endregion Methods
    }


}
