﻿using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class Players
    {
        public Players()
        {
            Videos = new HashSet<Videos>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string IconPosition { get; set; }
        public int NativeId { get; set; }
        public int? HeightInCm { get; set; }
        public int? WeightInKg { get; set; }
        public string Nationality { get; set; }
        public string PortraitUrl { get; set; }
        public int? CurrentTeamId { get; set; }
        public int? CurrentShirtNumber { get; set; }
        public string Age { get; set; }

        public virtual ICollection<Videos> Videos { get; set; }
        public virtual Teams CurrentTeam { get; set; }
    }
}
