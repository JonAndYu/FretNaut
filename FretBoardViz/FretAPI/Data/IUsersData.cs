using FretAPI.Models;

namespace FretAPI.Data
{
    public interface IUsersData
    {
        Task DeleteUser(int id);
        Task<UsersModel?> GetUser(int id);
        Task<IEnumerable<UsersModel>> GetUsers();
        Task InsertUser(UsersModel user);
        Task UpdateUser(UsersModel user);
    }
}