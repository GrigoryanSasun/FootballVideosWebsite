using FootballVideosWebsite.Server.ModelsData;
using System;

namespace FootballVideosWebsite.Server.Models
{
    public class MatchAlternate 
    {
        public int Id { get; set; }
        public int NativeId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int SeasonId { get; set; }
        public int WhoScoredId { get; set; }
        public string Date { get; set; }

        public Matches CovertToMatch()
        {
            try
            {
                Matches item = new Matches();
                item.AwayTeamId = this.AwayTeamId;
                item.HomeTeamId = this.HomeTeamId;
                item.Date = Convert.ToDateTime(this.Date);
                item.NativeId = this.NativeId;
                item.WhoScoredId = this.WhoScoredId;
                item.SeasonId = this.SeasonId;
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
