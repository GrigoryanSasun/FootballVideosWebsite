using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class TeamTournamentMap
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public int? TournamentId { get; set; }
        public int? SeasonId { get; set; }

        public virtual Season Season { get; set; }
        public virtual Team Team { get; set; }
        public virtual Tournaments Tournament { get; set; }
    }
}
