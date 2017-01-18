using System;
using System.Collections.Generic;

namespace FootballAnalyticsAPI.ModelsData
{
    public partial class MatchDataTable
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public string MatchData { get; set; }

        public virtual Match Match { get; set; }
    }
}
