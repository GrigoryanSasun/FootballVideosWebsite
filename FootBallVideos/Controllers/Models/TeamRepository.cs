using FootballAnalyticsAPI.ModelsData;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Players>> GetPlayersAsync(int id)
        {
            var teamId = (from q in _context.Team
                            where q.WhoScoredTeamId == id
                            select q.Id).FirstOrDefault();
            
            var seasons = (from q in _context.Match
                           where q.AwayTeamId == teamId || q.HomeTeamId == teamId
                           select q.SeasonId).ToList();
            var seasonId = (from q in _context.Season
                            where seasons.Any(x=>x == q.Id)
                            orderby q.SeasonTitle descending
                            select q).FirstOrDefault();
            var matches = (from q in _context.Match
                           where q.SeasonId == seasonId.Id && (q.AwayTeamId == teamId || q.HomeTeamId == teamId)
                           select q.Id).ToList();
            var playerParticipationId = (from q in _context.PlayerParticipation
                                         where matches.Any(x => x == q.MatchId) && q.TeamId == id
                                         select q.PlayerId).ToList();
            var players = (from q in _context.Players
                           where playerParticipationId.Any(x => x == q.Id)
                           select q).ToListAsync();
            return await players;

        }

        public IEnumerable<Players> GetPlayers(int id)
        {
            var teamId = (from q in _context.Team
                          where q.WhoScoredTeamId == id
                          select q.Id).FirstOrDefault();

            var seasons = (from q in _context.Match
                           where q.AwayTeamId == teamId || q.HomeTeamId == teamId
                           select q.SeasonId).ToList();
            var seasonId = (from q in _context.Season
                            where seasons.Any(x => x == q.Id)
                            orderby q.SeasonTitle descending
                            select q).FirstOrDefault();
            var matches = (from q in _context.Match
                           where q.SeasonId == seasonId.Id && (q.AwayTeamId == teamId || q.HomeTeamId == teamId)
                           select q.Id).ToList();
            var playerParticipationId = (from q in _context.PlayerParticipation
                                         where matches.Any(x => x == q.MatchId) && q.TeamId == id
                                         select q.PlayerId).ToList();
            var players = (from q in _context.Players
                           where playerParticipationId.Any(x => x == q.Id)
                           select q).ToList();
            return players;

        }
    }
}
