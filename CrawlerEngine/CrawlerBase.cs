using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerEngine
{
    public abstract class CrawlerBase : ICrawler
    {
        protected HttpWebRequest requestClient;

        public HttpWebResponse ProcessCrawling()
        {
            //TODO
            throw new NotImplementedException();
        }

        public Task<HttpWebResponse> ProcessCrawlingAsync()
        {
            //TODO
            throw new NotImplementedException();
        }

        public void InitWebRequest(RequestConfig reqConfig)
        {
            if(!string.IsNullOrEmpty(reqConfig.ContentType))
            {
                this.requestClient.ContentType = reqConfig.ContentType;
            }
            this.requestClient.Method = reqConfig.RequestMethod;
            //TODO

           
        }

        public virtual void RequestConfigExt(HttpClient client)
        {

        }



    }
}
