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
        void Add(Players item);
        void Remove(int key);
        void Update(Players item);

        Task<IEnumerable<Players>> GetAllAsync();
        Task<Players> FindAsync(int key);
    }
}
