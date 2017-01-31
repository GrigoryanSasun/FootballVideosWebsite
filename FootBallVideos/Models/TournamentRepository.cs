using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FootBallVideos.ModelsData;

namespace FootBallVideos.Models
{
    public class TournamentRepository : ITournamentRepository
    {
        //private FootballAnalyticsContext _context;

        //public TournamentRepository(FootballAnalyticsContext context)
        //{
        //    _context = context;
        //}

        //public IEnumerable<TournamentDetail> GetAll()
        //{
        //    var tournaments = (from t in _context.Tournaments
        //                       join f in _context.Flags on t.FlagId equals f.Id
        //                       select new TournamentDetail
        //                       {
        //                           id = t.Id,
        //                           name = t.WhoScoredTourName,
        //                           nationalityFlagPosition = f.FlagLocation
        //                       }).ToList();
        //    return tournaments;
        //}

        //public async Task<IEnumerable<TournamentDetail>> GetAllAsync()
        //{
        //    var tournaments = (from t in _context.Tournaments
        //                   join f in _context.Flags on t.FlagId equals f.Id
        //                   select new TournamentDetail
        //                   {
        //                       id = t.Id,
        //                       name = t.WhoScoredTourName,
        //                       nationalityFlagPosition = f.FlagLocation
        //                   }).ToListAsync();
        //    return await tournaments;
        //}

        //public void Add(Tournaments item)
        //{
        //    _context.Tournaments.Add(item);
        //    _context.SaveChanges();
        //}

        //public Tournaments Find(int key)
        //{
        //    return (from b in _context.Tournaments
        //            where b.WhoScoredTourId == key
        //            select b).FirstOrDefault();
        //}

        //public async Task<Tournaments> FindAsync(int key)
        //{
        //    return await (from b in _context.Tournaments
        //            where b.WhoScoredTourId == key
        //            select b).FirstOrDefaultAsync();
        //}

        //public void Remove(int key)
        //{
        //    var tour = new Tournaments { WhoScoredTourId = key };
        //    _context.Tournaments.Attach(tour);
        //    _context.Tournaments.Remove(tour);
        //    _context.SaveChanges();
        //}

        //public void Update(Tournaments item)
        //{
        //    _context.Tournaments.Attach(item);
        //    var entry = _context.Entry(item);
        //    entry.Property(e => e.WhoScoredTourName).IsModified = true;
        //    entry.Property(e => e.WhoScoredTourId).IsModified = true;
        //    _context.SaveChanges();
        //}

        //public IEnumerable<Team> GetTeams(int id)
        //{
        //    var teams = (from q in _context.Team
        //                 join m1 in _context.TeamTournamentMap on q.Id equals m1.TeamId
        //                 select q);
        //    return teams.ToList();
            
        //}

        //public async Task<IEnumerable<Team>> GetTeamsAsync(int id)
        //{
        //    var teams = (from t in _context.Team
        //                 join ttm in _context.TeamTournamentMap on t.Id equals ttm.TeamId
        //                 where ttm.TournamentId == id && (from q in _context.TeamTournamentMap
        //                                                  where q.TournamentId == id
        //                                                  select q.SeasonId).Max() == ttm.SeasonId
        //                 select t).ToListAsync();
        //    return await teams;
        //}
    }
}
