using MatchDataManager.Api.MatchData;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{
    private readonly MatchDataDbContext _context;

    public TeamsController(MatchDataDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<ActionResult<Team>> AddTeam(Team team)
    {
        TeamsRepository.AddTeam(team);
        _context.Team.Add(team);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = team.Id}, team);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTeam(Guid teamId)
    {
        var deletedTeam = await _context.Team.FindAsync(teamId);
        
        if (deletedTeam == null)
        {
            return NotFound();
        }
        TeamsRepository.DeleteTeam(teamId);
        _context.Team.Remove(deletedTeam);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Team>>> Get()
    {
        return Ok(await _context.Team.ToListAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Team>> GetById(Guid id)
    {
        var teamInDataBase = await _context.Team.FindAsync(id);
        //var location = TeamsRepository.GetTeamById(id);
        if (teamInDataBase is null)
        {
            return NotFound();
        }

        return Ok(teamInDataBase);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTeam(Team team)
    {
        TeamsRepository.UpdateTeam(team);
        _context.Entry(team).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException)
        {
            if (TeamsRepository.GetTeamById(team.Id) != null)
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