using FretAPI.Data;
using FretAPI.Models;

namespace FretAPI.Services;

public class TuningsService : ITuningsService
{
    private readonly ILogger<TuningsService> _logger;
    private readonly ITuningsData _tuningsData;

    public TuningsService(ILogger<TuningsService> logger, ITuningsData tuningsData)
    {
        _logger = logger;
        _tuningsData = tuningsData;
    }

    public async Task<IEnumerable<TuningsModel>> GetAllTunings()
    {
        try
        {
            return await _tuningsData.GetTunings();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting tunings");
            throw;
        }
    }

    public async Task<TuningsModel?> GetTunings(int id)
    {
        try
        {
            return await _tuningsData.GetTunings(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting tunings");
            throw;
        }
    }

    public async Task InsertTunings(TuningsModel tuningsModel)
    {
        try
        {
            await _tuningsData.InsertTunings(tuningsModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occured while inserting tunings");
            throw;
        }
    }

    public async Task DeleteTunings(int id)
    {
        try
        {
            await _tuningsData.DeleteTunings(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occured while inserting tunings");
            throw;
        }
    }
}
