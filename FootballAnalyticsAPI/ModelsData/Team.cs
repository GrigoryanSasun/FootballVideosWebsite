using System;
using System.Collections.Generic;

namespace FootballAnalyticsAPI.ModelsData
{
    public partial class Team
    {
        public int Id { get; set; }
        public int WhoScoredTeamId { get; set; }
        public string TeamName { get; set; }
    }
}
