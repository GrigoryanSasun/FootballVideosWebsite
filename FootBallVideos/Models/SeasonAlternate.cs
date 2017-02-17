using FootBallVideos.ModelsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallVideos.Models
{
    public class SeasonAlternate
    {
        public int Id { get; set; }
        public int NativeId { get; set; }
        public int WhoScoredId { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public Season CovertToSeason()
        {
            try
            {
                Season item = new Season();
                item.EndDate = Convert.ToDateTime(this.EndDate);
                item.StartDate = Convert.ToDateTime(this.StartDate);
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
