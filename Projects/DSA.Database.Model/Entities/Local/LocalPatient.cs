using System;
using System.Collections.Generic;
using System.Windows.Media;
using DTS.Jurnal.Database.Model.Entities.Local;

namespace DSA.Database.Model.Entities.Local
{
   public class LocalPatient
    {
       public int Id { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string AllName { get; set; }
       public string Address { get; set; }
       public DateTime ?BirthDate { get; set; }
       public string City { get; set; }
       public string Country { get; set; }
       public string Street { get; set; }
       public string Block { get; set; }
       public string StreetNumber { get; set; }
       public string Job { get; set; }
       public string Ocupation { get; set; }
       public string Phone { get; set; }
       public string Email { get; set; }
       public Brush Brush { get; set; }
       public bool NewlyAdded { get; set; }
       public bool ?WasExported { get; set; }
       public List<LocalIntervention> Interventions = new List<LocalIntervention>();
    }
}
