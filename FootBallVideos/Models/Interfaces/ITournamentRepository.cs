using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface ITournamentRepository
    {
        IEnumerable<Tournaments> GetAll();
        IEnumerable<Teams> GetTeams(int id);
        Tournaments Find(int key);
        Task<bool> Add(Tournaments item);
        bool Remove(int key);
        bool Update(Tournaments item);

        Task<IEnumerable<Tournaments>> GetAllAsync();
        Task<IEnumerable<Teams>> GetTeamsAsync(int id);
        Task<Tournaments> FindAsync(int key);

    }
}
