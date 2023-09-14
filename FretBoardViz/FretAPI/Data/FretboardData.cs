using FretAPI.DbAccess;
using FretAPI.Models;

namespace FretAPI.Data;

public class FretboardData : IFretboardData
{
    private readonly ISqlDataAccess _db;

    public FretboardData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<FretboardModel>> GetUsers() =>
        _db.LoadData<FretboardModel, dynamic>(storedProcedure: "dbo.spFretboard_GetAll", new { });

    public async Task<FretboardModel?> GetAllFretboards(int id)
    {
        var results = await _db.LoadData<FretboardModel, dynamic>(
            storedProcedure: "dbo.spFretboard_Get",
            new { TuningId = id });
        return results.FirstOrDefault();
    }

    public Task InsertFretboard(FretboardModel fretboard) =>
        _db.SaveData(storedProcedure: "dbo.spFretboard_Insert", new { fretboard.TuningId, fretboard.Fretboard });

    public Task DeleteFretboard(int id) =>
        _db.SaveData(storedProcedure: "dbo.spFretboard_Delete", new { TuningId = id });
}
