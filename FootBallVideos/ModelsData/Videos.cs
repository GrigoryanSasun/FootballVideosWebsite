using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class Videos
    {
        public int Id { get; set; }
        public int DurationInSec { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? SizeInKb { get; set; }
        public int? PlayerId { get; set; }
        public int? SeasonId { get; set; }
        public int? TeamId { get; set; }
        public int? TournamentId { get; set; }
        public int? QualityInP { get; set; }
        public int? FramePerSecond { get; set; }
        public int? ViewCount { get; set; }
        public string ThumbnailUrl { get; set; }

        public virtual Players Player { get; set; }
        public virtual Season Season { get; set; }
        public virtual Teams Team { get; set; }
        public virtual Tournaments Tournament { get; set; }
    }
}
