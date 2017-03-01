using FootBallVideos.Models;
using FootBallVideos.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallVideos.Logging
{
    public class LoggerService
    {
        private IErrorLogRepository Error { get; set; }
        public LoggerService(IErrorLogRepository error)
        {
            Error = error;
        }

        public async Task<IEnumerable<ErrorLog>> GetAll()
        {
            return await Error.GetAllAsync();
        }


        public async Task<bool> AddAsync(string message, int priority)
        {
            ErrorLog err = new ErrorLog();
            err.IsFixed = false;
            err.Message = message;
            err.Priority = priority;
            err.Time = DateTime.UtcNow;
            return await Error.AddAsync(err);
        }

        public bool Add(string message, int priority)
        {
            ErrorLog err = new ErrorLog();
            err.IsFixed = false;
            err.Message = message;
            err.Priority = priority;
            err.Time = DateTime.UtcNow;
            return Error.Add(err);
        }
    }
}
