using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public class TournamentDetail
    {
        public TournamentDetail() { }

        public int id { get; set; }
        public string name { get; set; }
        public string nationalityFlagPosition { get; set; }
        public int videoCount { get; set; }
    }

}
