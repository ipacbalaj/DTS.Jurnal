using DevExpress.XtraBars.Docking2010.Base;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Prism.Regions.ViewsInterfaces;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace DSA.Common.Infrastructure.Prism.Regions
{
    /// <summary>
    /// Register views with regions
    /// </summary>
    public static class RegisterMeWithRegions
    {
        private static IRegionManager regionManager;
        private static IUnityContainer unityContainer;

        /// <summary>
        /// Initializes the <see cref="RegisterMeWithRegions"/> class.
        /// </summary>
        static RegisterMeWithRegions()
        {
            unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
        }

        /// <summary>
        /// Registers a view with a region and a shell state
        /// </summary>
        /// <typeparam name="T">The view that will be registered</typeparam>
        /// <param name="mainScreenRegion">The main screen region.</param>
        /// <param name="regionToken">The region token.</param>
        public static void RegisterWithRegionAndState<T>(string mainScreenRegion, ShellState regionToken) where T : IStatefulView
        {
            regionManager.RegisterViewWithRegion(mainScreenRegion,
                                                 () =>
                                                 {
                                                     var a = unityContainer.Resolve<T>(regionToken.ToString());
                                                     a.RegionToken = regionToken;
                                                     return a;
                                                 });
        }
    }
}
