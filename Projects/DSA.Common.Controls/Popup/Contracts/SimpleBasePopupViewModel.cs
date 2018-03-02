using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ConnectSuiteInstaller.Common.Infrastructure.MVVM;

namespace ConnectSuiteInstaller.Common.Controls.Popup.Contracts
{
    public abstract class SimpleBasePopupViewModel : BaseViewModel
    {
        public bool ActionStatus { get; set; }
        public abstract bool GetResult();
    }
}
