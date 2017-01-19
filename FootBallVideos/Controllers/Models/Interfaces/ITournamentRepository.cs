using FootballAnalyticsAPI.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAnalyticsAPI.Models
{
    public interface ITournamentRepository
    {
        void Add(Tournaments item);
        IEnumerable<Tournaments> GetAll();
        Tournaments Find(int key);
        void Remove(int key);
        void Update(Tournaments item);
    }
}
