using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class ApiLoginReponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Token_Key { get; set; }
        public int Status { get; set; }
        public int Is_Admin { get; set; }
    }
}
