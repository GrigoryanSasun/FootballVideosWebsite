using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FootballVideosWebsite.Server.ModelsData;
using System;
using FootballVideosWebsite.Server.Services;

namespace FootballVideosWebsite.Server.Models
{
    public class PlayersRepository : IPlayersRepository
    {
        private FootballWebsiteContext _context;
        private LoggerService _logger;

        public PlayersRepository(FootballWebsiteContext context,LoggerService logger)
        {
            _context = context;
            _logger = logger;
        }


        public IEnumerable<Players> GetAll()
        {
            return _context.Players;
        }

        public async Task<IEnumerable<Players>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public bool Add(Players item)
        {
            try
            {
                if (item.WhoScoredId == null)
                {
                    return Update(item);
                }
                else
                {
                    _context.Players.Add(item);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("UNIQUE") && !ex.InnerException.Message.Contains("UNIQUE"))
                {
                    if (_logger.DetachAll(_context))
                    {
                        if (ex.Message.Contains("inner exception"))
                        {
                            _logger.Add(ex.InnerException.Message, "Player Add", 1);
                            return false;
                        }
                        else
                        {
                            _logger.Add(ex.Message, "Player Add", 1);
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

        public async Task<bool> AddAsync(Players item)
        {
            try
            {
                if (item.WhoScoredId == null)
                {
                    return Update(item);
                }
                else
                {
                    _context.Players.Add(item);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("UNIQUE") && !ex.InnerException.Message.Contains("UNIQUE"))
                {
                    if (_logger.DetachAll(_context))
                    {
                        if (ex.Message.Contains("inner exception"))
                        {
                            await _logger.AddAsync(ex.InnerException.Message, "Player AddAsync", 1);
                            return false;
                        }
                        else
                        {
                            await _logger.AddAsync(ex.Message, "Player AddAsync", 1);
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

        public Players Find(int id)
        {
            try
            {
                return (from b in _context.Players
                        where b.Id == id
                        select b).FirstOrDefault();

            } catch(Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "Player Find", 1);
                        return null;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "Player Find", 1);
                        return null;
                    }
                }
                else return null;
            }
        }

        public async Task<Players> FindAsync(int id)
        {
            try
            {
                return await (from b in _context.Players
                              where b.Id == id
                              select b).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "Player FindAsync", 1);
                        return null;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "Player FindAsync", 1);
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
                var player = new Players { NativeId = id };
                _context.Players.Attach(player);
                _context.Players.Remove(player);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "Player Remove", 1);
                        return false;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "Player Remove", 1);
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
                var player = new Players { NativeId = id };
                _context.Players.Attach(player);
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "Player RemoveAsync", 1);
                        return false;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "Player Async", 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public bool Update(Players item)
        {
            try
            {
                var itemOrigin = (from q in _context.Players where q.NativeId == item.NativeId select q).FirstOrDefault();
                itemOrigin.NativeId = item.NativeId;
                itemOrigin.Nationality = item.Nationality;
                itemOrigin.HeightInCm = item.HeightInCm;
                itemOrigin.WeightInKg = item.WeightInKg;
                itemOrigin.CurrentShirtNumber = item.CurrentShirtNumber;
                itemOrigin.CurrentTeamId = item.CurrentTeamId;
                itemOrigin.IconPosition = item.IconPosition;
                itemOrigin.PortraitUrl = item.PortraitUrl;
                itemOrigin.Age = item.Age;
                itemOrigin.Position = item.Position;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        _logger.Add(ex.InnerException.Message, "Player Update", 1);
                        return false;
                    }
                    else
                    {
                        _logger.Add(ex.Message, "Player Update", 1);
                        return false;
                    }
                }
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(Players item)
        {
            try
            {
                var itemOrigin = (from q in _context.Players where q.NativeId == item.NativeId select q).FirstOrDefault();
                itemOrigin.NativeId = item.NativeId;
                itemOrigin.Nationality = item.Nationality;
                itemOrigin.HeightInCm = item.HeightInCm;
                itemOrigin.WeightInKg = item.WeightInKg;
                itemOrigin.CurrentShirtNumber = item.CurrentShirtNumber;
                itemOrigin.CurrentTeamId = item.CurrentTeamId;
                itemOrigin.IconPosition = item.IconPosition;
                itemOrigin.PortraitUrl = item.PortraitUrl;
                itemOrigin.Age = item.Age;
                itemOrigin.Position = item.Position;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                if (_logger.DetachAll(_context))
                {
                    if (ex.Message.Contains("inner exception"))
                    {
                        await _logger.AddAsync(ex.InnerException.Message, "Player UpdateAsync", 1);
                        return false;
                    }
                    else
                    {
                        await _logger.AddAsync(ex.Message, "Player UpdateAsync", 1);
                        return false;
                    }
                }
                else return false;
            }
        }
    }
}
