using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectSuiteInstaller.Common.Controls.Popup.Entities
{
    public class PopupResult<T>
    {
        /// <summary>
        /// This is set to true if the user clicked on the confirm button
        /// false otherwise
        /// </summary>
        public bool Status { get; set; }
        public T Result { get; set; }
    }
}
