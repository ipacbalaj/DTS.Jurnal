using System.Windows.Controls;
using System.Windows.Input;
namespace DSA.Common.Controls.Buttons.ListItemButton
{
    /// <summary>
    /// Interaction logic for ListItemButtonView.xaml
    /// </summary>
    public partial class ListItemButtonView : UserControl
    {
        public ListItemButtonView()
        {
            InitializeComponent();
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            ((ListItemButtonViewModel)DataContext).MouseOn();
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            ((ListItemButtonViewModel)DataContext).MouseOff();
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            ((ListItemButtonViewModel)DataContext).OnSelected();
        }

    }
}
