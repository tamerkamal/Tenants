using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Base.Helpers.Extensions
{
    public class ApiClient
    {
        protected const string DefaultContentType = "application/json";
        private readonly string _accessToken;
        private readonly string _serverUrl;

        public ApiClient(string accessToken, string serverUrl)
        {
            _accessToken = accessToken;
            _serverUrl = serverUrl;
        }

        public object Call(HttpMethod method, string path)
        {
            return Call(method, path, string.Empty);
        }

        public object Call(HttpMethod method, string path, object callParams)
        {
            string requestUriString = string.Format("{0}{1}", _serverUrl, path);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);

            httpWebRequest.ContentType = DefaultContentType;
            if (_accessToken != "")
            {
                httpWebRequest.Headers.Add("Authorization", string.Format("Bearer {0}", _accessToken));
            }


            httpWebRequest.Method = ((object)method).ToString();

            if (callParams != null)
            {
                if (method == HttpMethod.Get || method == HttpMethod.Delete)
                {
                    return string.Format("{0}?{1}", requestUriString, callParams);
                }

                if (method == HttpMethod.Post || method == HttpMethod.Put)
                {
                    using (new MemoryStream())
                    {
                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            streamWriter.Write(callParams);
                            streamWriter.Close();
                        }
                    }
                }
            }

            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string encodedData = string.Empty;

            using (Stream responseStream = httpWebResponse.GetResponseStream())
            {
                if (responseStream != null)
                {
                    var streamReader = new StreamReader(responseStream);
                    encodedData = streamReader.ReadToEnd();
                    streamReader.Close();
                }
            }

            return encodedData;
        }

        public object Get(string path)
        {
            return Get(path, null);
        }

        public object Get(string path, NameValueCollection callParams)
        {
            return Call(HttpMethod.Get, path, callParams);
        }

        public object Post(string path, object data)
        {
            return Call(HttpMethod.Post, path, data);
        }

        public object Put(string path, object data)
        {
            return Call(HttpMethod.Put, path, data);
        }

        public object Delete(string path)
        {
            return Call(HttpMethod.Delete, path);
        }

        public ApiResponse CreateWebRequest(string method, string contentType, string url, byte[] body)
        {
            ApiResponse response = new ApiResponse();
            //try
            //{
            // Create a request for the URL. 
            HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            // If required by the server, set the credentials.
            webRequest.Method = method;
            webRequest.ContentType = contentType;
            webRequest.ContentLength = body.Length;

            using (var requestStream = webRequest.GetRequestStream())
            {
                requestStream.Write(body, 0, body.Length);
            }

            //  webRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer eyJraWQiOiJaeWtcLzQ2aldvR3R6TWhoYlpLNlwvaktqZVBVd0VCZ2hDWkt4aXJIZTZQbUk9IiwiYWxnIjoiUlMyNTYifQ.eyJhdF9oYXNoIjoiYVhqTEtKNHVwaFowWjBBNFctTmhYZyIsInN1YiI6ImE1OTVkMzY0LTVlOGItNDdmZS1hNjc1LTNkMWMzZTFhMTBhMSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAuYXAtc291dGhlYXN0LTIuYW1hem9uYXdzLmNvbVwvYXAtc291dGhlYXN0LTJfTmpaOTVucnQ0IiwicGhvbmVfbnVtYmVyX3ZlcmlmaWVkIjp0cnVlLCJjb2duaXRvOnVzZXJuYW1lIjoiaW5maW5pdGUiLCJhdWQiOiIyN2NvZ3MwMzd1cXJyMG02cHRndnJhY3JmNyIsImV2ZW50X2lkIjoiZjI3MWIwYjQtNTA4Ny00NWRiLTk0YjktMWY1NjYzODA1OGM2IiwidG9rZW5fdXNlIjoiaWQiLCJhdXRoX3RpbWUiOjE2Mjk3NDI5ODksInBob25lX251bWJlciI6Iis2MTQxOTE2ODgyNiIsImV4cCI6MTYyOTc0NjU4OSwiaWF0IjoxNjI5NzQyOTg5LCJlbWFpbCI6ImNsYXVkZS5icm93bkB0ZWNoMi5jb20uYXUifQ.ohy1_0ypChV7v9-M0FV3nHh8tn-JpF7Ag6BKYgv6u0DvLO7O4HjAhvK1Kb0zHgOpfL3YSbQqjCx0dcyHKPtkhq6LVZksw_DnhGzAQhWDMvuDU0UEVa3ExtRCSTGa_Zm_9V0we4Mq2Ira0ZwsoTR-rOOClBIvl6D0E6xy_vKvgBclvqdXCNc78t-7qfvvIWJUH_xy5bsfbww8FDODbnAjLgT2yByGkvbIg2zj3rndTBbW6vKvO1rTGesntaUPBj_bKnXD4IjRAcJZBX7rg_oGubepW2XsHTur546z2ZB92pdNSU-Rg7X8d0PIbj4YBteQwNXWXS6kMV0XnOW3fc8b0g");

            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            response = GetApiResponse(webResponse);
            //}
            //catch (WebException wex)
            //{
            //    if (wex.Response != null)
            //        response = GetApiResponse((HttpWebResponse)wex.Response);
            //    else
            //    {
            //        response.ResponseCode = HttpStatusCode.InternalServerError;
            //        response.ResponseBody = "url="+url+". "+wex.ToString();
            //    }
            //}

            //catch (Exception ex)
            //{
            //    response.ResponseCode = HttpStatusCode.InternalServerError;
            //    response.ResponseBody = "url=" + url + ". " + ex.ToString();
            //}

            return response;
        }

        private static ApiResponse GetApiResponse(HttpWebResponse webResponse)
        {
            ApiResponse response = new ApiResponse();
            // Get the response.
            // Display the status.
            response.ResponseCode = webResponse.StatusCode;
            response.ResponseBody = webResponse.StatusDescription;
            // Get the stream containing content returned by the server.
            using (Stream responseStream = webResponse.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    // Read the content.
                    response.ResponseBody = reader.ReadToEnd();
                }
            }

            return response;
        }


    }

    public class ApiResponse
    {
        public HttpStatusCode ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string ResponseBody { get; set; }
    }
    public class WebServiceResponse
    {
        public string Response { get; set; }
        public string Message { get; set; }
    }

}