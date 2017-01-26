using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public class PlayerDetails
    {
        public PlayerDetails() { }

        public string name { get; set; }
        public string nationalityFlagUrl { get; set; }
        public int videoCount { get; set; }
    }
}
