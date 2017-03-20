using FootBallVideos.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface IVideoRepository
    {
        IEnumerable<Videos> GetAll();
        Task<IEnumerable<Videos>> GetAllAsync();

        Videos Find(int id);
        Task<Videos> FindAsync(int id);

        bool Add(Videos item);
        Task<bool> AddAsync(Videos item);

        bool Remove(int id);
        Task<bool> RemoveAsync(int id);

        bool Update(Videos item);
        Task<bool> UpdateAsync(Videos item);

        IEnumerable<Videos> GetVideosByPlayerId(int id);
        Task<IEnumerable<Videos>> GetVideosByPlayerIdAsync(int id);

        IEnumerable<Videos> GetVideosByTeamId(int id);
        Task<IEnumerable<Videos>> GetVideosByTeamIdAsync(int id);

        IEnumerable<Videos> GetVideosByTournamentId(int id);
        Task<IEnumerable<Videos>> GetVideosByTournamentIdAsync(int id);
    }
}
