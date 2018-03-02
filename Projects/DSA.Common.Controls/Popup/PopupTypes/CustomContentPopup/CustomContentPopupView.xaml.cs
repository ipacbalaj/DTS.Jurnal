using System;
using ConnectSuiteInstaller.Common.AppUtils;
using ConnectSuiteInstaller.Common.Controls.Popup.Contracts;
using ConnectSuiteInstaller.Files.Images;

namespace ConnectSuiteInstaller.Common.Controls.Popup.PopupTypes.CustomContentPopup
{
    /// <summary>
    /// Interaction logic for CustomContentPopupView.xaml
    /// </summary>
    public partial class CustomContentPopupView : PopupWindow
    {
        public CustomContentPopupView(CustomContentPopupViewModel viewModel, IApplicationManager applicationManager, IImageService imageService) : base(viewModel, applicationManager, imageService)
        {
            InitializeComponent();
            viewModel.ContentViewModel.CloseAction += new Action(() => this.Close());
        }
    }
}
