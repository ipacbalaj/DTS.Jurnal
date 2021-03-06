//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTS.Jurnal.Database.SQLServer.Module
{
    using System;
    using System.Collections.Generic;
    
    public partial class Work
    {
        public Work()
        {
            this.Interventions = new HashSet<Intervention>();
            this.WorkTypes = new HashSet<WorkType>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public Nullable<double> Percent { get; set; }
        public Nullable<bool> IncludedINFinancial { get; set; }
        public Nullable<bool> WasDeleted { get; set; }
    
        public virtual ICollection<Intervention> Interventions { get; set; }
        public virtual ICollection<WorkType> WorkTypes { get; set; }
    }
}
