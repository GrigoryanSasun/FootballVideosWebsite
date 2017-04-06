using FootballVideosWebsite.Server.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballVideosWebsite.Server.Models
{
    public interface ITeamSeasonTournamentMapRepository
    {
        IEnumerable<TeamSeasonTournamentMap> GetAll();
        Task<IEnumerable<TeamSeasonTournamentMap>> GetAllAsync();

        TeamSeasonTournamentMap Find(int id);
        Task<TeamSeasonTournamentMap> FindAsync(int id);

        bool Add(TeamSeasonTournamentMap item);
        Task<bool> AddAsync(TeamSeasonTournamentMap item);

        bool Remove(int id);
        Task<bool> RemoveAsync(int id);

        bool Update(TeamSeasonTournamentMap item);
        Task<bool> UpdateAsync(TeamSeasonTournamentMap item);
        
    }
}
