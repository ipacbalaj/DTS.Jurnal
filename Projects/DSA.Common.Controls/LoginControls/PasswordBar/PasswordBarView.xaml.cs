using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace DSA.Common.Controls.LoginControls.PasswordBar
{
    /// <summary>
    /// Interaction logic for PasswordBarView.xaml
    /// </summary>
    public partial class PasswordBarView : UserControl
    {
        public PasswordBarView()
        {
            InitializeComponent();
//            passwordTextBox.Focus();
        }

        private void PasswordBoxPasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            ((PasswordBarViewModel) DataContext).Password = ((PasswordBox) sender).SecurePassword;
            //((PasswordBox)sender). = "";
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ((PasswordBarViewModel)DataContext).ChangeBackgroud();
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ((PasswordBarViewModel)DataContext).ChangeBackgroud();
        }

        private void PasswordBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ((PasswordBarViewModel)DataContext).LoginCommand.Execute(null);
                passwordTextBox.Clear();
            }
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            ((PasswordBarViewModel)DataContext).LoginCommand.Execute(null);
            passwordTextBox.Clear();
        }

        private void PasswordTextBox_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                Dispatcher.BeginInvoke(
                DispatcherPriority.ContextIdle,
                new Action(delegate()
                {
                    passwordTextBox.Focus();
                }));
            } 
        }
    }
}
