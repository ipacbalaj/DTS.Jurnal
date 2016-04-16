using System.Windows.Controls;
using System.Windows.Input;

namespace ClientShell.Views.Tabs.HorizontalTab
{
    /// <summary>
    /// Interaction logic for HorizontalTabView.xaml
    /// </summary>
    public partial class HorizontalTabView : UserControl
    {
        public HorizontalTabView()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HorizontalTabViewModel verticalTabViewModel = (HorizontalTabViewModel)DataContext;
            verticalTabViewModel.OnSelected(verticalTabViewModel);
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            ((HorizontalTabViewModel)DataContext).MouseOn();
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            ((HorizontalTabViewModel)DataContext).MouseOff();
        }
    }
}
