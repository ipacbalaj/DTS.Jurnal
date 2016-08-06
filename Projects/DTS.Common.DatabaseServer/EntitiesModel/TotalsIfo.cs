using System;

namespace DTS.Jurnal.Database.SQLServer.Module.EntitiesModel
{
    public class TotalsIfo
    {
        public int TotalPatients { get; set; }
        public long TotalInverventions { get; set; }
        public double TotalRevenue { get; set; }
        public double TotalProfit { get; set; }
        public TimeSpan TotalHours { get; set; } 
    }
}
