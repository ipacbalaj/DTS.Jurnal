using System;

namespace DSA.Common.Infrastructure.ObjectList
{
    public interface IObjectListBase<T> where T : IObjectListBase<T>
    {
        ObjectList<T> ListOfElements { get; set; }
        Boolean IsSelected { get; set; }
        void OnSelected(T selected);
        void OnClick(bool shouldSelect);
    }
}
