using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DSA.Module.PersonalData.SettingsColumns.SettingsTileList
{
    /// <summary>
    /// Interaction logic for SettingsTileListView.xaml
    /// </summary>
    public partial class SettingsTileListView : UserControl
    {
        public SettingsTileListView()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            ((SettingsTileListViewModel)DataContext).ViewReference = this;
        }
    }
}
