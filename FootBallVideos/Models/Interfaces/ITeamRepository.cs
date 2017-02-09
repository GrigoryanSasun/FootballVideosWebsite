using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface ITeamRepository
    {
        IEnumerable<Teams> GetAll();
        IEnumerable<Players> GetPlayers(int id);
        Teams Find(int id);
        Task<bool> Add(Teams item);
        void Remove(int id);
        void Update(Teams item);

        Task<IEnumerable<Players>> GetPlayersAsync(int id);
        Task<IEnumerable<Teams>> GetAllAsync();
        Task<Teams> FindAsync(int key);
    }
}
