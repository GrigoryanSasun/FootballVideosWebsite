using FootBallVideos.ModelsData;
using System.Collections.Generic;
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

        Task<IEnumerable<PlayerParticipation>> GetAllAsync();
        Task<PlayerParticipation> FindAsync(int key);
    }
}
