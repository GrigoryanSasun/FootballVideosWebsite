using FootBallVideos.ModelsData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootBallVideos;
using System.Diagnostics;
using FootBallVideos.LogingServcie;

namespace FootBallVideos.Models
{
    public class MatchRepository : IMatchRepository
    {
        private FootballWebsiteContext _context;
        private LoggerService _logger;

        public MatchRepository(FootballWebsiteContext context, LoggerService logger)
        {
            _context = context;
            _logger = logger;
        }


        public IEnumerable<Matches> GetAll()
        {
            return _context.Matches;
        }

        public async Task<IEnumerable<Matches>> GetAllAsync()
        {
            return await _context.Matches.ToListAsync();
        }

        public bool Add(Matches item)
        {
            try
            {
                Matches newItem = item;
                int HomeTeamId = (from q in _context.Teams where q.NativeId == item.HomeTeamId select q.Id).FirstOrDefault();
                int AwayTeamId = (from q in _context.Teams where q.NativeId == item.AwayTeamId select q.Id).FirstOrDefault();
                int SeasonId = (from q in _context.Season where q.NativeId == item.SeasonId select q.Id).FirstOrDefault();
                newItem.HomeTeamId = HomeTeamId;
                newItem.AwayTeamId = AwayTeamId;
                newItem.SeasonId = SeasonId;
                _context.Matches.Add(newItem);
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
                            _logger.Add(ex.InnerException.Message, 1);
                            return false;
                        }
                        else
                        {
                            _logger.Add(ex.Message, 1);
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

        public async Task<bool> AddAsync(Matches item)
        {
            try
            {
                Matches newItem = item;
                int HomeTeamId = (from q in _context.Teams where q.NativeId == item.HomeTeamId select q.Id).FirstOrDefault();
                int AwayTeamId = (from q in _context.Teams where q.NativeId == item.AwayTeamId select q.Id).FirstOrDefault();
                int SeasonId = (from q in _context.Season where q.NativeId == item.SeasonId select q.Id).FirstOrDefault();
                newItem.HomeTeamId = HomeTeamId;
                newItem.AwayTeamId = AwayTeamId;
                newItem.SeasonId = SeasonId;
                _context.Matches.Add(newItem);
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
                            await _logger.AddAsync(ex.InnerException.Message, 1);
                            return false;
                        }
                        else
                        {
                            await _logger.AddAsync(ex.Message, 1);
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

        public Matches Find(int id)
        {
            try
            {
                return (from b in _context.Matches
                        where b.NativeId == id
                        select b).FirstOrDefault();
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, 1);
                        return null;
                    }
                    else
                    {
                        _logger.Add(ex.Message, 1);
                        return null;
                    }
                }
                else return null;
            }
        }

        public async Task<Matches> FindAsync(int id)
        {
            try
            {
                return await (from b in _context.Matches
                              where b.NativeId == id
                              select b).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, 1);
                        return null;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, 1);
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
                var matches = new Matches { Id = id };
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
                        _logger.Add(ex.InnerException.Message, 1);
                        return false;
                    }
                    else
                    {
                        _logger.Add(ex.Message, 1);
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
                var matches = new Matches { Id = id };
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
                        await _logger.AddAsync(ex.InnerException.Message, 1);
                        return false;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public bool Update(Matches item)
        {
            try
            {
                _context.Matches.Attach(item);
                var entry = _context.Entry(item);
                entry.Property(e => e.AwayTeamId).IsModified = true;
                entry.Property(e => e.HomeTeamId).IsModified = true;
                entry.Property(e => e.Date).IsModified = true;
                entry.Property(e => e.NativeId).IsModified = true;
                entry.Property(e => e.SeasonId).IsModified = true;
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, 1);
                        return false;
                    }
                    else
                    {
                        _logger.Add(ex.Message, 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(Matches item)
        {
            try
            {
                _context.Matches.Attach(item);
                var entry = _context.Entry(item);
                entry.Property(e => e.AwayTeamId).IsModified = true;
                entry.Property(e => e.HomeTeamId).IsModified = true;
                entry.Property(e => e.Date).IsModified = true;
                entry.Property(e => e.NativeId).IsModified = true;
                entry.Property(e => e.SeasonId).IsModified = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, 1);
                        return false;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, 1);
                        return false;
                    }
                }
                else return false;
            }
        }
    }
}
