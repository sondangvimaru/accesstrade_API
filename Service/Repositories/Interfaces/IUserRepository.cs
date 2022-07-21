using DLL.Entity;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories.Interfaces
{
    public interface IUserRepository: IGenericRepository<User>
    {
        ApiLoginReponse Getloginresult(LoginModel model, AppSettings _appSettings);
    }
}
