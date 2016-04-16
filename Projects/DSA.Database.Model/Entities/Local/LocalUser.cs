using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS.Jurnal.V3.Database.Module.Entities.Local
{
    public class LocalUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AppInfo { get; set; }
        public string SavePath { get; set; }
        public string ImagePath { get; set; }        
    }
}
