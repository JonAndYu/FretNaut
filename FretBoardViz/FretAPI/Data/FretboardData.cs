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

    public Task<IEnumerable<FretboardModel>> GetAllFretboards() =>
        _db.LoadData<FretboardModel, dynamic>(storedProcedure: "dbo.spFretboard_GetAll", new { });

    public async Task<FretboardModel?> GetFretboard(string tuningValues)
    {
        var results = await _db.LoadData<FretboardModel, dynamic>(
            storedProcedure: "dbo.spFretboard_Get",
            new { TuningValues = tuningValues });
        return results.FirstOrDefault();
    }

    public Task InsertFretboard(FretboardModel fretboard) =>
        _db.SaveData(storedProcedure: "dbo.spFretboard_Insert", new { TuningValues = fretboard.TuningValues, Notes = fretboard.Notes });

    public Task DeleteFretboard(string tuningValues) =>
        _db.SaveData(storedProcedure: "dbo.spFretboard_Delete", new { TuningValues = tuningValues });
}
