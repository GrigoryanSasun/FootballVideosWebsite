﻿using FootBallVideos.ModelsData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallVideos.Models
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

        public async Task<IEnumerable<Season>> GetAllAsync()
        {
            return await _context.Season.ToListAsync();
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

        public async Task<Season> FindAsync(int key)
        {
            return await (from b in _context.Season
                          where b.WhoScoredSeasonId == key
                          select b).FirstOrDefaultAsync();
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