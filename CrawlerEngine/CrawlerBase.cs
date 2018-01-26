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
        private HttpWebRequest httpWebRequest;


        public CrawlerBase(RequestConfig reqConfig)
        {
            this.httpWebRequest = WebRequest.Create(reqConfig.RequestUrl) as HttpWebRequest;
            ServicePointManager.DefaultConnectionLimit = Int32.MaxValue;

            InitWebRequest(reqConfig);
        }

        public HttpWebResponse ProcessCrawl()
        {
            throw new NotImplementedException();
        }

        public Task<HttpWebResponse> ProcessCrawlAsync()
        {
            throw new NotImplementedException();
        }

        public void InitWebRequest(RequestConfig reqConfig)
        {
            

            //TODO

            throw new NotImplementedException();
        }

        public virtual void RequestConfigExt(HttpClient client)
        { }


    }
}
