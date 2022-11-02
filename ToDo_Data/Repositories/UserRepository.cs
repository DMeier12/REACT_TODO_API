using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ToDo_Data.Interfaces;

namespace ToDo_Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ReactAPIContext _reactAPIContext;
        public UserRepository()//ReactAPIContext reactAPIContext)
        {
            string connDev = @"metadata=res://*/MyModel.csdl|res://*/MyModel.ssdl|res://*/MyModel.msl;provider=System.Data.SqlClient;provider connection string=""Server=.\sqlexpress;Database=ReactAPI;Integrated Security=True""";
            EntityConnection ec = new EntityConnection(connDev);

            _reactAPIContext = new ReactAPIContext(ec);
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

        public async Task<UserId> login(string username, string password)
        {
            var user = await getUser(username);
            if (user == null) return null;
            return user.Password == password ? user : null;
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
