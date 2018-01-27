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

        public string Source { get; set; }

        public string CrawlerKey { get; set; }

        public string CrawlerDescription { get; set; }

        public override string GetRequestUrl()
        {
            string tmpRequestUrl = this.RequestUrlPattern.Trim();
            if (!string.IsNullOrEmpty(tmpRequestUrl))
            {
                if (UrlParas != null && UrlParas.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvParameter in UrlParas)
                    {
                        // Placeholder of parameter value in the CrawlerConfig request url pattern is formatted as "{###}"
                        string paramPlaceHolder = string.Format("{0}{1}{2}", "{", kvParameter.Key, "}");
                        if (this.RequestUrlPattern.Contains(paramPlaceHolder))
                        {
                            tmpRequestUrl = tmpRequestUrl.Replace(paramPlaceHolder, kvParameter.Value);
                        }
                    }
                }
            }
            else
            {
                tmpRequestUrl = base.GetRequestUrl();
            }
            return tmpRequestUrl;
        }
    }
}
