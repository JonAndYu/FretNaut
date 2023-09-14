using FretAPI.Data;
using FretAPI.Models;

namespace FretAPI.Services;

public class UsersService : IUsersService
{
    private readonly ILogger<UsersService> _logger;
    private readonly IUsersData _usersData;

    public UsersService(ILogger<UsersService> logger, IUsersData usersData)
    {
        _logger = logger;
        _usersData = usersData;
    }

    public async Task<IEnumerable<UsersModel>> GetAllUsers()
    {
        try
        {
            return await _usersData.GetUsers();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving all users");
            throw;
        }
    }

    public async Task<UsersModel?> GetUsers(int id)
    {
        try
        {
            return await _usersData.GetUsers(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occured while retrieving user");
            throw;
        }
    }

    public async Task InsertUsers(UsersModel users)
    {
        try
        {
            await _usersData.InsertUsers(users);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occured while inserting User");
            throw;
        }
    }

    public async Task UpdateUsers(int userId,
                                  string username = null,
                                  string passwordHash = null,
                                  string email = null)
    {
        try
        {
            await _usersData.UpdateUsers(new UsersModel
            {
                UserId = userId,
                Username = username,
                PasswordHash = passwordHash,
                Email = email
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occured while updating User");
            throw;
        }
    }

    public async Task DeleteUsers(int id)
    {
        try
        {
            await _usersData.DeleteUsers(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occured while deleting user");
            throw;
        }
    }
}

