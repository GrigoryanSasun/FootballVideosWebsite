using FootballAnalyticsAPI.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAnalyticsAPI.Models
{
    public class TeamRepository : ITeamRepository
    {
        private FootballAnalyticsContext _context;

        public TeamRepository(FootballAnalyticsContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> GetAll()
        {
            return _context.Team;
        }

        public void Add(Team item)
        {
            _context.Team.Add(item);
            _context.SaveChanges();
        }

        public Team Find(int key)
        {
            return (from b in _context.Team
                        where b.WhoScoredTeamId == key
                        select b).FirstOrDefault();
        }

        public void Remove(int key)
        {
            var team = new Team { WhoScoredTeamId = key };
            _context.Team.Attach(team);
            _context.Team.Remove(team);
            _context.SaveChanges();
        }

        public void Update(Team item)
        {
            _context.Team.Attach(item);
            var entry = _context.Entry(item);
            entry.Property(e => e.TeamName).IsModified = true;
            entry.Property(e => e.WhoScoredTeamId).IsModified = true;
            _context.SaveChanges();
        }

        public IEnumerable<Players> GetPlayers(int id)
        {
            var playerParticipationId = (from q in _context.PlayerParticipation
                                         where q.TeamId == id
                                         select q.PlayerId);
            return (from q in _context.Players
                    where playerParticipationId.Any(x=>x == q.Id) 
                    select q);

        }
    }
}
