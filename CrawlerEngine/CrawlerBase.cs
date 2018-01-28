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

        public WebResponse ProcessCrawling()
        {
            //TODO
            HttpWebResponse response = null;
            if (requestClient != null)
            {
                try
                {
                    response = requestClient.GetResponse() as HttpWebResponse;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                throw new HttpRequestException("Web Request is not initialized.");
            }
            return response;
        }

        public async Task<WebResponse> ProcessCrawlingAsync()
        {
            //TODO
            Task<WebResponse> responseTask = null;
            if (requestClient != null)
            {
                try
                {
                    responseTask = requestClient.GetResponseAsync() ;
                    //Do other work not related to responseTask

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new HttpRequestException("Web Request is not initialized.");
            }
            return (await responseTask as HttpWebResponse);
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
