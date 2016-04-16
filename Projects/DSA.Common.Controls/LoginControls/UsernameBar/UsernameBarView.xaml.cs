using System.Windows.Controls;
using System.Windows.Input;

namespace DSA.Common.Controls.LoginControls.UsernameBar
{
    /// <summary>
    /// Interaction logic for UsernameBarView.xaml
    /// </summary>
    public partial class UsernameBarView : UserControl
    {
        public UsernameBarView()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ((UsernameBarViewModel)DataContext).ChangeBackgroud();
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ((UsernameBarViewModel)DataContext).ChangeBackgroud();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            ((UsernameBarViewModel)DataContext).ChangeButtonVisibility();
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            ((UsernameBarViewModel)DataContext).ChangeButtonVisibility();
        }
    }
}
