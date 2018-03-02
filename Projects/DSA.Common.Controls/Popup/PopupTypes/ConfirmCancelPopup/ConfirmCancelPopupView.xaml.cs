using System;
using ConnectSuiteInstaller.Common.AppUtils;
using ConnectSuiteInstaller.Common.Controls.Popup.Contracts;
using ConnectSuiteInstaller.Common.Infrastructure.MVVM;
using ConnectSuiteInstaller.Files.Images;

namespace ConnectSuiteInstaller.Common.Controls.Popup.PopupTypes.ConfirmCancelPopup
{
    /// <summary>
    /// Interaction logic for ConfirmCancelPopupView.xaml
    /// </summary>
    public partial class ConfirmCancelPopupView : PopupWindow
    {
        public ConfirmCancelPopupView(BaseViewModel viewModel, IApplicationManager applicationManager, IImageService imageService) : base(viewModel, applicationManager, imageService)
        {
            InitializeComponent();
            viewModel.CloseAction += new Action(() => this.Close());
        }
    }
}
