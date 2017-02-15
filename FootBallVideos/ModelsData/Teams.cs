using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class Teams
    {
        public int Id { get; set; }
        public int NativeId { get; set; }
        public int WhoScoredId { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
    }
}
