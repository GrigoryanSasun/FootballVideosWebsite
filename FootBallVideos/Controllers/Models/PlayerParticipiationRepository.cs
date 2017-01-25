using FootballAnalyticsAPI.ModelsData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAnalyticsAPI.Models
{
    public class PlayerParticipiationRepository : IPlayerParticipiationRepository
    {
        private FootballAnalyticsContext _context;

        public PlayerParticipiationRepository(FootballAnalyticsContext context)
        {
            _context = context;
        }

        public IEnumerable<PlayerParticipation> GetAll()
        {
            return _context.PlayerParticipation;
        }

        public async Task<IEnumerable<PlayerParticipation>> GetAllAsync()
        {
            return await _context.PlayerParticipation.ToListAsync();
        }

        public void Add(PlayerParticipation item)
        {
            _context.PlayerParticipation.Add(item);
            _context.SaveChanges();
        }

        public PlayerParticipation Find(int id)
        {
            return (from b in _context.PlayerParticipation
                    where b.Id == id
                    select b).FirstOrDefault();
        }

        public async Task<PlayerParticipation> FindAsync(int id)
        {
            return await (from b in _context.PlayerParticipation
                          where b.Id == id
                          select b).FirstOrDefaultAsync();
        }

        public void Remove(int id)
        {
            var playerParticipation = new PlayerParticipation { Id = id };
            _context.PlayerParticipation.Attach(playerParticipation);
            _context.PlayerParticipation.Remove(playerParticipation);
            _context.SaveChanges();
        }

        public void Update(PlayerParticipation item)
        {
            _context.PlayerParticipation.Attach(item);
            var entry = _context.Entry(item);
            entry.Property(e => e.MatchId).IsModified = true;
            entry.Property(e => e.PlayerId).IsModified = true;
            entry.Property(e => e.Played).IsModified = true;
            entry.Property(e => e.Score).IsModified = true;
            entry.Property(e => e.Position).IsModified = true;
            _context.SaveChanges();
        }
    }
}
