using FootballVideosWebsite.Server.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballVideosWebsite.Server.Models
{
    public interface IPlayersRepository
    {
        IEnumerable<Players> GetAll();
        Task<IEnumerable<Players>> GetAllAsync();

        Players Find(int id);
        Task<Players> FindAsync(int id);

        bool Add(Players item);
        Task<bool> AddAsync(Players item);

        bool Remove(int id);
        Task<bool> RemoveAsync(int id);

        bool Update(Players item);
        Task<bool> UpdateAsync(Players item);
    }
}
