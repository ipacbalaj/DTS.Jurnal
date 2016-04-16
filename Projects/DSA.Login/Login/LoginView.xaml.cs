
using System;
using System.Windows;
using System.Windows.Threading;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Prism.Regions.ViewsInterfaces;
using System.Windows.Controls;
namespace DSA.Login.Login
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        public ShellState RegionToken { get; set; }

        
    }
}
