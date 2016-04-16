using System;
using System.Collections.ObjectModel;
using DSA.Common.Infrastructure.ViewModel;

namespace DSA.Common.Infrastructure.ObjectList
{
    public class ObjectList<T> : ViewModelBase where T : IObjectListBase<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectList{T}"/> class.
        /// </summary>
        /// <param name="allowMultipleSelection">if set to <c>true</c> [allow multiple selection].</param>
        public ObjectList(Boolean allowMultipleSelection)
        {
            AllowMultipleSelection = allowMultipleSelection;
        }

        /// <summary>
        /// a list of objects of a specified type will be stored in this list
        /// it is an ObservableCollection so that any change in the list is notified
        /// </summary>
        private ObservableCollection<T> list = new ObservableCollection<T>();
        public ObservableCollection<T> List
        {
            get { return list; }
            set
            {
                list = value;
                OnPropertyChanged();
            }
        }

        public bool AllowMultipleSelection { get; set; }

        private T selectedItem;
        public T SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// contains the list of object of same type as in list property,
        /// this list only references the objects that are selected
        /// </summary>
        public ObservableCollection<T> selectedItems = new ObservableCollection<T>();
        public ObservableCollection<T> SelectedItems
        {
            get
            {
                return selectedItems;
            }
            set
            {
                selectedItems = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// when one object is selected it is added in  <see cref="selectedItems"/> 
        /// if it is deselected it is removed from above mentioned list
        /// </summary>
        /// <param name="selected">The selected.</param>
        public void OnSelectedObject(T selected)
        {
            if (AllowMultipleSelection)
            {
                if (SelectedItems.Contains(selected))
                {
                    Unselect(selected);
                    SelectedItems.Remove(selected);
                }
                else
                {
                    Select(selected);
                    SelectedItems.Add(selected);
                }
            }
            else
            {
                if (SelectedItem != null)
                {
                    Unselect(SelectedItem);
                }
                Select(selected);
                SelectedItem = selected;
            }
        }

        /// <summary>
        /// Selects the specified object.
        /// </summary>
        /// <param name="selected">The selected.</param>
        public void Select(T selected)
        {
            selected.OnClick(true);
        }

        /// <summary>
        /// Unselects the specified object.
        /// </summary>
        /// <param name="selected">The selected.</param>
        public void Unselect(T selected)
        {
            selected.OnClick(false);
        }

        /// <summary>
        /// Adds the specified element in the <see cref="List"/> 
        /// </summary>
        /// <param name="element">The element.</param>
        public void Add(T element)
        {
            element.ListOfElements = this;
            List.Add(element);

            OnPropertyChanged("List");
        }

        /// <summary>
        /// Clear the <see cref="List"/> 
        /// </summary>
        public void ClearList()
        {
            List = new ObservableCollection<T>();
            OnPropertyChanged("List");
        }

        /// <summary>
        /// Get the <see cref="List"/> count
        /// </summary>
        public int Count()
        {
            return List == null ? 0 : List.Count;
        }

    }
}
