using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface ISeasonRepository
    {
        void Add(Season item);
        IEnumerable<Season> GetAll();
        Season Find(int key);
        void Remove(int key);
        void Update(Season item);

        Task<IEnumerable<Season>> GetAllAsync();
        Task<Season> FindAsync(int key);
    }
}
