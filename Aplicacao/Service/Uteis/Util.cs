using System;
using System.IO;
using System.Net;

namespace Aplicacao.Service
{
    public static class Util
    {
        public static String WebRequest(string url)
        {
            var webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.UserAgent = "TESTE";
            try
            {
                using (var responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                    return responseReader.ReadToEnd();
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}