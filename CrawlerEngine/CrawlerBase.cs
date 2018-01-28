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
        protected WebRequest webRequest;

        public WebResponse ProcessCrawling()
        {
            HttpWebResponse response = null;
            if (webRequest != null)
            {
                try
                {
                    response = webRequest.GetResponse() as HttpWebResponse;
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
            Task<WebResponse> responseTask = null;
            if (webRequest != null)
            {
                try
                {
                    responseTask = webRequest.GetResponseAsync();
                    // other logic which is not related to responseTask will continue
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
            if (!string.IsNullOrEmpty(reqConfig.ContentType))
            {
                this.webRequest.ContentType = reqConfig.ContentType;
            }
            this.webRequest.Method = reqConfig.RequestMethod;
            if (reqConfig.Timeout > 0)
            {
                this.webRequest.Timeout = reqConfig.Timeout;
            }
            // TODO other request configuration setting

        }

        public virtual void RequestConfigExt(HttpClient client)
        {

        }



    }
}
