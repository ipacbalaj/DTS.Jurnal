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
    
    public partial class DateHourDetail
    {
        public DateHourDetail()
        {
            this.Interventions = new HashSet<Intervention>();
        }
    
        public int Id { get; set; }
        public System.DateTime StartHour { get; set; }
        public System.DateTime EndingHour { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<long> Duration { get; set; }
        public long MiliTime { get; set; }
    
        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}
