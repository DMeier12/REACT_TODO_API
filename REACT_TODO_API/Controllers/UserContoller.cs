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

        [HttpGet(Name = "GetUsers")]
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

        [HttpPut(Name = "CreateUser")]
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
    }

    
}