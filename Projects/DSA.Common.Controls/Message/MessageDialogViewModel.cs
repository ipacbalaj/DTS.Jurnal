using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.Common.Infrastructure.ViewModel;

namespace DSA.Common.Controls.Message
{
    public class MessageDialogViewModel : ViewModelBase
    {
        public MessageDialogViewModel(string textToDisplay)
        {
            Text = textToDisplay;
        }

        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                if (value == text)
                    return;
                text = value;
                OnPropertyChanged();
            }
        }
    }
}
