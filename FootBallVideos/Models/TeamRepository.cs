using FootBallVideos.ModelsData;
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

        public TeamRepository(FootballWebsiteContext context)
        {
            _context = context;
        }

        public IEnumerable<Teams> GetAll()
        {
            return _context.Teams;
        }

        public async Task<IEnumerable<Teams>> GetAllAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public void Add(Teams item)
        {
            try
            {
                _context.Teams.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("unique") || ex.InnerException.Message.Contains("unique"))
                {

                }
            }
        }

        public Teams Find(int key)
        {
            return (from b in _context.Teams
                    where b.NativeId == key
                    select b).FirstOrDefault();
        }

        public async Task<Teams> FindAsync(int key)
        {
            return await (from b in _context.Teams
                          where b.NativeId == key
                          select b).FirstOrDefaultAsync();
        }

        public void Remove(int key)
        {
            var team = new Teams { NativeId = key };
            _context.Teams.Attach(team);
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }

        public void Update(Teams item)
        {
            _context.Teams.Attach(item);
            var entry = _context.Entry(item);
            entry.Property(e => e.Name).IsModified = true;
            entry.Property(e => e.NativeId).IsModified = true;
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Players>> GetPlayersAsync(int id)
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
                           }).ToListAsync();
            return await players;

        }

        public IEnumerable<Players> GetPlayers(int id)
        {
            var players = (from p in _context.Players
                           where p.CurrentTeamId == id
                           select p).ToList();
            return players.ToList();

        }
    }
}
