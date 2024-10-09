using MyRoyalShop.DataLayer.Context;
using MyRoyalShop.DataLayer.Domain;
using MyRoyalShop.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRoyalShop.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        MyRoyalShopDbContext _context;
        public UserRepository(MyRoyalShopDbContext context)
        {
            _context = context;
        }
        public int AddUser(User user)
        {
            _context.Users.Add(user);
            return user.UserId;
        }

        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            DeleteUser(user); 
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
        }

        public void EditUser(User user)
        {
            _context.Update(user);
        }

        public IEnumerable<User> GetAllUser()
        {
            return _context.Users;
        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public bool IsEmailExist(string email)
        {
            return _context.Users.Any(user =>user.UserEmail == email);
        }

        public bool IsUserNameExist(string userName)
        {
            return _context.Users.Any(user => user.UserName == userName);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
