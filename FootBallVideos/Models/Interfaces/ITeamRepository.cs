using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface ITeamRepository
    {
        void Add(Team item);
        IEnumerable<Team> GetAll();
        IEnumerable<PlayerDetails> GetPlayers(int id);
        Team Find(int id);
        void Remove(int id);
        void Update(Team item);

        Task<IEnumerable<PlayerDetails>> GetPlayersAsync(int id);
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> FindAsync(int key);
    }
}
