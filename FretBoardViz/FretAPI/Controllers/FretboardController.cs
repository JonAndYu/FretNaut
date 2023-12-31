﻿using FretAPI.Models;
using FretAPI.Services;
using FretAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FretAPI.Controllers;

[Route("api/[controller]")]
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
	[AllowAnonymous]
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
            return StatusCode(StatusCodes.Status500InternalServerError, ex); // Return a 500 Internal Server Error in case of an exception
        }
    }

	// Get: api/Fretboard/{id}
	// 
	[HttpGet("GetFretboard/{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetFretboard(string id)
	{
		try
		{
			var fretboards = await _fretboardService.GetFretboardById(id);
			return Ok(fretboards);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "An error occured while retrieving fretboard");
			return StatusCode(StatusCodes.Status500InternalServerError, ex);
		}
	}

	[HttpPost("createfretboard/{str}")]
	[AllowAnonymous]
	public async Task<IActionResult> CreateFretboard(string str)
	{
		try
		{
			// Validate the incoming data.
			if (!NotesHelper.IsValidString(str))
			{
				return BadRequest($"Invalid tuning: {str}");
			}

			// Process the data (save it to a database)
			List<List<string>> notes = SemitoneGenerator
				.CreateNotesArray(NotesHelper.ConvertToList(str));
			var jsonString = JsonSerializer.Serialize(notes);
			await _fretboardService.InsertFretboard(
				new FretboardModel
				{
					TuningValues = str,
					Notes = jsonString
				});

			// Return a successful response
			return Ok("Fretboard created successfully");
		}
		catch (Exception ex)
		{
			// Log the error
			_logger.LogError(ex, "An error occurred while creating a fretboard");

			// Return an error response
			return StatusCode(StatusCodes.Status500InternalServerError, ex);
		}
	}

	// DELETE: api/Fretboard/{str}
	[HttpDelete("DeleteFretboard/{str}")]
	public async Task<IActionResult> DeleteFretboard(string str)
	{
		try
		{
			// Validate the incoming data.
			if (!NotesHelper.IsValidString(str))
			{
				return BadRequest($"Invalid tuning: {str}");
			}

			if ((await _fretboardService.GetFretboardById(str)) is null)
			{
				return BadRequest(StatusCodes.Status404NotFound);
			}

			await _fretboardService.DeleteFretboardById(str);

			// Return a successful response
			return Ok("Fretboard deleted successfully");


		}
		catch (Exception ex )
		{
			// Log the error
			_logger.LogError(ex, "An error occurred while creating a fretboard");

			// Return an error response
			return StatusCode(StatusCodes.Status500InternalServerError, ex);
		}
	}

	// Get: api/FretboardNotes/{str}
	// 
	[HttpGet("notes/{str}")]
	[AllowAnonymous]
	public IActionResult GetFretboardNotes(string str)
	{
		// Validate the incoming data.
		if (!NotesHelper.IsValidString(str))
		{
			return BadRequest($"Invalid tuning: {str}");
		}

		// Process the data (save it to a database)
		List<List<string>> notes = SemitoneGenerator
			.CreateNotesArray(NotesHelper.ConvertToList(str));
		return Ok(notes);
	}
}
