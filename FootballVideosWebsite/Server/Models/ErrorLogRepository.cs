using FootballVideosWebsite.Server.ModelsData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballVideosWebsite.Server.Models
{
    public class ErrorLogRepository : IErrorLogRepository
    {
        private FootballWebsiteContext _context;
        public ErrorLogRepository(FootballWebsiteContext context)
        {
            _context = context;
        }

        public IEnumerable<ErrorLog> GetAll()
        {
            return _context.ErrorLog;
        }

        public async Task<IEnumerable<ErrorLog>> GetAllAsync()
        {
            return await _context.ErrorLog.ToListAsync();
        }

        public async Task<bool> AddAsync(ErrorLog item)
        {
            try
            {
                _context.ErrorLog.Add(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Add(ErrorLog item)
        {
            try
            {
                _context.ErrorLog.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
