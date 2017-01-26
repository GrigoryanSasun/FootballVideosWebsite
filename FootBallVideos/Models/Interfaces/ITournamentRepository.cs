using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface ITournamentRepository
    {
        void Add(Tournaments item);
        IEnumerable<Tournaments> GetAll();
        IEnumerable<Team> GetTeams(int id);
        Tournaments Find(int key);
        void Remove(int key);
        void Update(Tournaments item);

        Task<IEnumerable<Tournaments>> GetAllAsync();
        Task<IEnumerable<Team>> GetTeamsAsync(int id);
        Task<Tournaments> FindAsync(int key);

    }
}
