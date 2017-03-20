using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface ITeamRepository
    {
        IEnumerable<Teams> GetAll();
        Task<IEnumerable<Teams>> GetAllAsync();

        Teams Find(int id);
        Task<Teams> FindAsync(int id);

        bool Add(Teams item);
        Task<bool> AddAsync(Teams item);

        bool Remove(int id);
        Task<bool> RemoveAsync(int id);

        bool Update(Teams item);
        Task<bool> UpdateAsync(Teams item);

        IEnumerable<Players> GetPlayers(int id);
        Task<IEnumerable<Players>> GetPlayersAsync(int id);
    }
}
