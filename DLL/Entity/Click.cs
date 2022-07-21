using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Entity
{
    public class Click
    {
        public int Id { get; set; }
        public int UserID { get; set; }

        public DateTime Click_Time { get; set; }
        public string? Ip_Adds { get; set; }
        public Guid Camp_Id { get; set; }

        public User? User { get; set; }
        public Camps? Camps { get; set; }
    }
}
