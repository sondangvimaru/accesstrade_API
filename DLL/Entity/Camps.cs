using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Entity
{
    public class Camps
    {
        public Guid Camp_Id { get; set; }  
        public string? Camp_Name { get; set; }
        public string? Type { get; set; }

       
        public String? Price { get; set; } = "0";
        public string? Camps_Image { get; set;}
        public DateTime? Created { get; set; }
        public String? Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public virtual ICollection<Click>? Clicks { get; set; }
    }
}
