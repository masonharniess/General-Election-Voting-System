using GEVS_API.Context;
using GEVS_API.DTOs;
using GEVS_API.Entities;
using GEVS_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GEVS_API.Controllers;

[Route("api")]
[ApiController]
public class VoteController : ControllerBase
{
    private readonly GevsContext _context;

    public VoteController(GevsContext context)
    {
        _context = context;
    }

    [HttpPost("vote")]
    public async Task<ActionResult<VoteEntity>> PostVote(VoteDto voteDto)
    {
        var activeElection = _context.ElectionEntities
            .FirstOrDefault(e => e.EndDateTime == DateTime.MaxValue && e.StartDateTime <= DateTime.Now);

        if (activeElection == null)
        {
            return BadRequest(new { message = "There's no active election at the moment."});
        }

        var candidate = await _context.CandidateEntities
            .Include(c => c.Constituency)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == voteDto.CandidateId);

        if (candidate == null)
        {
            return BadRequest(new { message = "Invalid candidate."});
        }

        var candidateConstituencyId = candidate.ConstituencyId;
        var candidateName = candidate.Name;
        var constituencyName = candidate.Constituency.Name;

        var user = await _context.UserEntities
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == voteDto.UserId);

        if (user == null)
        {
            return BadRequest(new { message = "Invalid user."});
        }

        if (user.ConstituencyId != candidateConstituencyId)
        {
            return BadRequest(new { message = "You can only vote for candidates within your constituency."});
        }

        var existingVote = await _context.VoteEntities
            .Include(v => v.Candidate)
            .AsNoTracking()
            .FirstOrDefaultAsync(v =>
                v.UserId == voteDto.UserId && v.Candidate.ConstituencyId == candidateConstituencyId);

        if (existingVote != null)
        {
            return BadRequest(new { message = "Your vote has already been obtained. You cannot vote more than once."});
        }

        var voteEntity = new VoteEntity
        {
            UserId = voteDto.UserId,
            CandidateId = voteDto.CandidateId
        };

        _context.VoteEntities.Add(voteEntity);
        await _context.SaveChangesAsync();

        return Ok(new { message = $"Your vote for {candidateName} in {constituencyName} was successful." });
    }


    [HttpGet("countVotes")]
    public async Task<ActionResult<IEnumerable<VoteCountResult>>> CountVotes()
    {
        var voteCounts = await _context.VoteEntities
            .Include(v => v.Candidate) 
            .ThenInclude(c => c.Constituency) 
            .GroupBy(v => new
            {
                v.Candidate.ConstituencyId, v.CandidateId, ConstituencyName = v.Candidate.Constituency.Name,
                CandidateName = v.Candidate.Name
            })
            .Select(group => new VoteCountResult
            {
                ConstituencyId = group.Key.ConstituencyId,
                ConstituencyName = group.Key.ConstituencyName,
                CandidateId = group.Key.CandidateId,
                CandidateName = group.Key.CandidateName,
                VoteCount = group.Count()
            })
            .ToListAsync();

        return Ok(voteCounts);
    }
    
    public class VoteCountResult
    {
        public Guid ConstituencyId { get; set; }
        public string ConstituencyName { get; set; }
        public Guid CandidateId { get; set; }
        public string CandidateName { get; set; }
        public int VoteCount { get; set; }
    } 

    [HttpGet("getWinner")]
    public async Task<ActionResult> GetWinner()
    {
        var votesWithDetails = await _context.VoteEntities
            .Include(v => v.Candidate)
            .ThenInclude(c => c.Party)
            .Include(v => v.Candidate)
            .ThenInclude(c => c.Constituency)
            .Select(v => new
            {
                v.CandidateId,
                CandidateName = v.Candidate.Name,
                ConstituencyId = v.Candidate.ConstituencyId,
                ConstituencyName = v.Candidate.Constituency.Name,
                PartyId = v.Candidate.Party.Id,
                PartyName = v.Candidate.Party.Name
            })
            .ToListAsync();
        
        var constituencyWinners = votesWithDetails
            .GroupBy(v => v.ConstituencyId)
            .Select(g => g
                .GroupBy(v => v.CandidateId)
                .OrderByDescending(gg => gg.Count())
                .FirstOrDefault()
                .First())
            .ToList();
        
        var partyWins = constituencyWinners
            .GroupBy(w => w.PartyId)
            .Select(group => new
            {
                PartyId = group.Key,
                PartyName = group.First().PartyName,
                ConstituencyWins = group.Count()
            })
            .OrderByDescending(g => g.ConstituencyWins)
            .ToList();
        
        var totalConstituencies = constituencyWinners.Count;
        
        var winningParty = partyWins.FirstOrDefault();

        if (winningParty == null || winningParty.ConstituencyWins <= (totalConstituencies / 2))
        {
            return Ok(new { message = "Hung parliament."});
        }

        return Ok(new { message = $"The winning party is {winningParty.PartyName}."});
    }

}