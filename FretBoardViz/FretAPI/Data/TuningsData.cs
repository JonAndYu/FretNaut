using FretAPI.DbAccess;
using FretAPI.Models;

namespace FretAPI.Data;

public class TuningsData : ITuningsData
{
    private readonly ISqlDataAccess _db;

    public TuningsData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<TuningsModel>> GetTunings() =>
        _db.LoadData<TuningsModel, dynamic>(storedProcedure: "dbo.spTunings_GetAll", new { });

    public async Task<TuningsModel?> GetTunings(int id)
    {
        var results = await _db.LoadData<TuningsModel, dynamic>(
            storedProcedure: "dbo.spTunings_Get",
            new { TuningId = id });
        return results.FirstOrDefault();
    }

    public Task InsertTunings(TuningsModel tune) =>
        _db.SaveData(storedProcedure: "dbo.spTunings_Insert", new { tune.Name, tune.Instrument, tune.TuningValues, tune.UserId });

    public Task DeleteTunings(int id) =>
        _db.SaveData(storedProcedure: "dbo.spTunings_Delete", new { TuningId = id });
}
