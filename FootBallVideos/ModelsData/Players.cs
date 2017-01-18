using System;
using System.Collections.Generic;

namespace FootballAnalyticsAPI.ModelsData
{
    public partial class Players
    {
        public Players()
        {
            PlayerParticipation = new HashSet<PlayerParticipation>();
        }

        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int WhoScoredPlayerId { get; set; }

        public virtual ICollection<PlayerParticipation> PlayerParticipation { get; set; }
    }
}
