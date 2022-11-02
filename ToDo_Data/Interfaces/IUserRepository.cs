namespace ToDo_Data.Interfaces;

public interface IUserRepository
{
    Task<List<UserId>> getUserIds();
    Task<UserId?> getUser(string username);
    Task<UserId> login(string username, string password);
    Task<UserId> createUser(string username, string password);
    Task<bool> updateUser(UserId userId, string username, string password);
    Task<bool> deleteUser(UserId userid);
    Task<UserId> getUserByID(int UserId);
}