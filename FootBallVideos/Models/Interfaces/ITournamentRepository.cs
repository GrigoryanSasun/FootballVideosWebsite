using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface ITournamentRepository
    {
        IEnumerable<Tournaments> GetAll();
        Task<IEnumerable<Tournaments>> GetAllAsync();

        Tournaments Find(int id);
        Task<Tournaments> FindAsync(int id);

        bool Add(Tournaments item);
        Task<bool> AddAsync(Tournaments item);

        bool Remove(int id);
        Task<bool> RemoveAsync(int id);

        bool Update(Tournaments item);
        Task<bool> UpdateAsync(Tournaments item);

        IEnumerable<Teams> GetTeams(int id);
        Task<IEnumerable<Teams>> GetTeamsAsync(int id);

    }
}
