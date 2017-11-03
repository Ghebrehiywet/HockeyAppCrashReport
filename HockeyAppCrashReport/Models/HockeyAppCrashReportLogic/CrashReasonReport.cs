using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HockeyAppCrashReport.Models.HockeyAppCrashReportLogic
{

    #region CrashReasonReportList Region

    public class CrashReasonReportList
    {
        public List<CrashReason> crash_reasons { get; set; }
        public string status { get; set; }
        public int current_page { get; set; }
        public int per_page { get; set; }
        public int total_entries { get; set; }
        public int total_pages { get; set; }
    }

    public class CrashReason
    {
        public int id { get; set; }
        public int app_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int status { get; set; }
        public string reason { get; set; }
        public DateTime last_crash_at { get; set; }
        public string exception_type { get; set; }
        public bool @fixed { get; set; }
        public int app_version_id { get; set; }
        public string bundle_version { get; set; }
        public string bundle_short_version { get; set; }
        public int number_of_crashes { get; set; }
        public string grouping_hash { get; set; }
        public int grouping_type { get; set; }
        public string method { get; set; }
        public string file { get; set; }
        public string @class { get; set; }
        public string line { get; set; }
        public string pattern { get; set; }
    }

    #endregion


    #region CrashReasonReportDetails Region

    public class CrashReasonReportDetails
    {
        public CrashReason crash_reason { get; set; }
        public List<Crash> crashes { get; set; }
        public string status { get; set; }
        public int current_page { get; set; }
        public int per_page { get; set; }
        public int total_entries { get; set; }
        public int total_pages { get; set; }
    }
    public class Crash
    {
        public object id { get; set; }
        public int app_id { get; set; }
        public int crash_reason_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string oem { get; set; }
        public string model { get; set; }
        public string os_version { get; set; }
        public object jail_break { get; set; }
        public string contact_string { get; set; }
        public string user_string { get; set; }
        public bool has_log { get; set; }
        public bool has_description { get; set; }
        public int app_version_id { get; set; }
        public string bundle_version { get; set; }
        public string bundle_short_version { get; set; }
    }


    #endregion
}