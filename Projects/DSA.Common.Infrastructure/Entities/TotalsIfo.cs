using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Common.Infrastructure.Entities
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
