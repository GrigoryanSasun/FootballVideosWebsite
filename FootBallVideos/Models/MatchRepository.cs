using FootBallVideos.ModelsData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public class MatchRepository : IMatchRepository
    {
        private FootballWebsiteContext _context;

        public MatchRepository(FootballWebsiteContext context)
        {
            _context = context;
        }

        public IEnumerable<Matches> GetAll()
        {
            return _context.Matches;
        }

        public async Task<IEnumerable<Matches>> GetAllAsync()
        {
            return await _context.Matches.ToListAsync();
        }

        public void Add(Matches item)
        {
            try
            {
                _context.Matches.Add(item);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                if (!ex.Message.Contains("unique") || ex.InnerException.Message.Contains("unique"))
                {

                }
            }
        }

        public Matches Find(int id)
        {
            return (from b in _context.Matches
                    where b.NativeId == id
                    select b).FirstOrDefault();
        }

        public async Task<Matches> FindAsync(int id)
        {
            return await (from b in _context.Matches
                          where b.NativeId == id
                          select b).FirstOrDefaultAsync();
        }

        public void Remove(int id)
        {
            var matches = new Matches { NativeId = id };
            _context.Matches.Attach(matches);
            _context.Matches.Remove(matches);
            _context.SaveChanges();
        }

        public void Update(Matches item)
        {
            _context.Matches.Attach(item);
            var entry = _context.Entry(item);
            entry.Property(e => e.AwayTeamId).IsModified = true;
            entry.Property(e => e.HomeTeamId).IsModified = true;
            entry.Property(e => e.Date).IsModified = true;
            entry.Property(e => e.NativeId).IsModified = true;
            entry.Property(e => e.SeasonId).IsModified = true;
            _context.SaveChanges();
        }
        public int GetByTeamId(int id)
        {
            return id;
        }
    }
}
