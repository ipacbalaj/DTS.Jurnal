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
    
    public partial class ProgramInfo
    {
        public int Id { get; set; }
        public string ExportFileName { get; set; }
        public System.DateTime LastFileDateImport { get; set; }
        public System.DateTime LastAddedInterventionDate { get; set; }
    }
}
