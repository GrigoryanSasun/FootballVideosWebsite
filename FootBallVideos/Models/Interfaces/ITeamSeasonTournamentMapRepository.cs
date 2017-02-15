using FootBallVideos.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface ITeamSeasonTournamentMapRepository
    {
        IEnumerable<TeamSeasonTournamentMap> GetAll();
        TeamSeasonTournamentMap Find(int key);
        Task<bool> Add(TeamSeasonTournamentMap item);
        bool Remove(int key);
        bool Update(TeamSeasonTournamentMap item);

        Task<IEnumerable<TeamSeasonTournamentMap>> GetAllAsync();
        Task<TeamSeasonTournamentMap> FindAsync(int key);
    }
}
