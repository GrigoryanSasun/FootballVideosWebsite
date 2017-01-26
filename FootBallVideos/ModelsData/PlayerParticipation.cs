using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class PlayerParticipation
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public string Played { get; set; }
        public string Score { get; set; }
        public string Position { get; set; }
        public int? TeamId { get; set; }

        public virtual Players Player { get; set; }
    }
}
