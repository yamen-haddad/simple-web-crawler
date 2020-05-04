using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace webCrawler
{
    public class HttpHelper
    {

        public static string HttpGet(string url)
        {
            HttpWebRequest req = WebRequest.Create(url)
            as HttpWebRequest;

            string result = null;
            using (HttpWebResponse resp = req.GetResponse()
            as HttpWebResponse)
            {
                StreamReader reader =
                new StreamReader(resp.GetResponseStream());
                result = reader.ReadToEnd();
            }
            return result;
        }

        public static string HttpPost(string url, string[] paramNames, string[] paramValues)
        {
            HttpWebRequest req = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            // Build a string with all the params, properly encoded.
            // We assume that the arrays paramName and paramVal are
            // of equal length:
            StringBuilder paramz = new StringBuilder();
            for (int i = 0; i < paramNames.Length; i++)
            {
                paramz.Append(paramNames[i]);
                paramz.Append("=");

                paramz.Append(HttpUtility.UrlEncode(paramValues[i]));
                paramz.Append("&");
            }
            // Encode the parameters as form data:
            byte[] formData =
            UTF8Encoding.UTF8.GetBytes(paramz.ToString());
            req.ContentLength = formData.Length;
            // Send the request:
            using (Stream post = req.GetRequestStream())
            {
                post.Write(formData, 0, formData.Length);
            }
            // Pick up the response:
            string result = null;
            using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
            {
                StreamReader reader =
                new StreamReader(resp.GetResponseStream());
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
