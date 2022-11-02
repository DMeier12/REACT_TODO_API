using Microsoft.AspNetCore.Mvc;
using REACT_TODO_API.Services;
using ToDo_Data;

namespace REACT_TODO_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<List<UserId>> GetUsersAsync()
        {
            try
            {
                var returnvalue = await _userService.getUserIds();
                return (returnvalue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("CreateUser")]
        public async Task<UserId> CreateUserAsync(string username, string password)
        {
            try
            {
                var returnvalue = await _userService.createUser(username, password);
                return returnvalue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("UpdateUser")]
        public async Task<bool> UpdateUserAsync(int userid, string username, string password)
        {
            try
            {
                var returnvalue = await _userService.updateUser(userid, username, password);
                return returnvalue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("DeleteUser")]
        public async Task<bool> DeleteUserAsync(int userid)
        {
            try
            {
                var returnvalue = await _userService.deleteUser(userid);
                return returnvalue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet("Login")]
        public async Task<UserId> LoginAsync(string username, string password)
        {
            try
            {
                var returnvalue = await _userService.login(username, password);
                return returnvalue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }

    
}