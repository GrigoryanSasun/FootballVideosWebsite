using FootballVideosWebsite.Server.Models;
using FootballVideosWebsite.Server.ModelsData;
using FootballVideosWebsite.Server.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public class SeasonRepository : ISeasonRepository
    {
        private FootballWebsiteContext _context;
        private LoggerService _logger;

        public SeasonRepository(FootballWebsiteContext context, LoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Season> GetAll()
        {
            return _context.Season;
        }

        public async Task<IEnumerable<Season>> GetAllAsync()
        {
            return await _context.Season.ToListAsync();
        }

        public bool Add(Season item)
        {
            try
            {
                _context.Season.Add(item);
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
                            _logger.Add(ex.InnerException.Message, "Season Add", 1);
                            return false;
                        }
                        else
                        {
                            _logger.Add(ex.Message, "Season Add", 1);
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

        public async Task<bool> AddAsync(Season item)
        {
            try
            {
                _context.Season.Add(item);
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
                            await _logger.AddAsync(ex.InnerException.Message, "Season AddAsync", 1);
                            return false;
                        }
                        else
                        {
                            await _logger.AddAsync(ex.Message, "Season AddAsync", 1);
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

        public Season Find(int id)
        {
            try
            {
                return (from b in _context.Season
                        where b.Id == id
                        select b).FirstOrDefault();

            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "Season Find", 1);
                        return null;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "Season Find", 1);
                        return null;
                    }
                }
                else return null;
            }
        }

        public async Task<Season> FindAsync(int id)
        {
            try
            {
                return await (from b in _context.Season
                              where b.Id == id
                              select b).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "Season FindAsync", 1);
                        return null;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "Season FindAsync", 1);
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
                var season = new Season { NativeId = key };
                _context.Season.Attach(season);
                _context.Season.Remove(season);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "Season Remove", 1);
                        return false;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "Season Remove", 1);
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
                var season = new Season { NativeId = key };
                _context.Season.Attach(season);
                _context.Season.Remove(season);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "Season RemoveAsync", 1);
                        return false;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "Season RemoveAsync", 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public bool Update(Season item)
        {
            try
            {
                _context.Season.Attach(item);
                var entry = _context.Entry(item);
                entry.Property(e => e.Name).IsModified = true;
                entry.Property(e => e.NativeId).IsModified = true;
                entry.Property(e => e.StartDate).IsModified = true;
                entry.Property(e => e.EndDate).IsModified = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "Season UpdateAsync", 1);
                        return false;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "Season UpdateAsync", 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(Season item)
        {
            try
            {
                _context.Season.Attach(item);
                var entry = _context.Entry(item);
                entry.Property(e => e.Name).IsModified = true;
                entry.Property(e => e.NativeId).IsModified = true;
                entry.Property(e => e.StartDate).IsModified = true;
                entry.Property(e => e.EndDate).IsModified = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "Season UpdateAsync", 1);
                        return false;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "Season UpdateAsync", 1);
                        return false;
                    }
                }
                else return false;
            }
        }
    }
}
