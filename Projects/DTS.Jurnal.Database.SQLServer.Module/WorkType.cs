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
    
    public partial class WorkType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public double Percent { get; set; }
        public int Work_Id { get; set; }
    
        public virtual Work Work { get; set; }
    }
}
