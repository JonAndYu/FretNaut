using FretAPI.Models;
using FretAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FretAPI.Controllers;

public class FretboardController : ControllerBase
{
    private readonly ILogger<FretboardController> _logger;
    private readonly IFretboardService _fretboardService;

    public FretboardController(ILogger<FretboardController> logger, IFretboardService fretboardService)
    {
        _logger = logger;
        _fretboardService = fretboardService;
    }

    // GET: api/Fretboard
    // 
    [HttpGet]
    public async Task<IActionResult> GetFretboardModels()
    {
        try
        {
            var fretboards = await _fretboardService.GetAllFretboards();
            return Ok(fretboards); // Assuming you want to return a 200 OK response with the list of fretboards
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving fretboards.");
            return StatusCode(StatusCodes.Status500InternalServerError); // Return a 500 Internal Server Error in case of an exception
        }
    }
}
