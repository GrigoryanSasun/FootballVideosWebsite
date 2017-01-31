using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface ITeamRepository
    {
        void Add(Teams item);
        IEnumerable<Teams> GetAll();
        IEnumerable<PlayerDetails> GetPlayers(int id);
        Teams Find(int id);
        void Remove(int id);
        void Update(Teams item);

        Task<IEnumerable<PlayerDetails>> GetPlayersAsync(int id);
        Task<IEnumerable<Teams>> GetAllAsync();
        Task<Teams> FindAsync(int key);
    }
}
