using FootballAnalyticsAPI.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAnalyticsAPI.Models
{
    public interface ISeasonRepository
    {
        void Add(Season item);
        IEnumerable<Season> GetAll();
        Season Find(int key);
        void Remove(int key);
        void Update(Season item);
    }
}
