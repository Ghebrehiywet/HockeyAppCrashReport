using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HockeyAppCrashReport.Logic
{

    public class GenericHttpCaller
    {
        string HockeyAPIToken = "bdd833cd39814de5946ce99338188eb6";

        public HttpResponseMessage GetAsync<TReturn>(string baseAddress, string ApiAddress, string AuthenticationHeaderType, string Token, string MediaType, Dictionary<string, string> cookies, Dictionary<string, string> headers)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
                using (var client = new HttpClient(handler))
                {
                    //Add Cookie Values
                    if (cookies != null)
                    {
                        foreach (var cookie in cookies)
                        {
                            cookieContainer.Add(new Uri(baseAddress), new Cookie(cookie.Key, cookie.Value));
                        }
                    }
                    ////Trust all certificates
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                    client.BaseAddress = new Uri(baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationHeaderType, Token);
                    client.DefaultRequestHeaders.Add("X-HockeyAppToken", HockeyAPIToken);
                    //Add Header Values
                    if (headers != null)
                    {
                        foreach (var header in headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }
                    client.Timeout = TimeSpan.FromMinutes(60);

                    HttpResponseMessage response = client.GetAsync(ApiAddress).Result;
                    return response;

                }

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage();

            }
        }

        public async Task<HttpResponseMessage> PostAsync<ThttpResponseMessage, Tpara>(string baseAddress, string ApiAddress, string Token, Tpara para, string AuthenticationHeaderType, string MediaType, string BodyMediaType, bool IsBodyRequestJSON, Dictionary<string, string> cookies, Dictionary<string, string> headers)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
                using (var client = new HttpClient(handler))
                {
                    //Add Cookie Values
                    if (cookies != null)
                    {
                        foreach (var cookie in cookies)
                        {
                            if (!String.IsNullOrEmpty(cookie.Value))
                            {
                                cookieContainer.Add(new Uri(baseAddress), new Cookie(cookie.Key, cookie.Value));
                            }

                        }
                    }

                    ////Trust all certificates
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                    client.BaseAddress = new Uri(baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationHeaderType, Token);
                    client.DefaultRequestHeaders.Add("X-HockeyAppToken", HockeyAPIToken);
                    //Add Header Values
                    if (headers != null)
                    {
                        foreach (var header in headers)
                        {
                            if (!String.IsNullOrEmpty(header.Value))
                            {
                                client.DefaultRequestHeaders.Add(header.Key, header.Value);
                            }
                        }
                    }
                    client.Timeout = TimeSpan.FromMinutes(60);

                    HttpResponseMessage response = null;

                    if (IsBodyRequestJSON)
                    {
                        response = client.PostAsync(ApiAddress,
                      new StringContent(JsonConvert.SerializeObject(para,
                                Formatting.None,
                                new JsonSerializerSettings
                                {
                                    NullValueHandling = NullValueHandling.Ignore
                                }).ToString(),
                      Encoding.UTF8, BodyMediaType)).Result;
                    }
                    else
                    {
                        response = await client.PostAsync(ApiAddress, new StringContent(para.ToString(), Encoding.UTF8, BodyMediaType));
                    }

                    return response;
                }

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage();
            }
        }

        public async Task<HttpResponseMessage> PutAsync<TreturnHttpResponseMessage, Tpara>(string baseAddress, string ApiAddress, string Token, Tpara para, string AuthenticationHeaderType, string MediaType, string BodyMediaType, bool IsBodyRequestJSON, Dictionary<string, string> cookies, Dictionary<string, string> headers)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
                using (var client = new HttpClient(handler))
                {
                    //Add Cookie Values
                    if (cookies != null)
                    {
                        foreach (var cookie in cookies)
                        {
                            cookieContainer.Add(new Uri(baseAddress), new Cookie(cookie.Key, cookie.Value));
                        }
                    }

                    client.BaseAddress = new Uri(baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationHeaderType, Token);
                    client.DefaultRequestHeaders.Add("X-HockeyAppToken", HockeyAPIToken);
                    //Add Header Values
                    if (headers != null)
                    {
                        foreach (var header in headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }
                    client.Timeout = TimeSpan.FromMinutes(60);

                    HttpResponseMessage response = null;

                    if (IsBodyRequestJSON)
                    {
                        response = client.PutAsync(ApiAddress, new StringContent(JsonConvert.SerializeObject(para).ToString(), Encoding.UTF8, BodyMediaType)).Result;
                    }
                    else
                    {
                        response = await client.PutAsync(ApiAddress, new StringContent(para.ToString(), Encoding.UTF8, BodyMediaType));
                    }

                    return response;
                }

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage();
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync<TreturnHttpResponseMessage>(string baseAddress, string ApiAddress, string AuthenticationHeaderType, string Token, string MediaType, Dictionary<string, string> cookies, Dictionary<string, string> headers)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
                using (var client = new HttpClient(handler))
                {
                    //Add Cookie Values
                    if (cookies != null)
                    {
                        foreach (var cookie in cookies)
                        {
                            if (cookie.Value != null)
                                cookieContainer.Add(new Uri(baseAddress), new Cookie(cookie.Key, cookie.Value));
                        }
                    }
                    client.BaseAddress = new Uri(baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationHeaderType, Token);
                    client.DefaultRequestHeaders.Add("X-HockeyAppToken", HockeyAPIToken);
                    //Add Header Values
                    if (headers != null)
                    {
                        foreach (var header in headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }
                    client.Timeout = TimeSpan.FromMinutes(60);

                    HttpResponseMessage response = await client.DeleteAsync(ApiAddress);
                    return response;

                }

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage();
            }
        }


    }
}