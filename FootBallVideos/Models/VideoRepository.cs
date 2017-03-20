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
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(Videos item)
        {
            throw new NotImplementedException();
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
