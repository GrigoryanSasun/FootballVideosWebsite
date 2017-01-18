using System;
using System.Collections.Generic;

namespace FootballAnalyticsAPI.ModelsData
{
    public partial class Tournaments
    {
        public Tournaments()
        {
            Season = new HashSet<Season>();
        }

        public int Id { get; set; }
        public string WhoScoredTourName { get; set; }
        public int WhoScoredTourId { get; set; }

        public virtual ICollection<Season> Season { get; set; }
    }
}
