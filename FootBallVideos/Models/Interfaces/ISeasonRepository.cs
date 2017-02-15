using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface ISeasonRepository
    {
        IEnumerable<Season> GetAll();
        Season Find(int key);
        Task<bool> Add(Season item);
        bool Update(Season item);
        bool Remove(int key);

        Task<IEnumerable<Season>> GetAllAsync();
        Task<Season> FindAsync(int key);
    }
}
