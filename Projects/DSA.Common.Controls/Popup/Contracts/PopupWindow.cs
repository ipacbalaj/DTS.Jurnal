using System.Windows;
using ConnectSuiteInstaller.Common.AppUtils;
using ConnectSuiteInstaller.Common.Infrastructure.MVVM;
using ConnectSuiteInstaller.Files.Images;

namespace ConnectSuiteInstaller.Common.Controls.Popup.Contracts
{
    public class PopupWindow : Window
    {
        private readonly IApplicationManager _applicationManager;

        public PopupWindow(BaseViewModel viewModel, IApplicationManager applicationManager, IImageService imageService)
        {
            DataContext = viewModel;
            _applicationManager = applicationManager;
            this.Loaded += PopupWindow_Loaded;
            Icon = imageService.GetImageSource("Logos/favicon.ico");
        }

        private void PopupWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CenterPopup();
        }

        private void CenterPopup()
        {
            Point leftTopRef = new Point(_applicationManager.MainWindow.Left, _applicationManager.MainWindow.Top);
            Point offset = new Point(
                (_applicationManager.MainWindow.Width - this.Width) / 2,
                (_applicationManager.MainWindow.Height - this.Height) / 2);

            this.Left = leftTopRef.X + offset.X;
            this.Top = leftTopRef.Y + offset.Y;
        }
    }
}
