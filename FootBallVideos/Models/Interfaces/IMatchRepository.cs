using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface IMatchRepository
    {
        IEnumerable<Matches> GetAll();
        Matches Find(int key);
        Task<bool> Add(Matches item);
        bool Remove(int key);
        bool Update(Matches item);

        Task<IEnumerable<Matches>> GetAllAsync();
        Task<Matches> FindAsync(int key);
    }
}
