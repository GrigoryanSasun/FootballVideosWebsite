using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootBallVideos.ModelsData;
using FootBallVideos.LogingServcie;
using Microsoft.EntityFrameworkCore;

namespace FootBallVideos.Models
{
    public class VideoRepository : IVideoRepository
    {
        private FootballWebsiteContext _context;
        private LoggerService _logger;

        public VideoRepository(FootballWebsiteContext context, LoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Add(Videos item)
        {
            try
            {
                Videos newItem = item;
                int teamId = (from q in _context.Teams where q.NativeId == item.TeamId select q.Id).FirstOrDefault();
                int seasonId = (from q in _context.Season where q.NativeId == item.SeasonId select q.Id).FirstOrDefault();
                int tournamentId = (from q in _context.Tournaments where q.NativeId == item.TournamentId select q.Id).FirstOrDefault();
                newItem.TeamId = teamId;
                newItem.SeasonId = seasonId;
                newItem.TournamentId = tournamentId;
                _context.Videos.Add(newItem);
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
                            _logger.Add(ex.InnerException.Message, "Videos Add", 1);
                            return false;
                        }
                        else
                        {
                            _logger.Add(ex.Message, "Videos Add", 1);
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

        public async Task<bool> AddAsync(Videos item)
        {
            try
            {
                Videos newItem = item;
                int playerId = (from q in _context.Players where q.NativeId == item.PlayerId select q.Id).FirstOrDefault();
                int teamId = (from q in _context.Teams where q.NativeId == item.TeamId select q.Id).FirstOrDefault();
                int seasonId = (from q in _context.Season where q.NativeId == item.SeasonId select q.Id).FirstOrDefault();
                int tournamentId = (from q in _context.Tournaments where q.NativeId == item.TournamentId select q.Id).FirstOrDefault();
                newItem.TeamId = teamId;
                newItem.SeasonId = seasonId;
                newItem.TournamentId = tournamentId;
                newItem.PlayerId = playerId;
                _context.Videos.Add(newItem);
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
                            await _logger.AddAsync(ex.InnerException.Message, "Videos AddAsync", 1);
                            return false;
                        }
                        else
                        {
                            await _logger.AddAsync(ex.Message, "Videos AddAsync", 1);
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

        public Videos Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Videos> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Videos> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Videos>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Videos> GetVideosByPlayerId(int id)
        {
            var videos = (from q in _context.Videos
                          where q.PlayerId == id
                          select q).ToList();
            return videos;
        }

        public async Task<IEnumerable<Videos>> GetVideosByPlayerIdAsync(int id)
        {
            var videos = (from q in _context.Videos
                          where q.PlayerId == id
                          select q).ToListAsync();
            return await videos;
        }

        public IEnumerable<Videos> GetVideosByTeamId(int id)
        {
            var videos = (from q in _context.Videos
                          where q.TeamId == id
                          select q).ToList();
            return videos;
        }

        public async Task<IEnumerable<Videos>> GetVideosByTeamIdAsync(int id)
        {
            var videos = (from q in _context.Videos
                          where q.TeamId == id
                          select q).ToListAsync();
            return await videos;
        }

        public IEnumerable<Videos> GetVideosByTournamentId(int id)
        {
            var videos = (from q in _context.Videos
                          where q.TournamentId == id
                          select q).ToList();
            return videos;
        }

        public async Task<IEnumerable<Videos>> GetVideosByTournamentIdAsync(int id)
        {
            var videos = (from q in _context.Videos
                          where q.TournamentId == id
                          select q).ToListAsync();
            return await videos;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Videos item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Videos item)
        {
            throw new NotImplementedException();
        }
    }
}
