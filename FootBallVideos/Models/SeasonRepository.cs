using FootBallVideos.ModelsData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public class SeasonRepository : ISeasonRepository
    {
        private FootballWebsiteContext _context;

        public SeasonRepository(FootballWebsiteContext context)
        {
            _context = context;
        }

        public IEnumerable<Season> GetAll()
        {
            return _context.Season;
        }

        public async Task<IEnumerable<Season>> GetAllAsync()
        {
            return await _context.Season.ToListAsync();
        }

        public async Task<bool> Add(Season item)
        {
            try
            {
                _context.Season.Add(item);
                await _context.SaveChangesAsync();
                Debug.WriteLine("Season: " + item.Id + " : OK");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + " error occured in Season insert");
                if (!ex.Message.Contains("unique") && !ex.InnerException.Message.Contains("unique"))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public Season Find(int key)
        {
            return (from b in _context.Season
                    where b.NativeId == key
                    select b).FirstOrDefault();
        }

        public async Task<Season> FindAsync(int key)
        {
            return await (from b in _context.Season
                          where b.NativeId == key
                          select b).FirstOrDefaultAsync();
        }

        public bool Remove(int key)
        {
            try
            {
                var season = new Season { NativeId = key };
                _context.Season.Attach(season);
                _context.Season.Remove(season);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + " error occured in Season remove");
                return false;
            }
        }

        public bool Update(Season item)
        {
            try
            {
                _context.Season.Attach(item);
                var entry = _context.Entry(item);
                entry.Property(e => e.Name).IsModified = true;
                entry.Property(e => e.NativeId).IsModified = true;
                entry.Property(e => e.StartDate).IsModified = true;
                entry.Property(e => e.EndDate).IsModified = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + " error occured in Season Update");
                return false;
            }
        }

        IEnumerable<Season> ISeasonRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        Season ISeasonRepository.Find(int key)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Season>> ISeasonRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Season> ISeasonRepository.FindAsync(int key)
        {
            throw new NotImplementedException();
        }
    }
}
