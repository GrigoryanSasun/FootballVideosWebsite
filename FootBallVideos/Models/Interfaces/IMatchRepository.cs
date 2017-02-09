using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface IMatchRepository
    {
        IEnumerable<Matches> GetAll();
        Matches Find(int key);
        void Remove(int key);
        void Update(Matches item);
        Task<bool> Add(Matches item);

        Task<IEnumerable<Matches>> GetAllAsync();
        Task<Matches> FindAsync(int key);
    }
}
