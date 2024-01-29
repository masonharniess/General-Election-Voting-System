using GEVS_API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GEVS_API.Entities;


namespace GEVS_API.Controllers;

[ApiController]
[Route("gevs")]
public class ResultsController : ControllerBase
{
    private readonly GevsContext _context;

    public ResultsController(GevsContext context)
    {
        _context = context;
    }

    [HttpGet("results")]
    public async Task<ActionResult> GetElectionResults()
    {
        var isElectionOngoing = _context.ElectionEntities
            .Any(e => e.EndDateTime == DateTime.MaxValue && e.StartDateTime <= DateTime.Now);
    
        var results = await _context.PartyEntities
            .Include(p => p.Candidates)
            .ThenInclude(cand => cand.Votes)
            .Select(p => new 
            {
                party = p.Name,
                seat = p.Candidates.Sum(c => c.Votes.Count)
            })
            .ToListAsync();

        string status = isElectionOngoing ? "Pending" : "Completed";
        string winner = isElectionOngoing ? "Pending" : GetWinner(results.Cast<dynamic>().ToList());

        return Ok(new 
        {
            status = status,
            winner = winner,
            seats = results
        });
    }


    private string GetWinner(List<dynamic> results)
    {
        // Calculate the total number of seats
        int totalSeats = results.Sum(r => (int)r.seat);
    
        // Find the party with the most seats
        var winningParty = results.OrderByDescending(r => (int)r.seat).FirstOrDefault();
    
        // Check if the winning party has more than half of the total seats
        if (winningParty != null && (int)winningParty.seat > totalSeats / 2)
        {
            return winningParty.party;
        }
    
        // Check if there's a tie for the most seats
        bool isTie = results.Count(r => (int)r.seat == (int)winningParty.seat) > 1;
    
        // If there's a tie or no party has more than half of the seats, it's a hung parliament
        if (isTie || (int)winningParty.seat <= totalSeats / 2)
        {
            return "Hung Parliament";
        }
    
        return winningParty.party;
    }

}
