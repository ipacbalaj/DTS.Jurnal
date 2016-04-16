using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Prism.Regions;
using DSA.Common.Infrastructure.Prism.Regions.ViewsInterfaces;
using DTS.Jurnal.V3.Shell;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace DTS_Jurnal.Main.Bootstrapper
{
    public class RegionHandlers
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IUnityContainer unityContainer;
        private readonly IRegionManager regionManager;
        public MainWindowViewModel Parent { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegionHandlers"/> class.
        /// subscribe an event handler for an event of type ShellStateChangeEvent 
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="regionManager">The region manager.</param>
        public RegionHandlers(IEventAggregator eventAggregator, IUnityContainer unityContainer, IRegionManager regionManager)
        {
            this.eventAggregator = eventAggregator;
            this.unityContainer = unityContainer;
            this.regionManager = regionManager;
            this.eventAggregator.GetEvent<ShellStateChangeEvent>().Subscribe(OnShellStateChanged, ThreadOption.UIThread, true);
        }

        /// <summary>
        /// Shows the view within the region and for the specified state.
        /// </summary>
        /// <typeparam name="T">The view to activate</typeparam>
        /// <param name="region">The region.</param>
        /// <param name="state">The state.</param>
        private void ShowView<T>(string region, ShellState state) where T : IStatefulView
        {
            var view = regionManager.Regions[region].Views.Where(aView => aView is T).FirstOrDefault(bView => ((T)bView).RegionToken == state);

            if (view != null)
            {
                regionManager.Regions[region].Activate(view);
            }
        }

        /// <summary>
        /// Called when [shell state changed].
        /// dependind on <see cref="ShellState" /> a specific module is visible
        /// </summary>
        /// <param name="shellState">State of the shell.</param>
        private void OnShellStateChanged(ShellState shellState)
        {
            switch (shellState)
            {
                case ShellState.Mainpage:
                    eventAggregator.GetEvent<UpdateDentalRecordsEvent>().Publish(null);
                    ShowView<IWorkAreaView>(MainScreenRegions.WorkRegion, shellState);
                    break;
                case ShellState.Settings:
                    eventAggregator.GetEvent<UpdateSettingsEvent>().Publish(null);
                    ShowView<IWorkAreaView>(MainScreenRegions.WorkRegion, shellState);
                    break;
                case ShellState.Patient:
                    eventAggregator.GetEvent<UpdatePersonalInfoEvent>().Publish(null);
                    ShowView<IWorkAreaView>(MainScreenRegions.WorkRegion, shellState);
                    break;
                case ShellState.Login:
                    break;
            }
        }
    }
}
