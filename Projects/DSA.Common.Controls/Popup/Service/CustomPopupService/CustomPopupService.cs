using System;
using System.Threading.Tasks;
using ConnectSuiteInstaller.Common.AppUtils;
using ConnectSuiteInstaller.Common.Controls.Popup.Contracts;
using ConnectSuiteInstaller.Common.Controls.Popup.Entities;
using ConnectSuiteInstaller.Common.Controls.Popup.PopupTypes.CustomContentPopup;
using ConnectSuiteInstaller.Common.Resource;
using ConnectSuiteInstaller.Files.Images;

namespace ConnectSuiteInstaller.Common.Controls.Popup.Service.CustomPopupService
{
    public class CustomPopupService<T> : ICustomPopupService<T>
    {
        private readonly ITemplateResourceService _templateResouceService;
        private readonly IApplicationManager _applicationManager;
        private readonly IImageService _imageService;

        public CustomPopupService(ITemplateResourceService templateResouceService, IApplicationManager applicationManager, IImageService imageService)
        {
            _templateResouceService = templateResouceService;
            _applicationManager = applicationManager;
            _imageService = imageService;
        }

        public Task<PopupResult<T>> OpenPopupCustomContent(string popupTitle, PopupContentViewModel<T> viewModel, Type viewType)
        {
            var popup = new CustomContentPopupView(new CustomContentPopupViewModel(popupTitle, _templateResouceService, viewModel, viewType), _applicationManager, _imageService);
            var task = new TaskCompletionSource<PopupResult<T>>();
            popup.Closed += (s, a) => task.SetResult(viewModel.GetResult());
            popup.ShowDialog();
            popup.Focus();

            return task.Task;
        }
    }
}
