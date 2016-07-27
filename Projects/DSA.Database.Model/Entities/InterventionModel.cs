using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;
using DTS.Jurnal.V3.Database.Module;
using DTS.Jurnal.V3.Database.Module.Helpers;

namespace DSA.Common.Infrastructure.Entities
{
    public class InterventionModel : ViewModelBase
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

        private int patientId;
        public int PatientId
        {
            get { return patientId; }
            set
            {
                if (value == patientId)
                    return;
                patientId = value;
                OnPropertyChanged();
            }
        }

        private DateTime date = DateTime.Now;
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

        private int workId;
        public int WorkId
        {
            get { return workId; }
            set
            {
                if (value == workId)
                    return;
                workId = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan duration;

        public TimeSpan Duration
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

        private string durataString;

        public string DurataString
        {
            get { return Duration.Hours + ":" + Duration.Minutes; }
            set
            {
                if (value == durataString)
                    return;
                durataString = value;
                OnPropertyChanged();
            }
        }

        private DateTime start = DateTime.Now;

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

        private DateTime end = DateTime.Now;

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

        public bool revenueChanged = false;
        private double revenue;

        public double Revenue
        {
            get { return revenue; }
            set
            {
                if (value == revenue)
                    return;
                if (revenue != 0)
                {
                    revenueChanged = true;
                }
                revenue = value;
                OnPropertyChanged();
            }
        }

        private double materialCost;
        public double MaterialCost
        {
            get { return materialCost; }
            set
            {
                if (value == materialCost)
                    return;
                materialCost = value;
                OnPropertyChanged();
            }
        }

        private double percent;
        public double Percent
        {
            get { return percent; }
            set
            {
                if (value == percent)
                    return;
                percent = value;
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

        private int locationId;

        public int LocationId
        {
            get { return locationId; }
            set
            {
                if (value == locationId)
                    return;
                locationId = value;
                OnPropertyChanged();
            }
        }

        private string area;

        public string Area
        {
            get { return area; }
            set
            {
                if (value == area)
                    return;
                area = value;
                OnPropertyChanged();
            }
        }

        private int areaId;

        public int AreaId
        {
            get { return areaId; }
            set
            {
                if (value == areaId)
                    return;
                areaId = value;
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

        private Brush rowColorBrush;

        public Brush RowColorBrush
        {
            get { return rowColorBrush; }
            set
            {
                rowColorBrush = value;
                OnPropertyChanged();
            }
        }

        private double remainder;

        public double Remainder
        {
            get { return remainder; }
            set
            {
                //                if (value == remainder)
                //                    return;
                if (value == 0)
                {
                    WasPayed = true;
                }
                remainder = value;
                OnPropertyChanged();
            }
        }

        private bool wasPayed;
        public bool WasPayed
        {
            get { return wasPayed; }
            set
            {
                //                if (!LocalCache.Instance.InterventionLoaded || ShouldSetPayed)
                //                {
                wasPayed = value;
                if (wasPayed)
                {
                    RowColorBrush = null;
                }
                else
                {
                    RowColorBrush = BackgroundColors.GridNotPayedColor;
                }
                //                    ShouldSetPayed = false;
                //                }
                OnPropertyChanged();
            }
        }

        private bool shouldSetPayed;
        public bool ShouldSetPayed
        {
            get { return shouldSetPayed; }
            set
            {
                if (value == shouldSetPayed)
                    return;
                shouldSetPayed = value;
                OnPropertyChanged();
            }
        }

        private bool wasExported;
        public bool WasExported
        {
            get { return wasExported; }
            set
            {
                if (value == wasExported)
                    return;
                wasExported = value;
                OnPropertyChanged();
            }
        }

    }
}
