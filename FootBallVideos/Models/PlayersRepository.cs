using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FootBallVideos.ModelsData;

namespace FootBallVideos.Models
{
    public class PlayersRepository : IPlayersRepository
    {
        private FootballWebsiteContext _context;

        public PlayersRepository(FootballWebsiteContext context)
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
                    where b.NativeId == id
                    select b).FirstOrDefault();
        }

        public async Task<Players> FindAsync(int id)
        {
            return await (from b in _context.Players
                          where b.NativeId == id
                          select b).FirstOrDefaultAsync();
        }

        public void Remove(int id)
        {
            var player = new Players { NativeId = id };
            _context.Players.Attach(player);
            _context.Players.Remove(player);
            _context.SaveChanges();
        }

        public void Update(Players item)
        {
            _context.Players.Attach(item);
            var entry = _context.Entry(item);
            entry.Property(e => e.Name).IsModified = true;
            entry.Property(e => e.NativeId).IsModified = true;
            entry.Property(e => e.Nationality).IsModified = true;
            entry.Property(e => e.HeightInCm).IsModified = true;
            entry.Property(e => e.CurrentShirtNumber).IsModified = true;
            entry.Property(e => e.CurrentTeamId).IsModified = true;
            entry.Property(e => e.IconPosition).IsModified = true;
            entry.Property(e => e.PortraitUrl).IsModified = true;
            entry.Property(e => e.WeightInKg).IsModified = true;
            _context.SaveChanges();
        }
        public int GetByTeamId(int id)
        {
            return id;
        }

    }
}
