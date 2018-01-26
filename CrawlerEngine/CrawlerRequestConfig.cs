using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerEngine
{
    public class CrawlerRequestConfig : RequestConfig
    {
        public string RequestUrlPattern { get; set; }

        public Dictionary<string, string> UrlParas { get; set; }

        public override string GetRequestUrl()
        {
            string requestUrlPattern = this.RequestUrlPattern.Trim();
            if (UrlParas != null && UrlParas.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvParameter in UrlParas)
                {
                    // Placeholder of parameter value in the CrawlerConfig request url pattern is formatted as "{###}"
                    string paramPlaceHolder = string.Format("{0}{1}{2}", "{", kvParameter.Key, "}");
                    if (this.RequestUrlPattern.Contains(paramPlaceHolder))
                    {
                        requestUrlPattern = requestUrlPattern.Replace(paramPlaceHolder, kvParameter.Value);
                    }
                }
            }
            return requestUrlPattern;
        }
    }
}
