using System;
using ConnectSuiteInstaller.Common.AppUtils;
using ConnectSuiteInstaller.Common.Controls.Popup.Contracts;
using ConnectSuiteInstaller.Files.Images;

namespace ConnectSuiteInstaller.Common.Controls.Popup.PopupTypes.InfoPopup
{
    /// <summary>
    /// Interaction logic for InfoPopupView.xaml
    /// </summary>
    public partial class InfoPopupView : PopupWindow
    {
        public InfoPopupView(InfoPopupViewModel viewModel, IApplicationManager applicationManager, IImageService imageService) : base(viewModel, applicationManager, imageService)
        {
            InitializeComponent();
            viewModel.CloseAction += new Action(() => this.Close());
        }

    }
}
