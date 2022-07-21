using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Entity
{
    public class Oder
    {
        public string? Oder_Id { get; set; }
        public string? Device_Type { get; set; }
        public DateTime? Click_Time { get; set; }
        public DateTime? Confirmed_Time { get; set; } 
        public int Oder_status { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }
    }
}
