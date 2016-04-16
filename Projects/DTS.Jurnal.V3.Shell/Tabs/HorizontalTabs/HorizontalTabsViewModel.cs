using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientShell.Views.Tabs.HorizontalTab;
using DSA.Common.Infrastructure;
using DSA.Common.Infrastructure.Icos;
using DSA.Common.Infrastructure.ObjectList;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using TULIP.Common.Controls.Icons;
using TULIP.Common.Controls.Icons.TabsIcons;

namespace ClientShell.Views.Tabs.HorizontalTabs
{
    public class HorizontalTabsViewModel:ViewModelBase
    {
        #region Constructor

        public HorizontalTabsViewModel()
        {
            eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            PopulateTabs();
        }
        #endregion Constructor

        #region Properties
        private readonly IEventAggregator eventAggregator;

        private ObjectList<HorizontalTabViewModel> tabList = new ObjectList<HorizontalTabViewModel>(false);
        public ObjectList<HorizontalTabViewModel> TabList
        {
            get { return tabList; }
            set
            {
                if (tabList != value)
                {
                    tabList = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion Properties

        #region Methods

        public void PopulateTabs()
        {        
            TabList.Add(new HorizontalTabViewModel(BackgroundColors.JurnalColor) { Name = "Jurnal", ImagePath = ImagePath.PacientiIconPath, Command = new DelegateCommand(OnDetalPaper) });        
            TabList.Add(new HorizontalTabViewModel(BackgroundColors.JurnalColor) { Name = "Setări", ImagePath = ImagePath.SetariIconPath, Command = new DelegateCommand(OnSettingsCommand) });
            TabList.Add(new HorizontalTabViewModel(BackgroundColors.JurnalColor) { Name = "Pacienți", ImagePath = ImagePath.FisaPacientIconPath, Command = new DelegateCommand(OnPatientiCommand) });            
        }

        private void OnSettingsCommand()
        {
            eventAggregator.GetEvent<ShellStateChangeEvent>().Publish(ShellState.Settings);
        }


        private void OnPatientiCommand()
        {
            eventAggregator.GetEvent<ShellStateChangeEvent>().Publish(ShellState.Patient);
        }

        private void OnDetalPaper()
        {
            eventAggregator.GetEvent<ShellStateChangeEvent>().Publish(ShellState.Mainpage);
        }

        public void OnSelectTab(string tabToSelect)
        {
            var selectedTab = TabList.List.FirstOrDefault(item => item.Name == tabToSelect);
            selectedTab.OnSelected(selectedTab);
        }

        #endregion Methods

    }
}
