using ToDo_Data.Interfaces;

namespace ToDo_Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ReactAPIContext _reactApiContext;
        public UserRepository(ReactAPIContext reactApiContext)
        {
            _reactApiContext = reactApiContext;
        }

        public async Task<List<UserId>> getUserIds()
        {
            try
            {
                var userids = (from item in _reactApiContext.UserIds
                               select item).ToList();
                return userids;
            }
            catch (Exception)
            {
                return new List<UserId> { };
                throw;
            }
        }

        public Task<UserId?> getUser(string username)
        {
            try
            {
                var userids = (from item in _reactApiContext.UserIds
                               where item.Username == username
                               select item).FirstOrDefault();
                return Task.FromResult(userids);
            }
            catch (Exception)
            {
                return Task.FromResult<UserId>(null);
                throw;
            }
        }

        public Task<UserId> getUserByID(int UserId)
        {
            var user = (from item in _reactApiContext.UserIds
                where item.UserId1 == UserId
                select item).Single();

            return Task.FromResult(user);
        }

        public async Task<UserId> login(string username, string password)
        {
            var user = await getUser(username);
            return user.Password == password ? user : null;
        }

        public async Task<UserId> createUser(string username, string password)
        {
            try
            {

                if (!validatepassword(password)) throw new Exception("Password is not complex enough.");
                var newuser = new UserId { Password = password, 
                Username = username};
                var userids = _reactApiContext.UserIds.Add(newuser).Entity;
                _reactApiContext.SaveChanges();
                return userids;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> updateUser(UserId userId, string username, string password)
        {
            if (!validatepassword(password))
                    throw new Exception("Your password isn't complex enough.");

            if (username == null)
                throw new Exception("Invalid Username");

            userId.Password = password;
            userId.Username = username;

            var _userId = _reactApiContext.UserIds.Update(userId).Entity;
            _reactApiContext.SaveChanges();

            return true;
            }

        public async Task<bool> deleteUser(UserId userId)
        {

            var diduserdelete = _reactApiContext.UserIds.Remove(userId).Entity;
           _reactApiContext.SaveChanges();
            return diduserdelete != null;
        }


        private bool validatepassword(string password)
        {
            return true;
        }
    }
}
