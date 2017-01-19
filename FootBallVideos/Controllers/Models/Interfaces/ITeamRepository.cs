using FootballAnalyticsAPI.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAnalyticsAPI.Models
{
    public interface ITeamRepository
    {
        void Add(Team item);
        IEnumerable<Team> GetAll();
        IEnumerable<Players> GetPlayers(int id);
        Team Find(int id);
        void Remove(int id);
        void Update(Team item);
    }
}
