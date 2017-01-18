using FootballAnalyticsAPI.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAnalyticsAPI.Models
{
    public interface IPlayerParticipiationRepository
    {
        void Add(PlayerParticipation item);
        IEnumerable<PlayerParticipation> GetAll();
        PlayerParticipation Find(int key);
        void Remove(int key);
        void Update(PlayerParticipation item);
    }
}
