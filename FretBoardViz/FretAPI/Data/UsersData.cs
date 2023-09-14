using FretAPI.DbAccess;
using FretAPI.Models;

namespace FretAPI.Data;

public class UsersData : IUsersData
{
    private readonly ISqlDataAccess _db;

    public UsersData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UsersModel>> GetUsers() =>
        _db.LoadData<UsersModel, dynamic>(storedProcedure: "dbo.spUsers_GetAll", new { });

    public async Task<UsersModel?> GetUsers(int id)
    {
        var results = await _db.LoadData<UsersModel, dynamic>(
            storedProcedure: "dbo.spUsers_Get",
            new { UserId = id });
        return results.FirstOrDefault();
    }

    public Task InsertUsers(UsersModel user) =>
        _db.SaveData(storedProcedure: "dbo.spUsers_Insert", new { user.Username, user.PasswordHash, user.Email });

    public Task UpdateUsers(UsersModel user) =>
        _db.SaveData(storedProcedure: "dbo.spUsers_Update", user);

    public Task DeleteUsers(int id) =>
        _db.SaveData(storedProcedure: "dbo.spUsers_Delete", new { UserId = id });

}
