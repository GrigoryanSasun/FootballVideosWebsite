using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class Matches
    {
        public int Id { get; set; }
        public int NativeId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int SeasonId { get; set; }
        public int WhoScoredId { get; set; }
        public DateTime Date { get; set; }

        public virtual Teams AwayTeam { get; set; }
        public virtual Teams HomeTeam { get; set; }
        public virtual Season Season { get; set; }
    }
}
