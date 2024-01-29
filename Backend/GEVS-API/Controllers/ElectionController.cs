using GEVS_API.Context;
using GEVS_API.Entities;
using GEVS_API.Models;
using GEVS_API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GEVS_API.Controllers;

[Route("api/election")]
[ApiController]
public class ElectionController : ControllerBase
{
    private readonly GevsContext _context;
    
    public ElectionController(GevsContext context)
    {
        _context = context;
    }

    [HttpPost("start")]
    public async Task<ActionResult> PostStart()
    {
        var activeElection = _context.ElectionEntities
            .FirstOrDefault(e => e.EndDateTime == DateTime.MaxValue);
        if (activeElection != null)
        {
            return BadRequest(new { message = "An election is already in progress."});
        }
    
        ElectionEntity election = new ElectionEntity
        {
            StartDateTime = DateTime.Now
        };

        _context.ElectionEntities.Add(election);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Election start successful." + election.StartDateTime });
    }

    [HttpPost("end")]
    public async Task<ActionResult> PostEnd()
    {
        var activeElection = _context.ElectionEntities
            .FirstOrDefault(e => e.EndDateTime == DateTime.MaxValue);
    
        if (activeElection != null)
        {
            activeElection.EndDateTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(new { message = "Election ended successfully."});
        }
        else
        {
            return BadRequest(new { message = "No active election found." });
        }
    }
    
    [HttpGet("isActive")]
    public ActionResult<bool> GetElectionIsActive()
    {
        var activeElection = _context.ElectionEntities
            .FirstOrDefault(e => e.EndDateTime == DateTime.MaxValue && e.StartDateTime <= DateTime.Now);

        return Ok(activeElection != null);
    }
    


}