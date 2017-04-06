using FootballVideosWebsite.Server.Models;
using FootballVideosWebsite.Server.ModelsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballVideosWebsite.Server.Services
{
    public class LoggerService
    {
        private IErrorLogRepository Error { get; set; }
        private FootballWebsiteContext _context { get; set; }
        public LoggerService(IErrorLogRepository error, FootballWebsiteContext context)
        {
            Error = error;
            _context = context;
        }

        public async Task<IEnumerable<ErrorLog>> GetAll()
        {
            return await Error.GetAllAsync();
        }


        public async Task<bool> AddAsync(string message, string component, int priority)
        {
            ErrorLog err = new ErrorLog();
            err.IsFixed = false;
            err.Message = message;
            err.Priority = priority;
            err.Component = component;
            err.Datetime = DateTime.UtcNow;
            return await Error.AddAsync(err);
        }

        public bool Add(string message, string component, int priority)
        {
            ErrorLog err = new ErrorLog();
            err.IsFixed = false;
            err.Message = message;
            err.Priority = priority;
            err.Component = component;
            err.Datetime = DateTime.UtcNow;
            return Error.Add(err);
        }

        public bool DetachAll(FootballWebsiteContext context)
        {
            try
            {
                foreach (EntityEntry entityEntry in context.ChangeTracker.Entries().ToArray())
                {
                    if (entityEntry.Entity != null)
                    {
                        entityEntry.State = EntityState.Detached;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
