using System;
using System.Collections.Generic;

namespace FootBallVideos.ModelsData
{
    public partial class ErrorLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public int Priority { get; set; }
        public bool? IsFixed { get; set; }
    }
}
