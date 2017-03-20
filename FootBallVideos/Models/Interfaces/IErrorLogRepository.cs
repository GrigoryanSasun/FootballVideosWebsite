using FootBallVideos.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public interface IErrorLogRepository
    {
        IEnumerable<ErrorLog> GetAll();
        Task<bool> AddAsync(ErrorLog item);
        bool Add(ErrorLog item);

        Task<IEnumerable<ErrorLog>> GetAllAsync();
    }
}
