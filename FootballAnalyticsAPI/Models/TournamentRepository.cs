﻿using FootballAnalyticsAPI.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAnalyticsAPI.Models
{
    public class TournamentRepository : ITournamentRepository
    {
        private FootballAnalyticsContext _context;

        public TournamentRepository(FootballAnalyticsContext context)
        {
            _context = context;
        }

        public IEnumerable<Tournaments> GetAll()
        {
            return _context.Tournaments;
        }

        public void Add(Tournaments item)
        {
            _context.Tournaments.Add(item);
            _context.SaveChanges();
        }

        public Tournaments Find(int key)
        {
            return (from b in _context.Tournaments
                    where b.WhoScoredTourId == key
                    select b).FirstOrDefault();
        }

        public void Remove(int key)
        {
            var tour = new Tournaments { WhoScoredTourId = key };
            _context.Tournaments.Attach(tour);
            _context.Tournaments.Remove(tour);
            _context.SaveChanges();
        }

        public void Update(Tournaments item)
        {
            _context.Tournaments.Attach(item);
            var entry = _context.Entry(item);
            entry.Property(e => e.WhoScoredTourName).IsModified = true;
            entry.Property(e => e.WhoScoredTourId).IsModified = true;
            _context.SaveChanges();
        }
    }
}