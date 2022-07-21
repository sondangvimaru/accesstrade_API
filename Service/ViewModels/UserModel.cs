using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class UserModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? HoTen { get; set; }
        public int gender { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? SoTaiKhoan { get; set; }
        public string? ChuTaiKhoan { get; set; }
        public string? NganHang { get; set; }
        public string? Avatar { get; set; }
        public int IsAdmin { get; set; }
        public int Status { get; set; }
    }
}
