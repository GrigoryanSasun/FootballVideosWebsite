using FootballAnalyticsAPI.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(Players item)
        {
            _context.Players.Add(item);
            _context.SaveChanges();
        }

        public Players Find(int key)
        {
            using (_context)
            {  
                return (from b in _context.Players
                       where b.WhoScoredPlayerId == key
                       select b).FirstOrDefault();
            }
        }

        public void Remove(int key)
        {
            var player = new Players { WhoScoredPlayerId = key };
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
    }
}
