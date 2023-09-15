using FretAPI.Data;
using FretAPI.Models;

namespace FretAPI.Services;

public class FretboardService : IFretboardService
{
    private readonly ILogger<FretboardService> _logger;
    private readonly IFretboardData _fretboardData;

    public FretboardService(ILogger<FretboardService> logger, IFretboardData fretboardData)
    {
        _logger = logger;
        _fretboardData = fretboardData;
    }

    // Add methods for Fretboard-related operations here

    public async Task<IEnumerable<FretboardModel>> GetAllFretboards()
    {
        try
        {
            return await _fretboardData.GetAllFretboards();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting fretboards");
            throw;
        }
    }

    public async Task<FretboardModel?> GetFretboardById(string tuningValues)
    {
        try
        {
            return await _fretboardData.GetFretboard(tuningValues);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while getting fretboard with ID {tuningValues}");
            throw;
        }
    }

    // They'd give an TuningId, and a List of strings, We need to convert that into a FretboardModel
    // And pass it into the _InsertFretboard.
    public async Task InsertFretboard(FretboardModel fretboard)
    {
        try
        {
            await _fretboardData.InsertFretboard(fretboard);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating a new fretboard");
            throw;
        }
    }

    public async Task DeleteFretboardById(string tuningValues)
    {
        try
        {
            await _fretboardData.DeleteFretboard(tuningValues);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting fretboard with tuningValue {tuningValues}");
            throw;
        }
    }
}
