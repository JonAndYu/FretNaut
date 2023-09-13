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
    private readonly IGuitarTuningService _guitarTuningService;
    private readonly IBassTuningService _bassTuningService;

    public BoardController(
        IGuitarTuningService guitarTuningService,
        IBassTuningService bassTuningService)
    {
        _guitarTuningService = guitarTuningService;
        _bassTuningService = bassTuningService;
    }

    // GET: api/Board
    [HttpGet]
    public IEnumerable<Tunings> GetTunings()
    {
        // Retrieve and return all tuning objects
        return _guitarTuningService.TuningList().Concat(_bassTuningService.TuningList());
    }

    // GET: api/Board/instrument/name
    [HttpGet("{instrument}/{name}")]
    public IEnumerable<string> GetTuning(string instrument, string name)
    {
        return _guitarTuningService.Tuning(name);
    }
}
