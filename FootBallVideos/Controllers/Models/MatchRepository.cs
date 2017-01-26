using FootballAnalyticsAPI.ModelsData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootBallVideos.ModelsData;

namespace FootballAnalyticsAPI.Models
{
    public class MatchRepository : IMatchRepository
    {
        //private FootballAnalyticsContext _context;

        //public MatchRepository(FootballAnalyticsContext context)
        //{
        //    _context = context;
        //}

        //public IEnumerable<Match> GetAll()
        //{
        //    return _context.Match;
        //}

        //public async Task<IEnumerable<Match>> GetAllAsync()
        //{
        //    return await _context.Match.ToListAsync();
        //}

        //public void Add(Match item)
        //{
        //    _context.Match.Add(item);
        //    _context.SaveChanges();
        //}

        //public Match Find(int id)
        //{
        //    return (from b in _context.Match
        //            where b.WhoScoredMatchId == id
        //            select b).FirstOrDefault();
        //}

        //public async Task<Match> FindAsync(int id)
        //{
        //    return await (from b in _context.Match
        //                where b.WhoScoredMatchId == id
        //                select b).FirstOrDefaultAsync();
        //}

        //public void Remove(int id)
        //{
        //    var match = new Match { WhoScoredMatchId = id };
        //    _context.Match.Attach(match);
        //    _context.Match.Remove(match);
        //    _context.SaveChanges();
        //}

        //public void Update(Match item)
        //{
        //    _context.Match.Attach(item);
        //    var entry = _context.Entry(item);
        //    entry.Property(e => e.AwayTeamId).IsModified = true;
        //    entry.Property(e => e.HomeTeamId).IsModified = true;
        //    entry.Property(e => e.SeasonId).IsModified = true;
        //    entry.Property(e => e.WhoScoredDate).IsModified = true;
        //    entry.Property(e => e.WhoScoredMatchId).IsModified = true;
        //    _context.SaveChanges();
        //}
    }
}
