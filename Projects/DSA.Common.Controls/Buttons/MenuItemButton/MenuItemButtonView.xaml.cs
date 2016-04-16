using System.Windows.Controls;
using System.Windows.Input;

namespace DSA.Common.Controls.Buttons.MenuItemButton
{
    /// <summary>
    /// Interaction logic for MenuItemButtonView.xaml
    /// </summary>
    public partial class MenuItemButtonView : UserControl
    {
        public MenuItemButtonView()
        {
            InitializeComponent();
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            ((MenuItemButtonViewModel)DataContext).MouseOn();
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            ((MenuItemButtonViewModel)DataContext).MouseOff();
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            ((MenuItemButtonViewModel)DataContext).OnSelected();
        }

    }
}
