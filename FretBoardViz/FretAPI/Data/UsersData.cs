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

    public Task<IEnumerable<UserModel>> GetUsers() =>
        _db.LoadData<UserModel, dynamic>(storedProcedure: "spUser_GetAll", new { });

    public async Task<UserModel?> GetUser(int id)
    {
        var results = await _db.LoadData<UserModel, dynamic>(
            storedProcedure: "dbo.spUser_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertUser(UserModel user) =>
        _db.SaveData(storedProcedure: "dbo.spUser_Insert", new { user.Username, user.PasswordHash, user.Email });

    public Task UpdateUser(UserModel user) =>
        _db.SaveData(storedProcedure: "dbo.spUser_Update", user);

    public Task DeleteUser(int id) =>
        _db.SaveData(storedProcedure: "dbo.spUser_Update", new { Id = id });

}
