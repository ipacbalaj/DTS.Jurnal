using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Common.Infrastructure.ViewModel
{
    public class ViewModelBaseOld:INotifyPropertyChanged
    {

            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string propName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
        
    }
}
