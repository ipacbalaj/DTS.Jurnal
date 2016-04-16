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

namespace DSA.Module.PersonalData.SettingsColumns.SettingsTile
{
    /// <summary>
    /// Interaction logic for SettingsTileView.xaml
    /// </summary>
    public partial class SettingsTileView : UserControl
    {
        public SettingsTileView()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (!DataContext.ToString().Equals("{DisconnectedItem}"))
            {
                ((SettingsTileViewModel)DataContext).MouseOn();
            }

        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (!DataContext.ToString().Equals("{DisconnectedItem}"))
            {
                ((SettingsTileViewModel)DataContext).MouserOff();
            }

        }
    }
}
