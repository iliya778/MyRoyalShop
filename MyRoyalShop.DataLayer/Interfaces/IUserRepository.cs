using MyRoyalShop.DataLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRoyalShop.DataLayer.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int userId);
        User GetUserByActiveCode(string activeCode);
        int AddUser(User user); 
        void EditUser(User user);
        void DeleteUser(int userId);
        void DeleteUser(User user);
        bool IsEmailExist(string email);
        bool IsUserNameExist(string userName);
        void Save();


    }
}
