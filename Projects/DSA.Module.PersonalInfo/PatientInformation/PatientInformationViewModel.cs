using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DSA.Common.Controls.Buttons.OptionButton;
using DSA.Common.Infrastructure.Icos;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;
using DSA.Module.PersonalInfo.PersonalInfoScreen;
using Microsoft.Practices.Prism.Commands;

namespace DSA.Module.PersonalInfo.PatientInformation
{
   public  class PatientInformationViewModel:ViewModelBase
   {
       #region Constructor

       public PatientInformationViewModel(PersonalInfoScreenViewModel parent)
       {
           Parent = parent;
       }

       #endregion Constructor

       #region Properties

       public PersonalInfoScreenViewModel Parent { get; set; }

       private string name;
       public string Name
       {
           get { return name; }
           set
           {
               if (value == name)
                   return;
               name = value;
               OnPropertyChanged();
           }
       }

       private Brush datePersonaleColor = BackgroundColors.DatePersonaleColor;

       public Brush DatePersonaleColor
       {
           get { return datePersonaleColor; }
           set
           {
               if (value == datePersonaleColor)
                   return;
               datePersonaleColor = value;
               OnPropertyChanged();
           }
       }

       private string surname;
       public string Surname
       {
           get { return surname; }
           set
           {
               if (value == surname)
                   return;
               surname = value;
               OnPropertyChanged();
           }
       }

       private string etnie="romana";

       public string Etnie
       {
           get { return etnie; }
           set
           {
               if (value == etnie)
                   return;
               etnie = value;
               OnPropertyChanged();
           }
       }

       private DateTime birthDate=DateTime.Now;
       public DateTime BirthDate
       {
           get { return birthDate; }
           set
           {
               if (value == birthDate)
                   return;
               birthDate = value;
               OnPropertyChanged();
           }
       }

       private string city;

       public string City
       {
           get { return city; }
           set
           {
               if (value == city)
                   return;
               city = value;
               OnPropertyChanged();
           }
       }

       private string street;

       public string Street
       {
           get { return street; }
           set
           {
               if (value == street)
                   return;
               street = value;
               OnPropertyChanged();
           }
       }

       private string number;

       public string Number
       {
           get { return number; }
           set
           {
               if (value == number)
                   return;
               number = value;
               OnPropertyChanged();
           }
       }

       private string scara;

       public string Scara
       {
           get { return scara; }
           set
           {
               if (value == scara)
                   return;
               scara = value;
               OnPropertyChanged();
           }
       }

       private string bloc;

       public string Bloc
       {
           get { return bloc; }
           set
           {
               if (value == bloc)
                   return;
               bloc = value;
               OnPropertyChanged();
           }
       }

       private string country="Romania";
       public string Country
       {
           get { return country; }
           set
           {
               if (value == country)
                   return;
               country = value;
               OnPropertyChanged();
           }
       }

       private string phone;

       public string Phone
       {
           get { return phone; }
           set
           {
               if (value == phone)
                   return;
               phone = value;
               OnPropertyChanged();
           }
       }

       private string email;
       public string Email
       {
           get { return email; }
           set
           {
               if (value == email)
                   return;
               email = value;
               OnPropertyChanged();
           }
       }

       private string job;

       public string Job
       {
           get { return job; }
           set
           {
               if (value == job)
                   return;
               job = value;
               OnPropertyChanged();
           }
       }

       private string ocupation;

       public string Ocupation
       {
           get { return ocupation; }
           set
           {
               if (value == ocupation)
                   return;
               ocupation = value;
               OnPropertyChanged();
           }
       }


       #endregion Properties

       #region Methods
       #endregion Methods
   }
}
