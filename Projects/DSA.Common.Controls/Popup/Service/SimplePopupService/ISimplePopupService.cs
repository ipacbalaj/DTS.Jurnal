using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectSuiteInstaller.Common.Controls.Popup.Service.SimplePopupService
{
    public interface ISimplePopupService
    {
        Task<bool> OpenPopupInfo(string popupTile, string text, string actionText);
        Task<bool> OpenPopupConfirmCancel(string popupTile, string text, string confirmActionText, string cancelActionText);
    }
}
