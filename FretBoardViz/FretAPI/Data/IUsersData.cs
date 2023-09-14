using FretAPI.Models;

namespace FretAPI.Data
{
    public interface IUsersData
    {
        Task DeleteUsers(int id);
        Task<UsersModel?> GetUsers(int id);
        Task<IEnumerable<UsersModel>> GetUsers();
        Task InsertUsers(UsersModel user);
        Task UpdateUsers(UsersModel user);
    }
}