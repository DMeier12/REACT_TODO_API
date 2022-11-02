using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using ToDo_Data;
using ToDo_Data.Interfaces;

namespace REACT_TODO_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserId>> getUserIds()
        {
            var userIds = await _userRepository.getUserIds();
            return userIds;
        }

        public Task<UserId> getUser(string username)
        {
            var userId = Task.FromResult(_userRepository.getUser(username).Result);
            return userId;
        }

        public Task<UserId> login(string username, string password)
        {
            var loginResult = Task.FromResult(_userRepository.login(username, password).Result);
            return loginResult;
        }

        public Task<UserId> createUser(string username, string password)
        {
            var createUserResult = Task.FromResult(_userRepository.createUser(username, password).Result);
            return createUserResult;
        }

        public Task<bool> updateUser(int userId, string username, string password)
        {
            var currentuser = Task.FromResult(_userRepository.getUserByID(userId).Result);
            if (currentuser == null) throw new Exception("User Not Found");
            var updateUserResult = Task.FromResult(_userRepository.updateUser(currentuser.Result, username, password).Result);
            return updateUserResult;
        }

        public async Task<bool> deleteUser(int userid)
        {
            var currentuser = await Task.FromResult(_userRepository.getUserByID(userid).Result);
            var deleteUserResult = Task.FromResult(_userRepository.deleteUser(currentuser).Result);
            return await deleteUserResult;
        }
    }
}
