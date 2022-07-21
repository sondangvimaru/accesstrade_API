using DLL.Entity;
using Service.Helper;
using Service.Repositories.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories.Implimentations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Accesstradecontext _context) : base(_context) { }

        public ApiLoginReponse Getloginresult(LoginModel model, AppSettings _appSettings)
        {
            var user = _context?.Users?.SingleOrDefault(p => p.Username == model.Username && model.Password == p.Password);
            if (user is null)
                return new ApiLoginReponse()
                {
                    Success = false,
                    Message = "Tài Khoản Hoặc Mật Khẩu không Chính Xác"
                };

            return new ApiLoginReponse()
            {
                Success = true,
                Message = "Authenticate success",
                Token_Key = JwebHelper.GenreRateToken(user, _appSettings),
                Is_Admin =user.IsAdmin,

            };
        }
    }
}
