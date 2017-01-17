using System;
using System.Collections.Generic;

namespace FootballAnalyticsAPI.ModelsData
{
    public partial class Match
    {
        public Match()
        {
            MatchDataTable = new HashSet<MatchDataTable>();
            PlayerParticipation = new HashSet<PlayerParticipation>();
        }

        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int SeasonId { get; set; }
        public int WhoScoredMatchId { get; set; }
        public DateTime WhoScoredDate { get; set; }

        public virtual ICollection<MatchDataTable> MatchDataTable { get; set; }
        public virtual ICollection<PlayerParticipation> PlayerParticipation { get; set; }
        public virtual Team AwayTeam { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Season Season { get; set; }
    }
}
