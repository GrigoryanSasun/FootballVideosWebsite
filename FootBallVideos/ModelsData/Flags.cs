using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class Flags
    {
        public Flags()
        {
            PlayerProfile = new HashSet<PlayerProfile>();
        }

        public int Id { get; set; }
        public string FlagLocation { get; set; }
        public string Country { get; set; }

        public virtual ICollection<PlayerProfile> PlayerProfile { get; set; }
    }
}
