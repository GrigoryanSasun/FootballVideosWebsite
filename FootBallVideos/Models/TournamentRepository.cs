using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FootBallVideos.ModelsData;
using System;

namespace FootBallVideos.Models
{
    public class TournamentRepository : ITournamentRepository
    {
        private FootballWebsiteContext _context;

        public TournamentRepository(FootballWebsiteContext context)
        {
            _context = context;
        }

        public IEnumerable<Tournaments> GetAll()
        {
            var tournaments = (from t in _context.Tournaments
                               select t).ToList();
            return tournaments;
        }

        public async Task<IEnumerable<Tournaments>> GetAllAsync()
        {
            var tournaments = (from t in _context.Tournaments
                               select t).ToListAsync();
            return await tournaments;
        }

        public void Add(Tournaments item)
        {
            try
            {
                _context.Tournaments.Add(item);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("unique"))
                {

                }
            }
        }

        public Tournaments Find(int key)
        {
            return (from b in _context.Tournaments
                    where b.NativeId == key
                    select b).FirstOrDefault();
        }

        public async Task<Tournaments> FindAsync(int key)
        {
            return await (from b in _context.Tournaments
                          where b.NativeId == key
                          select b).FirstOrDefaultAsync();
        }

        public void Remove(int key)
        {
            var tour = new Tournaments { NativeId = key };
            _context.Tournaments.Attach(tour);
            _context.Tournaments.Remove(tour);
            _context.SaveChanges();
        }

        public void Update(Tournaments item)
        {
            _context.Tournaments.Attach(item);
            var entry = _context.Entry(item);
            entry.Property(e => e.Name).IsModified = true;
            entry.Property(e => e.NativeId).IsModified = true;
            _context.SaveChanges();
        }

        public IEnumerable<Teams> GetTeams(int id)
        {
            var teams = (from t in _context.Teams
                         join ttm in _context.TeamSeasonTournamentMap on t.Id equals ttm.TeamId
                         where ttm.TournamentId == id && (from q in _context.TeamSeasonTournamentMap
                                                          where q.TournamentId == id
                                                          select q.SeasonId).Max() == ttm.SeasonId
                         select t).ToList();
            return teams;

        }

        public async Task<IEnumerable<Teams>> GetTeamsAsync(int id)
        {
            var teams = (from t in _context.Teams
                         join ttm in _context.TeamSeasonTournamentMap on t.Id equals ttm.TeamId
                         where ttm.TournamentId == id && (from q in _context.TeamSeasonTournamentMap
                                                          where q.TournamentId == id
                                                          select q.SeasonId).Max() == ttm.SeasonId
                         select t).ToListAsync();
            return await teams;
        }
    }
}
