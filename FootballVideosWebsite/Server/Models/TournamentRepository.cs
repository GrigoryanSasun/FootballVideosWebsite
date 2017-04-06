using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FootballVideosWebsite.Server.ModelsData;
using FootballVideosWebsite.Server.Models;
using System;
using FootballVideosWebsite.Server.Services;

namespace FootBallVideos.Models
{
    public class TournamentRepository : ITournamentRepository
    {
        private FootballWebsiteContext _context;
        private LoggerService _logger;

        public TournamentRepository(FootballWebsiteContext context, LoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Tournaments> GetAll()
        {
            return _context.Tournaments;
        }

        public async Task<IEnumerable<Tournaments>> GetAllAsync()
        {
            var tournaments = await _context.Tournaments.ToListAsync();
            return tournaments;
        }

        public bool Add(Tournaments item)
        {
            try
            {
                _context.Tournaments.Add(item);
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
                            _logger.Add(ex.InnerException.Message, "Tournament Add", 1);
                            return false;
                        }
                        else
                        {
                            _logger.Add(ex.Message, "Tournament Add", 1);
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

        public async Task<bool> AddAsync(Tournaments item)
        {
            try
            {
                _context.Tournaments.Add(item);
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
                            await _logger.AddAsync(ex.InnerException.Message, "Tournament AddAsync", 1);
                            return false;
                        }
                        else
                        {
                            await _logger.AddAsync(ex.Message, "Tournament AddAsync", 1);
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

        public Tournaments Find(int id)
        {
            try
            {
                return (from b in _context.Tournaments
                        where b.Id == id
                        select b).FirstOrDefault();

            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "Tournament Find", 1);
                        return null;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "Tournament Find", 1);
                        return null;
                    }
                }
                else return null;
            }
        }

        public async Task<Tournaments> FindAsync(int id)
        {
            try
            {
                return await (from b in _context.Tournaments
                              where b.Id == id
                              select b).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "Tournament FindAsync", 1);
                        return null;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "Tournament FindAsync", 1);
                        return null;
                    }
                }
                else return null;
            }
        }

        public bool Remove(int key)
        {
            try
            {
                var tour = new Tournaments { NativeId = key };
                _context.Tournaments.Attach(tour);
                _context.Tournaments.Remove(tour);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "Tournament Remove", 1);
                        return false;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "Tournament Remove", 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public async Task<bool> RemoveAsync(int key)
        {
            try
            {
                var tour = new Tournaments { NativeId = key };
                _context.Tournaments.Attach(tour);
                _context.Tournaments.Remove(tour);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "Tournament RemoveAsync", 1);
                        return false;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "Tournament RemoveAsync", 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public bool Update(Tournaments item)
        {
            try
            {
                _context.Tournaments.Attach(item);
                var entry = _context.Entry(item);
                entry.Property(e => e.Name).IsModified = true;
                entry.Property(e => e.NativeId).IsModified = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "Tournament Update", 1);
                        return false;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "Tournament Update", 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(Tournaments item)
        {
            try
            {
                _context.Tournaments.Attach(item);
                var entry = _context.Entry(item);
                entry.Property(e => e.Name).IsModified = true;
                entry.Property(e => e.NativeId).IsModified = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "Tournament UpdateAsync", 1);
                        return false;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "Tournament UpdateAsync", 1);
                        return false;
                    }
                }
                else return false;
            }
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
