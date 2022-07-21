﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Entity
{
    public class Category
    {

        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public virtual ICollection<Camps>?Camps { get; set; }
            

    }
}
