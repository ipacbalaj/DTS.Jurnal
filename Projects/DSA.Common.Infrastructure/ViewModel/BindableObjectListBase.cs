using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using DSA.Common.Infrastructure.ObjectList;

namespace DSA.Common.Infrastructure.ViewModel
{
    /// <summary>
    /// This class is used to refresh user interface when a property has been changed.
    /// </summary>
    public abstract class BindableObjectListBase<T> : INotifyPropertyChanged, IObjectListBase<T> where T : IObjectListBase<T>
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public ObjectList<T> ListOfElements { get; set; }
        public bool IsSelected { get; set; }
        public void OnSelected(T selected)
        {
            ListOfElements.OnSelectedObject(selected);
        }

        public abstract void OnClick(bool shouldSelect);

        private Visibility elementVisibility = Visibility.Collapsed;
        public Visibility ElementVisibility
        {
            get { return elementVisibility; }
            set
            {
                if (elementVisibility != value)
                {
                    elementVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
