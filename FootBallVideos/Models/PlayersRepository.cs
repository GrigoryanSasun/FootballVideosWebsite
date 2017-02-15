using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FootBallVideos.ModelsData;
using System;
using System.Diagnostics;

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

        public async Task<bool> Add(Players item)
        {
            try
            {
                if (item.WhoScoredId == null)
                {                    
                    return Update(item); ;
                }
                else
                {
                    _context.Players.Add(item);
                    await _context.SaveChangesAsync();
                    Debug.WriteLine("Player Inserted: " + item.Id + " : OK");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + " error occured in Player insert");
                if (!ex.Message.Contains("unique") && !ex.InnerException.Message.Contains("unique"))
                {
                    return false;
                } else
                {
                    return true;
                }
            }
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
                Debug.WriteLine(ex.Message + " error occured in Player remove");
                return false;
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
                Debug.WriteLine(ex.Message + " error occured in Player Update");
                return false;
            }
        }
        public int GetByTeamId(int id)
        {
            return id;
        }

    }
}
