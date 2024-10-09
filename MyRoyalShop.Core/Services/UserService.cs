using MyRoyalShop.Core.Interfaces;
using MyRoyalShop.DataLayer.ViewModels;
using MyRoyalShop.DataLayer.Interfaces;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRoyalShop.DataLayer.Domain;
using MyRoyalShop.Core.Securities;
using MyRoyalShop.DataLayer.Repositories;

namespace MyRoyalShop.Core.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ActiveUser(string activeCode)
        {
            var user = _userRepository.GetUserByActiveCode(activeCode);
            if(user == null)
            {
                return false;
            }
            user.IsActive = true;
            user.ActiveCode=Guid.NewGuid().ToString();

            _userRepository.EditUser(user);
            _userRepository.Save();

            return true;
        }

        public bool IsEmailExist(string email)
        {
            string _email = email.ToLower().Trim();
            return _userRepository.IsEmailExist(_email);
        }

        public bool IsUserNameExist(string userName)
        {
            return _userRepository.IsUserNameExist(userName);
        }

        public bool RegisterUser(RegisterViewModel register)
        {
            User user = new User();
            user.UserName = register.UserName;
            user.UserEmail = register.UserEmail.ToLower().Trim();
            user.RegisterDate = DateTime.Now;
            user.UserPassword = SecurePasswordHasher.EncodePasswordMd5(register.UserPassword);
            user.IsAdmin = false;
            user.IsActive =false;
            user.ActiveCode= Guid.NewGuid().ToString();

            _userRepository.AddUser(user);
            _userRepository.Save();

            return true;
        }
    }
}
