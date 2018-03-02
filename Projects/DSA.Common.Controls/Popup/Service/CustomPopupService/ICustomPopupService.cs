using System;
using System.Threading.Tasks;
using ConnectSuiteInstaller.Common.Controls.Popup.Contracts;
using ConnectSuiteInstaller.Common.Controls.Popup.Entities;

namespace ConnectSuiteInstaller.Common.Controls.Popup.Service.CustomPopupService
{
    public interface ICustomPopupService<T>
    {
        Task<PopupResult<T>> OpenPopupCustomContent(string popupTitle, PopupContentViewModel<T> viewModel, Type viewType);
    }
}
