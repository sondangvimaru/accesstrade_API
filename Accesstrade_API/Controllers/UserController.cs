using DLL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Service.Repositories.Interfaces;
using Service.ViewModels;

namespace Accesstrade_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository Userrepository;
        private readonly AppSettings Appsettings;
        public UserController(IUserRepository userRepository, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            Userrepository = userRepository;
            Appsettings = optionsMonitor.CurrentValue;
        }


        ///Hàm bắt sự kiện người dùng yêu cầu đăng nhập từ fontend
        [HttpPost("Login")]
        public IActionResult Validate(LoginModel model)
        {
            var result = Userrepository.Getloginresult(model, Appsettings);
            return Ok(result);
        }




        /// Hàm tạo thêm 1 bản ghi người dùng
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> createnew(UserModel model)
        {
            var newuser = new User()
            {
              
                Email = model.Email,
                HoTen = model.HoTen, 
                Username = model.Username,
                Password = model.Password,
                gender=model.gender,
                NgaySinh = model.NgaySinh,
                SoDienThoai = model.SoDienThoai,
                SoTaiKhoan = model.SoTaiKhoan,
                ChuTaiKhoan= model.ChuTaiKhoan,
                NganHang = model.NganHang,
                Avatar=model.Avatar,
                Status=model.Status,
                IsAdmin=model.IsAdmin,

            

            };
            var nguoidungmoi = await Userrepository.Add(newuser);
            return Ok(nguoidungmoi);

        }
    }
}
