using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Data.Repositories
{
    internal class UserRepository
    {
        private readonly ReactAPIContext _reactAPIContext;
        public UserRepository(ReactAPIContext reactAPIContext)
        {
            _reactAPIContext = reactAPIContext;
        }

        public async Task<List<UserId>> getUserIds()
        {
            try
            {
                var userids = (from item in _reactAPIContext.UserIds
                               select item).ToList();
                return userids;
            }
            catch (Exception)
            {
                return new List<UserId> { };
                throw;
            }
        }

        public async Task<UserId> getUser(string username)
        {
            try
            {
                var userids = (from item in _reactAPIContext.UserIds
                               where item.Username == username
                               select item).FirstOrDefault();
                return userids;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<UserId> createUser(string username, string password)
        {
            try
            {
                 if (!validatepassword(password)) new Exception("Password is not complex enough.");
                var newuser = new UserId { Password = password, 
                Username = username};
                var userids = _reactAPIContext.UserIds.AddAsync(newuser).Result.Entity;
                return userids;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<bool> updateUser(UserId userId, string username, string password)
        {
            try
            {
                if (validatepassword(password) || password == null)
                    throw new Exception("Your password isn't complex enough.");


                if (username == null)
                    throw new Exception("Invalid Username");
                userId.Password = password;
                userId.Username = username;
                var _userId = _reactAPIContext.UserIds.Update(userId).Entity;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        private bool validatepassword(string password)
        {
            return true;
        }
    }
}
