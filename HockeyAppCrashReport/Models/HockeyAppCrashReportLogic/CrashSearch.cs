using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HockeyAppCrashReport.Models.HockeyAppCrashReportLogic
{
    public class CrashSearch
    {
        public List<Crash> crashes { get; set; }
        public string status { get; set; }
        public int current_page { get; set; }
        public int per_page { get; set; }
        public int total_entries { get; set; }
        public int total_pages { get; set; }


        public string querytxt { get; set; }
        public string crashProperty { get; set; }
    }
}