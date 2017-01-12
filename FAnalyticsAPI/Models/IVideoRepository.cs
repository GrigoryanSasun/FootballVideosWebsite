using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAnalyticsAPI.Models
{
    public interface IVideoRepository
    {
        void Add(VideoItem item);
        IEnumerable<VideoItem> GetAll();
        VideoItem Find(string key);
        VideoItem Remove(string key);
        void Update(VideoItem item);
    }
}
