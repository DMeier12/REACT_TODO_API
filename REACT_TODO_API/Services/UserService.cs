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

        public Task<bool> updateUser(UserId userId, string username, string password)
        {
            var updateUserResult = Task.FromResult(_userRepository.updateUser(userId, username, password).Result);
            return updateUserResult;
        }
    }
}
