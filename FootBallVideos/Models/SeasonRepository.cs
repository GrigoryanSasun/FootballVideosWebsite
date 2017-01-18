using FootballAnalyticsAPI.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAnalyticsAPI.Models
{
    public class SeasonRepository : ISeasonRepository
    {
        private FootballAnalyticsContext _context;

        public SeasonRepository(FootballAnalyticsContext context)
        {
            _context = context;
        }

        public IEnumerable<Season> GetAll()
        {
            return _context.Season;
        }

        public void Add(Season item)
        {
            _context.Season.Add(item);
            _context.SaveChanges();
        }

        public Season Find(int key)
        {
            return (from b in _context.Season
                    where b.WhoScoredSeasonId == key
                    select b).FirstOrDefault();
        }

        public void Remove(int key)
        {
            var season = new Season { WhoScoredSeasonId = key };
            _context.Season.Attach(season);
            _context.Season.Remove(season);
            _context.SaveChanges();
        }

        public void Update(Season item)
        {
            _context.Season.Attach(item);
            var entry = _context.Entry(item);
            entry.Property(e => e.SeasonTitle).IsModified = true;
            entry.Property(e => e.WhoScoredSeasonId).IsModified = true;
            entry.Property(e => e.TournamentsId).IsModified = true;
            _context.SaveChanges();
        }
    }
}
