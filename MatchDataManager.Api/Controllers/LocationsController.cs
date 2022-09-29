using MatchDataManager.Api.MatchData;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationsController : ControllerBase
{
    private readonly MatchDataDbContext _context;

    public LocationsController(MatchDataDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<ActionResult<Location>> AddLocation(Location location)
    {
        LocationsRepository.AddLocation(location);
        _context.Location.Add(location);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = location.Id}, location);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteLocation(Guid locationId)
    {
        var deletedLocation = await _context.Location.FindAsync(locationId);
        
        if (deletedLocation == null)
        {
            return NotFound();
        }
        
        LocationsRepository.DeleteLocation(locationId);
        _context.Location.Remove(deletedLocation);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Location>>> Get()
    {
        //await _context.Location.ToListAsync();
        return Ok(await _context.Location.ToListAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Location>> GetById(Guid id)
    {
        //var location = LocationsRepository.GetLocationById(id);
        var locationInDataBase = await _context.Location.FindAsync(id);
        if (locationInDataBase is null)
        {
            return NotFound();
        }

        return Ok(locationInDataBase);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLocation(Location location)
    {
        LocationsRepository.UpdateLocation(location);
        _context.Entry(location).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException)
        {
            if (LocationsRepository.GetLocationById(location.Id) != null)
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }
}
