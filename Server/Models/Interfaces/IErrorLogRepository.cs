using FootballVideosWebsite.Server.ModelsData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballVideosWebsite.Server.Models
{
    public interface IErrorLogRepository
    {
        IEnumerable<ErrorLog> GetAll();
        Task<bool> AddAsync(ErrorLog item);
        bool Add(ErrorLog item);

        Task<IEnumerable<ErrorLog>> GetAllAsync();
    }
}
