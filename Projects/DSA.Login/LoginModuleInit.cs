using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Prism.Regions;
using DSA.Common.Infrastructure.Prism.Regions.ViewsInterfaces;
using DSA.Login.Login;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace DSA.Login
{
    public class LoginModuleInit : IModule
    {
        private readonly IUnityContainer unityContainer;
        private readonly IRegionManager regionManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginModuleInit"/> class.
        ///  The instance is created by unity container
        /// </summary>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="regionManager">The region manager.</param>
        [InjectionConstructor]
        public LoginModuleInit(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.unityContainer = unityContainer;
        }

        /// <summary>
        /// Registers the module <see cref="LoginViewModel"/> in the unityContainer
        /// Registers the view <see cref="ILoginView"/> in its specific region
        /// </summary>
        public void Initialize()
        {
            if (unityContainer == null) return;

            unityContainer.RegisterInstance(typeof (LoginViewModel));
            unityContainer.RegisterType<ILoginView, LoginView>(ShellState.Login.ToString());
            RegisterMeWithRegions.RegisterWithRegionAndState<ILoginView>(MainScreenRegions.LoginRegion, ShellState.Login);      
        } 
    }
}
