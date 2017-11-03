using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HockeyAppCrashReport.Models.HockeyAppCrashReportLogic;
using System.Net.Http;
using Newtonsoft.Json;

namespace HockeyAppCrashReport.Logic
{
    public class ClientReq
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
    public class TokenResponse
    {
        public string ClientId { get; set; }
        public TokenDetail tokenDetail { get; set; }
    }

    public class TokenDetail
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiresIn { get; set; }
    }
    public class CrashReasonReportLogic
    {
        GenericHttpCaller genericHttpCaller = new GenericHttpCaller();
        string BaseURI = "https://rink.hockeyapp.net/";
        string relateivepath;

        internal CrashReasonReportList Test()
        {
            BaseURI = "https://et-servicefabric.westeurope.cloudapp.azure.com:19081";
            relateivepath = "/ETDCAPI/AuthenticationAPI/api/Clients";
            ClientReq clientReq = new ClientReq()
            {
                 ClientId= "ClientId",
                  ClientSecret= "ClientSecret"
            };
            HttpResponseMessage response = genericHttpCaller.PostAsync<TokenResponse, ClientReq>(BaseURI, relateivepath, null, clientReq, "Bearer", "application/json", "application/json", true, null, null).Result;
            HttpResponseMessage response1 = genericHttpCaller.GetAsync<CrashReasonReportList>(BaseURI, relateivepath, "Bearer", null, "application/json", null, null);

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

        internal CrashReasonReportList List(int? page, int? per_page)
        {
            relateivepath = "/api/2/apps/34f664fe3f06440da795065669a5a047/crash_reasons?";
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

        internal Histogram Histogram(DateTime startDate, DateTime endTime)
        {
            startDate = startDate == DateTime.MinValue ? DateTime.Now.AddDays(-30) : startDate;
            endTime = endTime == DateTime.MinValue ? DateTime.Now : endTime;

            relateivepath = "/api/2/apps/34f664fe3f06440da795065669a5a047/crashes/histogram?start_date=" + "2017-10-01" + "&end_date=" + "2017-11-01";
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
            relateivepath = "/api/2/apps/34f664fe3f06440da795065669a5a047/crashes/search?query=" + query;
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
            relateivepath = "/api/2/apps/34f664fe3f06440da795065669a5a047/crash_reasons/" + id + "?";
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