using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HockeyAppCrashReport.Models.HockeyAppCrashReportLogic;
using System.Net.Http;
using Newtonsoft.Json;

namespace HockeyAppCrashReport.Logic
{
    public class CrashReasonReportLogic
    {
        GenericHttpCaller genericHttpCaller = new GenericHttpCaller();
        string BaseURI = "https://rink.hockeyapp.net/";
        string relateivepath = "/api/2/apps/something";


        internal CrashReasonReportList List(int? page, int? per_page)
        {
            relateivepath += "/crash_reasons?";
            if (page != null)
            {
                relateivepath += "page=" + page + "&";
            }
            if (per_page != null)
            {
                relateivepath += "per_page=" + per_page;
            }
            HttpResponseMessage response = genericHttpCaller.GetAsync<CrashReasonReportList>(BaseURI, relateivepath, "Bearer", null, "application/json", null, null);
            string responseData = response?.Content?.ReadAsStringAsync()?.Result;
            if (!string.IsNullOrWhiteSpace(responseData) && !string.IsNullOrEmpty(responseData))
            {
                var result = JsonConvert.DeserializeObject<CrashReasonReportList>(responseData);
                if (response.IsSuccessStatusCode)
                {
                    return result;
                }
            }
            return new CrashReasonReportList();
        }

        internal Histogram Histogram(DateTime startDate, DateTime endDate)
        {
            startDate = startDate == DateTime.MinValue ? DateTime.Now.AddDays(-10) : startDate;
            endDate = endDate == DateTime.MinValue ? DateTime.Now : endDate;

            relateivepath += "/crashes/histogram?start_date=" + startDate.ToString("yyyy-MM-dd") + "&end_date=" + endDate.ToString("yyyy-MM-dd");
            HttpResponseMessage response = genericHttpCaller.GetAsync<Histogram>(BaseURI, relateivepath, "Bearer", null, "application/json", null, null);
            string responseData = response?.Content?.ReadAsStringAsync()?.Result;
            if (!string.IsNullOrWhiteSpace(responseData) && !string.IsNullOrEmpty(responseData))
            {
                var result = JsonConvert.DeserializeObject<Histogram>(responseData);
                if (response.IsSuccessStatusCode)
                {
                    return result;
                }
            }
            return new Histogram();
        }

        internal CrashSearch CrashSearch(string query, int? page, int? per_page)
        {
            relateivepath += "/crashes/search?query=" + query;
            if (page != null)
            {
                relateivepath += "&page=" + page;
            }
            if (per_page != null)
            {
                relateivepath += "&per_page=" + per_page;
            }
            HttpResponseMessage response = genericHttpCaller.GetAsync<CrashSearch>(BaseURI, relateivepath, "Bearer", null, "application/json", null, null);
            string responseData = response?.Content?.ReadAsStringAsync()?.Result;
            if (!string.IsNullOrWhiteSpace(responseData) && !string.IsNullOrEmpty(responseData))
            {
                var result = JsonConvert.DeserializeObject<CrashSearch>(responseData);
                if (response.IsSuccessStatusCode)
                {
                    return result;
                }
            }
            return new CrashSearch();
        }

        internal CrashReasonReportDetails Details(string id, int? page, int? per_page)
        {
            relateivepath += "/crash_reasons/" + id + "?";
            if (page != null)
            {
                relateivepath += "page=" + page + "&";
            }
            if (per_page != null)
            {
                relateivepath += "per_page=" + per_page;
            }
            HttpResponseMessage response = genericHttpCaller.GetAsync<CrashReasonReportDetails>(BaseURI, relateivepath, "Bearer", null, "application/json", null, null);
            string responseData = response?.Content?.ReadAsStringAsync()?.Result;
            if (!string.IsNullOrWhiteSpace(responseData) && !string.IsNullOrEmpty(responseData))
            {
                var result = JsonConvert.DeserializeObject<CrashReasonReportDetails>(responseData);
                if (response.IsSuccessStatusCode)
                {
                    return result;
                }
            }
            return new CrashReasonReportDetails();
        }




    }
}