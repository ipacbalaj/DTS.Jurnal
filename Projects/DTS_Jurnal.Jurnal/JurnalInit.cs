using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Prism.Regions;
using DSA.Common.Infrastructure.Prism.Regions.ViewsInterfaces;
using DTS_Jurnal.Jurnal.JurnalScreen;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace DTS_Jurnal.Jurnal
{
    public class JurnalInit : IModule
    {
            #region Constructor
        [InjectionConstructor]
        public JurnalInit(IUnityContainer unityContainer, IRegionManager regionManager)
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
            unityContainer.RegisterInstance(typeof(JurnalViewModel));
            unityContainer.RegisterType<IWorkAreaView, JurnalView>(ShellState.Mainpage.ToString());
            RegisterMeWithRegions.RegisterWithRegionAndState<IWorkAreaView>(MainScreenRegions.WorkRegion, ShellState.Mainpage);
        }
        #endregion Methods
    }
}
