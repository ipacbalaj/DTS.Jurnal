using System.Windows.Controls;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Prism.Regions.ViewsInterfaces;

namespace DSA.Module.PersonalData.SettingsDataScreen
{
    /// <summary>
    /// Interaction logic for SettingsScreenView.xaml
    /// </summary>
    public partial class SettingsScreenView : UserControl, IWorkAreaView
    {
        public SettingsScreenView()
        {
            InitializeComponent();
            DataContext = new SettingsScreenViewModel();
        }
        public ShellState RegionToken { get; set; }
    }
}
