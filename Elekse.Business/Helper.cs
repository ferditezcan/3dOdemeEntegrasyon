using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Elekse.Business
{
    public class Helper
    {
        public static string PostUrl = "https://posservice.elekse.com/api/pay/EYV3DPay";
        public static string PostUrlLocal = "http://localhost:24003/api/pay/EYV3DPay";
        public string JsonPostData(string url, string postData)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = postData;

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var streamReader = new StreamReader(httpResponse.GetResponseStream());
            var result = streamReader.ReadToEnd();
            return result;
        }
    }
}
