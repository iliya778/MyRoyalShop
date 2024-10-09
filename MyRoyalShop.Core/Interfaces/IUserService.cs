using MyRoyalShop.DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRoyalShop.Core.Interfaces
{
    public interface IUserService
    {
        bool RegisterUser(RegisterViewModel register);
        bool IsEmailExist(string email);
        bool IsUserNameExist(string userName);

        bool ActiveUser(string activeCode);

    }
}
