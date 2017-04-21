using FootballVideosWebsite.Server.Services;
using FootballVideosWebsite.Server.ModelsData;
using FootballVideosWebsite.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public class TeamRepository : ITeamRepository
    {
        private FootballWebsiteContext _context;
        private LoggerService _logger;

        public TeamRepository(FootballWebsiteContext context, LoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Teams> GetAll()
        {
            return _context.Teams;
        }

        public async Task<IEnumerable<Teams>> GetAllAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public bool Add(Teams item)
        {
            try
            {
                _context.Teams.Add(item);
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
                            _logger.Add(ex.InnerException.Message, "Team Add", 1);
                            return false;
                        }
                        else
                        {
                            _logger.Add(ex.Message, "Team Add", 1);
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

        public async Task<bool> AddAsync(Teams item)
        {
            try
            {
                _context.Teams.Add(item);
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
                            await _logger.AddAsync(ex.InnerException.Message, "Team AddAsync", 1);
                            return false;
                        }
                        else
                        {
                            await _logger.AddAsync(ex.Message, "Team AddAsync", 1);
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

        public Teams Find(int id)
        {
            try
            {
                return (from b in _context.Teams
                        where b.Id == id
                        select b).FirstOrDefault();

            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "Team Find", 1);
                        return null;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "Team Find", 1);
                        return null;
                    }
                }
                else return null;
            }

        }

        public async Task<Teams> FindAsync(int id)
        {
            try
            {
                return await (from b in _context.Teams
                              where b.Id == id
                              select b).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "Team FindAsync", 1);
                        return null;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "Team FindAsync", 1);
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
                var team = new Teams { NativeId = key };
                _context.Teams.Attach(team);
                _context.Teams.Remove(team);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "Team Remove", 1);
                        return false;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "Team Remove", 1);
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
                var team = new Teams { NativeId = key };
                _context.Teams.Attach(team);
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "Team RemoveAsync", 1);
                        return false;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "Team RemoveAsync", 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public bool Update(Teams item)
        {
            try
            {
                _context.Teams.Attach(item);
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
                        _logger.Add(ex.InnerException.Message, "Team Update", 1);
                        return false;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "Team Update", 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(Teams item)
        {
            try
            {
                _context.Teams.Attach(item);
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
                        await _logger.AddAsync(ex.InnerException.Message, "Team UpdateAsync", 1);
                        return false;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "Team UpdateAsync", 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public IEnumerable<Players> GetPlayers(int id)
        {
            var players = (from p in _context.Players
                           where p.CurrentTeamId == id
                           select new Players
                           {
                               Name = p.Name,
                               Position = p.Position,
                               IconPosition = p.IconPosition,
                               HeightInCm = p.HeightInCm,
                               WeightInKg = p.WeightInKg,
                               Nationality = p.Nationality,
                               PortraitUrl = p.PortraitUrl,
                               CurrentShirtNumber = p.CurrentShirtNumber,
                               Age = p.Age
                           }).ToList();
            return players;

        }

        public async Task<IEnumerable<Players>> GetPlayersAsync(int id)
        {
            var players = (from p in _context.Players
                           where p.NativeId == id
                           select new Players
                           {
                               Name = p.Name,
                               Position = p.Position,
                               IconPosition = p.IconPosition,
                               HeightInCm = p.HeightInCm,
                               WeightInKg = p.WeightInKg,
                               Nationality = p.Nationality,
                               PortraitUrl = p.PortraitUrl,
                               CurrentShirtNumber = p.CurrentShirtNumber,
                               Age = p.Age
                           }).ToListAsync();
            return await players;

        }

    }
}
