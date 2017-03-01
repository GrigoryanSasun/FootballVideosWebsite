using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootBallVideos.ModelsData;
using Microsoft.EntityFrameworkCore;

namespace FootBallVideos.Models
{
    public class TeamSeasonTournamentMapRepository : ITeamSeasonTournamentMapRepository
    {
        private FootballWebsiteContext _context;

        public TeamSeasonTournamentMapRepository(FootballWebsiteContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(TeamSeasonTournamentMap item)
        {
            try
            {
                TeamSeasonTournamentMap newItem = item;
                int teamId = (from q in _context.Teams where q.NativeId == item.TeamId select q.Id).FirstOrDefault();
                int seasonId = (from q in _context.Season where q.NativeId == item.SeasonId select q.Id).FirstOrDefault();
                int tournamentId = (from q in _context.Tournaments where q.NativeId == item.TournamentId select q.Id).FirstOrDefault();
                newItem.TeamId = teamId;
                newItem.SeasonId = seasonId;
                newItem.TournamentId = tournamentId;
                _context.TeamSeasonTournamentMap.Add(newItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("UNIQUE") && !ex.InnerException.Message.Contains("UNIQUE"))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public TeamSeasonTournamentMap Find(int id)
        {
            return (from b in _context.TeamSeasonTournamentMap
                    where b.Id == id
                    select b).FirstOrDefault();
        }

        public async Task<TeamSeasonTournamentMap> FindAsync(int id)
        {
            return await (from b in _context.TeamSeasonTournamentMap
                    where b.Id == id
                    select b).FirstOrDefaultAsync();
        }

        public IEnumerable<TeamSeasonTournamentMap> GetAll()
        {
            return _context.TeamSeasonTournamentMap;
        }

        public async Task<IEnumerable<TeamSeasonTournamentMap>> GetAllAsync()
        {
            return await _context.TeamSeasonTournamentMap.ToListAsync();
        }

        public bool Remove(int id)
        {
            try
            {
                var matches = new Matches { NativeId = id };
                _context.Matches.Attach(matches);
                _context.Matches.Remove(matches);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(TeamSeasonTournamentMap item)
        {
            try
            {
                _context.TeamSeasonTournamentMap.Attach(item);
                var entry = _context.Entry(item);
                entry.Property(e => e.SeasonId).IsModified = true;
                entry.Property(e => e.TeamId).IsModified = true;
                entry.Property(e => e.TournamentId).IsModified = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
