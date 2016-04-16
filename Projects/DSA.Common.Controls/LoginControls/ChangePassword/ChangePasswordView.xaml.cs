using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace DSA.Common.Controls.LoginControls.ChangePassword
{
    /// <summary>
    /// Interaction logic for ChangePasswordView.xaml
    /// </summary>
    public partial class ChangePasswordView : Window
    {
        public ChangePasswordView(string username)
        {
            InitializeComponent();
            var viewmodel = new ChangePasswordViewModel();
            viewmodel.Email = username;
            if (viewmodel.CloseAction == null)
                viewmodel.CloseAction = new Action(() => this.Close());
            DataContext = viewmodel;
                
        }
    }
}
