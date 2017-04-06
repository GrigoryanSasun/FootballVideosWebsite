using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballVideosWebsite.Server.ModelsData;
using FootballVideosWebsite.Server.Models;
using Microsoft.EntityFrameworkCore;
using FootballVideosWebsite.Server.Services;

namespace FootBallVideos.Models
{
    public class TeamSeasonTournamentMapRepository : ITeamSeasonTournamentMapRepository
    {
        private FootballWebsiteContext _context;
        private LoggerService _logger;

        public TeamSeasonTournamentMapRepository(FootballWebsiteContext context, LoggerService logger)
        {
            _context = context;
            _logger = logger;
        }


        public IEnumerable<TeamSeasonTournamentMap> GetAll()
        {
            return _context.TeamSeasonTournamentMap;
        }

        public async Task<IEnumerable<TeamSeasonTournamentMap>> GetAllAsync()
        {
            return await _context.TeamSeasonTournamentMap.ToListAsync();
        }

        public bool Add(TeamSeasonTournamentMap item)
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
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("UNIQUE") && !ex.InnerException.Message.Contains("UNIQUE"))
                {
                    if (_logger.DetachAll(_context))
                    {
                        if (ex.Message.Contains("inner exception"))
                        {
                            _logger.Add(ex.InnerException.Message, "TeamSeasonTournamentMap Add", 1);
                            return false;
                        }
                        else
                        {
                            _logger.Add(ex.Message, "TeamSeasonTournamentMap Add", 1);
                            return false;
                        }
                    }
                    else return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public async Task<bool> AddAsync(TeamSeasonTournamentMap item)
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
                    if (_logger.DetachAll(_context))
                    {
                        if (ex.Message.Contains("inner exception"))
                        {
                            await _logger.AddAsync(ex.InnerException.Message, "TeamSeasonTournamentMap AddAsync", 1);
                            return false;
                        }
                        else
                        {
                            await _logger.AddAsync(ex.Message, "TeamSeasonTournamentMap AddAsync", 1);
                            return false;
                        }
                    }
                    else return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public TeamSeasonTournamentMap Find(int id)
        {
            try
            {
                return (from b in _context.TeamSeasonTournamentMap
                        where b.Id == id
                        select b).FirstOrDefault();
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "TeamSeasonTournamentMap Find", 1);
                        return null;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "TeamSeasonTournamentMap Find", 1);
                        return null;
                    }
                }
                else return null;
            }            
        }

        public async Task<TeamSeasonTournamentMap> FindAsync(int id)
        {
            try
            {
                return await (from b in _context.TeamSeasonTournamentMap
                              where b.Id == id
                              select b).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "TeamSeasonTournamentMap FindAsync", 1);
                        return null;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "TeamSeasonTournamentMap FindAsync", 1);
                        return null;
                    }
                }
                else return null;
            }
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
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "TeamSeasonTournamentMap Remove", 1);
                        return false;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "TeamSeasonTournamentMap Remove", 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                var matches = new Matches { NativeId = id };
                _context.Matches.Attach(matches);
                _context.Matches.Remove(matches);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "TeamSeasonTournamentMap RemoveAsync", 1);
                        return false;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "TeamSeasonTournamentMap RemoveAsync", 1);
                        return false;
                    }
                }
                else return false;
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
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "TeamSeasonTournamentMap Update", 1);
                        return false;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "TeamSeasonTournamentMap Update", 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(TeamSeasonTournamentMap item)
        {
            try
            {
                _context.TeamSeasonTournamentMap.Attach(item);
                var entry = _context.Entry(item);
                entry.Property(e => e.SeasonId).IsModified = true;
                entry.Property(e => e.TeamId).IsModified = true;
                entry.Property(e => e.TournamentId).IsModified = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "TeamSeasonTournamentMap UpdateAsync", 1);
                        return false;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "TeamSeasonTournamentMap UpdateAsync", 1);
                        return false;
                    }
                }
                else return false;
            }
        }
    }
}
