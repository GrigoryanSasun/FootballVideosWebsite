using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace FAnalyticsAPI.Models
{
    public class VideoRepository : IVideoRepository
    {
        private static ConcurrentDictionary<string, VideoItem> _videos =
              new ConcurrentDictionary<string, VideoItem>();

        public VideoRepository()
        {
            Add(new VideoItem { Name = "Item1" });
        }

        public IEnumerable<VideoItem> GetAll()
        {
            return _videos.Values;
        }

        public void Add(VideoItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _videos[item.Key] = item;
        }

        public VideoItem Find(string key)
        {
            VideoItem item;
            _videos.TryGetValue(key, out item);
            return item;
        }

        public VideoItem Remove(string key)
        {
            VideoItem item;
            _videos.TryRemove(key, out item);
            return item;
        }

        public void Update(VideoItem item)
        {
            _videos[item.Key] = item;
        }
    }
}
