using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class PlayerProfile
    {
        public int Id { get; set; }
        public int PlayersId { get; set; }
        public int CurrentShirtNumber { get; set; }
        public string Position { get; set; }
        public string Age { get; set; }
        public int HeightInCm { get; set; }
        public int? WeightInKg { get; set; }
        public string Nationality { get; set; }
        public string NationalityFlagUrl { get; set; }
        public string PlayerImageUrl { get; set; }
        public int CurrentTeamId { get; set; }
        public int? CountryId { get; set; }

        public virtual Flags Country { get; set; }
        public virtual Players Players { get; set; }
    }
}
