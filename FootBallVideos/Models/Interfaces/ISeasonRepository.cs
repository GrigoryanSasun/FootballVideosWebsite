using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface ISeasonRepository
    {
        IEnumerable<Season> GetAll();
        Season Find(int key);
        void Remove(int key);
        Task<bool> Add(Season item);
        void Update(Season item);

        Task<IEnumerable<Season>> GetAllAsync();
        Task<Season> FindAsync(int key);
    }
}
