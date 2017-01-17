using FootballAnalyticsAPI.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAnalyticsAPI.Models
{
    public interface IPlayersRepository
    {
        void Add(Players item);
        IEnumerable<Players> GetAll();
        Players Find(int key);
        void Remove(int key);
        void Update(Players item);
        int GetByTeamId(int id);
    }
}
