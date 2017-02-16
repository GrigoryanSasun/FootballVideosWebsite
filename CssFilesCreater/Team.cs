using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CssFilesCreater
{
    public class Team
    {
        public int Id { get; set; }
        public int? WhoScoredTeamId { get; set; }
        public string TeamName { get; set; }
        public int? TeamAlternativeId { get; set; }
        public string TeamLogoUrl { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
        public string IconColor { get; set; }
        public string ButtonColor { get; set; }
        public string BorderColor { get; set; }
        public string WrapperColor { get; set; }

    }
}
