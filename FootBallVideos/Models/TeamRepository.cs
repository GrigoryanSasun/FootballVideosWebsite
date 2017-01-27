using FootBallVideos.ModelsData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallVideos.Models
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

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Team.ToListAsync();
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

        public async Task<Team> FindAsync(int key)
        {
            return await (from b in _context.Team
                          where b.WhoScoredTeamId == key
                          select b).FirstOrDefaultAsync();
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

        public async Task<IEnumerable<PlayerDetails>> GetPlayersAsync(int id)
        {
            var players = (from p in _context.Players
                           join pp in _context.PlayerProfile on p.Id equals pp.PlayersId
                           where pp.CurrentTeamId == id
                           select new PlayerDetails
                           {
                               name = p.PlayerName,
                               nationalityFlagPosition = pp.NationalityFlagUrl
                           }).ToListAsync();
            return await players;

        }

        public IEnumerable<PlayerDetails> GetPlayers(int id)
        {
            var players = (from p in _context.Players
                           join pp in _context.PlayerProfile on p.Id equals pp.PlayersId
                           where pp.CurrentTeamId == id
                           select new PlayerDetails
                           {
                               name = p.PlayerName,
                               nationalityFlagPosition = pp.NationalityFlagUrl
                           }).ToList();
            return players.ToList();

        }
    }
}
