using ToDo_Data;

namespace REACT_TODO_API.Services;

public interface IUserService
{
    Task<List<UserId>> getUserIds();
    Task<UserId> getUser(string username);
    Task<UserId> login(string username, string password);
    Task<UserId> createUser(string username, string password);
    Task<bool> updateUser(int userId, string username, string password);
    Task<bool> deleteUser(int userid);
}