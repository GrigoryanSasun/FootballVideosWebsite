using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class Players
    {
        public Players()
        {
            PlayerParticipation = new HashSet<PlayerParticipation>();
            PlayerProfile = new HashSet<PlayerProfile>();
        }

        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int WhoScoredPlayerId { get; set; }
        public int? CurentTeamId { get; set; }

        public virtual ICollection<PlayerParticipation> PlayerParticipation { get; set; }
        public virtual ICollection<PlayerProfile> PlayerProfile { get; set; }
        public virtual Team CurentTeam { get; set; }
    }
}
