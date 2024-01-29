using GEVS_API.Context;
using GEVS_API.Entities;

namespace GEVS_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
public class ConstituenciesController : ControllerBase
{
    private readonly GevsContext _context;

    public ConstituenciesController(GevsContext context)
    {
        _context = context;
    }


    [HttpGet("api/constituencies")]
    public async Task<ActionResult<IEnumerable<ConstituencyEntity>>> GetConstituencies()
    {
        return await _context.ConstituencyEntities.ToListAsync();
    }
    
    [HttpGet("gevs/constituency/{constituencyName}")]
    public async Task<ActionResult> GetVoteCount(string constituencyName)
    {
        var constituency = await _context.ConstituencyEntities
            .Include(c => c.Candidates)
            .ThenInclude(cand => cand.Votes)
            .FirstOrDefaultAsync(c => c.Name.ToLower() == constituencyName.ToLower());
        
        if (constituency == null)
        {
            return NotFound(new { message = "Constituency not found." });
        }

        var result = constituency.Candidates
            .Select(c => new 
            {
                name = c.Name,
                party = c.Party != null ? c.Party.Name : "No Party",
                vote = c.Votes != null ? c.Votes.Count() : 0 
            });

        return Ok(new 
        { 
            constituency = constituencyName,
            result = result
        });
    }

}