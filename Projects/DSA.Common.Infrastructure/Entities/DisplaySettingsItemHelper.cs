using DSA.Common.Infrastructure.ViewModel;

namespace DSA.Common.Infrastructure.Entities
{
    public class DisplaySettingsItemHelper:ViewModelBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string cost;
        public string Cost
        {
            get { return cost; }
            set
            {
                if (cost != value)
                {
                    cost = value;
                    OnPropertyChanged();
                }
            }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
