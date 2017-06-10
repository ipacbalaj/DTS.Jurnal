using System.ComponentModel;
using System.Windows;

namespace DTS.Jurnal.V3.Shell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
        }

        private async void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            ((MainWindowViewModel)DataContext).SaveDatabaseBackUp();
            //((MainWindowViewModel)DataContext).SaveDatabaseFileToFtp();
            MessageBox.Show("Baza de date a fost salvată.");
        }
    }
}
