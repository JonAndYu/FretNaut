using FretAPI.Models;
using FretAPI.Services;
using FretAPI.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace FretAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoardController : ControllerBase
{
    /*private readonly ITuningService _tuningService;

    public BoardController(ITuningService tuningService)
    {
        _tuningService = tuningService;
    }*/

    // GET: api/Board
    /*[HttpGet]
    public IEnumerable<Tunings> GetTunings()
    {
        // Retrieve and return all tuning objects
        return _tuningService.TuningList();
    }*/

    // GET: api/Board/instrument/name
    /*[HttpGet("{instrument}/{name}")]
    public IEnumerable<string> GetTuning(string instrument, string name)
    {
        return _tuningService.Tuning(name, instrument);
    }*/
}
