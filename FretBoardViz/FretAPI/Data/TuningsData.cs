using FretAPI.DbAccess;

namespace FretAPI.Data;

public class TuningsData
{
    private readonly ISqlDataAccess _db;

    public TuningsData(ISqlDataAccess db)
    {
        _db = db;
    }
}
