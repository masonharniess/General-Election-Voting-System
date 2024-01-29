using GEVS_API.Context;
using GEVS_API.DTOs;
using GEVS_API.Entities;

namespace GEVS_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api")]
[ApiController]
public class CandidateController : ControllerBase
{
    private readonly GevsContext _context;

    public CandidateController(GevsContext context)
    {
        _context = context;
    }

    [HttpGet("candidates")]
    public async Task<ActionResult<IEnumerable<CandidateDto>>> GetCandidates()
    {
        var candidates = await _context.CandidateEntities
            .Include(c => c.Party) 
            .Include(c => c.Constituency) 
            .Select(c => new CandidateDto
            {
                Id = c.Id,
                Name = c.Name,
                PartyName = c.Party.Name,
                ConstituencyName = c.Constituency.Name,
                VoteCount = c.Votes.Count 
            })
            .ToListAsync();

        return Ok(candidates);
    }


}