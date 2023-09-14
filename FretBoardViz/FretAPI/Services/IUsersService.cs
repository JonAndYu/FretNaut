using FretAPI.Models;

namespace FretAPI.Services
{
    public interface IUsersService
    {
        Task DeleteUsers(int id);
        Task<IEnumerable<UsersModel>> GetAllUsers();
        Task<UsersModel?> GetUsers(int id);
        Task InsertUsers(UsersModel users);
        Task UpdateUsers(int userId, string username = null, string passwordHash = null, string email = null);
    }
}