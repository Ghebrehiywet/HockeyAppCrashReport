using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HockeyAppCrashReport.Models.HockeyAppCrashReportLogic
{
    public class Histogram
    {
        public string status { get; set; }
        public List<List<object>> histogram { get; set; }
    }
}