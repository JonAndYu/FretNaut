using FretAPI.DbAccess;

namespace FretAPI.Data;

public class FretboardData
{
    private readonly ISqlDataAccess _db;

    public FretboardData(ISqlDataAccess db)
    {
        _db = db;
    }
}
