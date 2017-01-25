using FootballAnalyticsAPI.ModelsData;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FootballAnalyticsAPI.Models
{
    public class PlayersRepository : IPlayersRepository
    {
        private FootballAnalyticsContext _context;

        public PlayersRepository(FootballAnalyticsContext context)
        {
            _context = context;
        }

        public IEnumerable<Players> GetAll()
        {
            return _context.Players;
        }

        public async Task<IEnumerable<Players>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public void Add(Players item)
        {
            _context.Players.Add(item);
            _context.SaveChanges();
        }

        public Players Find(int id)
        {
            return (from b in _context.Players
                    where b.WhoScoredPlayerId == id
                    select b).FirstOrDefault();
        }

        public async Task<Players> FindAsync(int id)
        {
            return await (from b in _context.Players
                          where b.WhoScoredPlayerId == id
                          select b).FirstOrDefaultAsync();
        }

        public void Remove(int id)
        {
            var player = new Players { WhoScoredPlayerId = id };
            _context.Players.Attach(player);
            _context.Players.Remove(player);
            _context.SaveChanges();
        }

        public void Update(Players item)
        {
            _context.Players.Attach(item);
            var entry = _context.Entry(item);
            entry.Property(e => e.PlayerName).IsModified = true;
            entry.Property(e => e.WhoScoredPlayerId).IsModified = true;
            entry.Property(e => e.PlayerParticipation).IsModified = true;
            _context.SaveChanges();
        }
        public int GetByTeamId(int id)
        {
            return id;
        }

    }
}
