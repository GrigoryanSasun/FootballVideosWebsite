using FootballVideosWebsite.Server.ModelsData;
using System;

namespace FootballVideosWebsite.Server.Models
{
    public class SeasonAlternate
    {
        public int Id { get; set; }
        public int NativeId { get; set; }
        public int WhoScoredId { get; set; }
        public string Name { get; set; }
        public int? StartDate { get; set; }
        public int? EndDate { get; set; }

        public Season CovertToSeason()
        {
            try
            {
                Season item = new Season();
                item.EndDate = new DateTime(this.EndDate.Value, 1, 1);
                item.StartDate = new DateTime(this.StartDate.Value, 1, 1);
                item.NativeId = this.NativeId;
                item.Name = this.Name;
                item.WhoScoredId = this.WhoScoredId;
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
