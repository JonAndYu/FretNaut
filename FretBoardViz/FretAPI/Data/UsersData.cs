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

    public async Task<UsersModel?> GetUser(int id)
    {
        var results = await _db.LoadData<UsersModel, dynamic>(
            storedProcedure: "dbo.spUsers_Get",
            new { UserId = id });
        return results.FirstOrDefault();
    }

    public Task InsertUser(UsersModel user) =>
        _db.SaveData(storedProcedure: "dbo.spUsers_Insert", new { user.Username, user.PasswordHash, user.Email });

    public Task UpdateUser(UsersModel user) =>
        _db.SaveData(storedProcedure: "dbo.spUsers_Update", user);

    public Task DeleteUser(int id) =>
        _db.SaveData(storedProcedure: "dbo.spUsers_Delete", new { UserId = id });

}
