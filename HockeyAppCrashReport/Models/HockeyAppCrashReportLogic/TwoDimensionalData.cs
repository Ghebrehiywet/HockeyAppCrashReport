using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HockeyAppCrashReport.Models.HockeyAppCrashReportLogic
{
    public class TwoDimensionalData
    {
        public string Id { get; set; }
        private List<string[]> _data;

        public List<string[]> Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public TwoDimensionalData()
        {
            _data = new List<string[]>();

        }

    }
}