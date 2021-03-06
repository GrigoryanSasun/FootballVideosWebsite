﻿using System;
using System.Collections.Generic;

namespace FootballVideosWebsite.Server.ModelsData
{
    public partial class Season
    {
        public Season()
        {
            Matches = new HashSet<Matches>();
            TeamSeasonTournamentMap = new HashSet<TeamSeasonTournamentMap>();
            Videos = new HashSet<Videos>();
        }

        public int Id { get; set; }
        public int NativeId { get; set; }
        public int WhoScoredId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Matches> Matches { get; set; }
        public virtual ICollection<TeamSeasonTournamentMap> TeamSeasonTournamentMap { get; set; }
        public virtual ICollection<Videos> Videos { get; set; }
    }
}
