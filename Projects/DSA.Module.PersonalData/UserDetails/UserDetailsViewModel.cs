using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.Common.Infrastructure.ViewModel;

namespace DSA.Module.PersonalData.UserDetails
{
    public class UserDetailsViewModel:ViewModelBase
    {
        #region Constructor

        #endregion Constructor

        #region Properties
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

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged();
                }
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                if (address != value)
                {
                    address = value;
                    OnPropertyChanged();
                }
            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                if (phone != value)
                {
                    phone = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion Properties

        #region Methods

        #endregion Methods

    }
}
