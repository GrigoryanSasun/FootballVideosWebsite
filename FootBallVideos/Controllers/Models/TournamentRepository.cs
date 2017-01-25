using FootballAnalyticsAPI.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAnalyticsAPI.Models
{
    public class TournamentRepository : ITournamentRepository
    {
        private FootballAnalyticsContext _context;

        public TournamentRepository(FootballAnalyticsContext context)
        {
            _context = context;
        }

        public IEnumerable<Tournaments> GetAll()
        {
            return _context.Tournaments;
        }

        public void Add(Tournaments item)
        {
            _context.Tournaments.Add(item);
            _context.SaveChanges();
        }

        public Tournaments Find(int key)
        {
            return (from b in _context.Tournaments
                    where b.WhoScoredTourId == key
                    select b).FirstOrDefault();
        }

        public void Remove(int key)
        {
            var tour = new Tournaments { WhoScoredTourId = key };
            _context.Tournaments.Attach(tour);
            _context.Tournaments.Remove(tour);
            _context.SaveChanges();
        }

        public void Update(Tournaments item)
        {
            _context.Tournaments.Attach(item);
            var entry = _context.Entry(item);
            entry.Property(e => e.WhoScoredTourName).IsModified = true;
            entry.Property(e => e.WhoScoredTourId).IsModified = true;
            _context.SaveChanges();
        }

        public IEnumerable<Team> GetTeams(int id)
        {
            var whoScoredId = (from q1 in _context.Tournaments
                          where q1.Id == id
                          select q1.WhoScoredTourId).FirstOrDefault();

            var seasons = (from q2 in _context.Season
                           where q2.TournamentsId == id
                           select q2.Id).ToList();

            var matches = (from q in _context.Match
                           where seasons.Any(x => x == q.SeasonId)
                           select q).ToList();

            var teams = (from q in _context.Team
                         join m1 in matches on q.Id equals m1.HomeTeamId
                         join m2 in matches on q.Id equals m2.AwayTeamId
                         select new Team{
                             TeamName = q.TeamName,
                             Id = q.Id,
                             WhoScoredTeamId = q.WhoScoredTeamId
                     }).GroupBy(x => x.Id).Select(y => y.First());
            return teams;
            
        }
    }
}
