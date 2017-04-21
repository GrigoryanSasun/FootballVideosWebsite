using FootballVideosWebsite.Server.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballVideosWebsite.Server.Models
{
    public interface ISeasonRepository
    {
        IEnumerable<Season> GetAll();
        Task<IEnumerable<Season>> GetAllAsync();

        Season Find(int id);
        Task<Season> FindAsync(int id);

        bool Add(Season item);
        Task<bool> AddAsync(Season item);

        bool Remove(int id);
        Task<bool> RemoveAsync(int id);

        bool Update(Season item);
        Task<bool> UpdateAsync(Season item);
    }
}
