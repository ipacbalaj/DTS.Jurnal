using ConnectSuiteInstaller.Common.Controls.Popup.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ConnectSuiteInstaller.Common.Infrastructure.MVVM;

namespace ConnectSuiteInstaller.Common.Controls.Popup.Contracts
{
    public abstract class PopupContentViewModel<Result> : BaseChildViewModel
    {
        public PopupContentViewModel(BaseViewModel parent) : base(parent)
        {
        }
        /// <summary>
        /// This is set to true if the user clicked on the conf
        /// </summary>
        public bool ActionStatus { get; set; }
        public abstract PopupResult<Result> GetResult();

    }
}
