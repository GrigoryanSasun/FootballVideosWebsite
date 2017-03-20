using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface IMatchRepository
    {
        IEnumerable<Matches> GetAll();
        Task<IEnumerable<Matches>> GetAllAsync();

        Matches Find(int id);
        Task<Matches> FindAsync(int id);

        bool Add(Matches item);
        Task<bool> AddAsync(Matches item);

        bool Remove(int id);
        Task<bool> RemoveAsync(int id);

        bool Update(Matches item);
        Task<bool> UpdateAsync(Matches item);
    }
}
