using ConnectSuiteInstaller.Common.Controls.Popup.Contracts;
using System.Threading.Tasks;
using ConnectSuiteInstaller.Common.AppUtils;
using ConnectSuiteInstaller.Common.Controls.Popup.PopupTypes.ConfirmCancelPopup;
using ConnectSuiteInstaller.Common.Controls.Popup.PopupTypes.InfoPopup;
using ConnectSuiteInstaller.Files.Images;

namespace ConnectSuiteInstaller.Common.Controls.Popup.Service.SimplePopupService
{
    public class SimplePopupService : ISimplePopupService
    {
        private readonly IApplicationManager _applicationManager;
        private readonly IImageService _imageService;

        public SimplePopupService(IApplicationManager applicationManager, IImageService imageService)
        {
            _applicationManager = applicationManager;
            _imageService = imageService;
        }

        public Task<bool> OpenPopupInfo(string popupTile, string text, string actionText)
        {
            var popupViewModel = new InfoPopupViewModel(popupTile,text, actionText);
            var popup = new InfoPopupView(popupViewModel, _applicationManager, _imageService);
            return GetPopupTask(popup, popupViewModel);
        }

        public Task<bool> OpenPopupConfirmCancel(string popupTile, string text, string confirmActionText, string cancelActionText)
        {
            var popupViewModel = new ConfirmCancelPopupViewModel(popupTile, text, confirmActionText, cancelActionText);
            var popup = new ConfirmCancelPopupView(popupViewModel, _applicationManager, _imageService);

            return GetPopupTask(popup, popupViewModel);
        }

        private Task<bool> GetPopupTask(PopupWindow popup, SimpleBasePopupViewModel popupContent)
        {
            var task = new TaskCompletionSource<bool>();
            popup.Closed += (s, a) => task.SetResult(popupContent.GetResult());
            popup.ShowDialog();
            popup.Focus();
            return task.Task;
        }
    }
}
