using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface IPlayersRepository
    {
        IEnumerable<Players> GetAll();
        int GetByTeamId(int id);
        Players Find(int key);
        Task<bool> Add(Players item);
        bool Remove(int key);
        bool Update(Players item);

        Task<IEnumerable<Players>> GetAllAsync();
        Task<Players> FindAsync(int key);
    }
}
