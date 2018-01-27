using System.Collections.Generic;
using System.Net.Http;

namespace CrawlerEngine
{
    public class RequestConfig
    {
        private string requesUrl = string.Empty;

        public string RequestUrl
        {
            get
            {
                return GetRequestUrl();
            }
            set
            {
                this.requesUrl = value;
            }
        }

        public string RequestMethod { get; set; }

        public int Timeout { get; set; }


        public string ContentType { get; set; }

        public virtual string GetRequestUrl()
        {
            return this.requesUrl;
        }
    }
}