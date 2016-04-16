using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.Common.Infrastructure.ViewModel;

namespace DSA.Common.Infrastructure.Entities
{
    public class InterventionModel:ViewModelBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                if (value == id)
                    return;
                id = value;
                OnPropertyChanged();
            }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == firstName)
                    return;
                firstName = value;
                OnPropertyChanged();
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == lastName)
                    return;
                lastName = value;
                OnPropertyChanged();
            }
        }

        private string patinetName;

        public string PatientName
        {
            get { return patinetName; }
            set
            {
                if (value == patinetName)
                    return;
                patinetName = value;
                OnPropertyChanged();
            }
        }


        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value == date)
                    return;
                date = value;
                OnPropertyChanged();
            }
        }

        private string work;

        public string Work
        {
            get { return work; }
            set
            {
                if (value == work)
                    return;
                work = value;
                OnPropertyChanged();
            }
        }


        private long duration;

        public long Duration
        {
            get { return duration; }
            set
            {
                if (value == duration)
                    return;
                duration = value;
                OnPropertyChanged();
            }
        }

        private DateTime start;

        public DateTime Start
        {
            get { return start; }
            set
            {
                if (value == start)
                    return;
                start = value;
                OnPropertyChanged();
            }
        }

        private DateTime end;

        public DateTime End
        {
            get { return end; }
            set
            {
                if (value == end)
                    return;
                end = value;
                OnPropertyChanged();
            }
        }

        private double revenue;

        public double Revenue
        {
            get { return revenue; }
            set
            {
                if (value == revenue)
                    return;
                revenue = value;
                OnPropertyChanged();
            }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set
            {
                if (value == location)
                    return;
                location = value;
                OnPropertyChanged();
            }
        }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value == isSelected)
                    return;
                isSelected = value;
                OnPropertyChanged();
            }
        }

    }
}
