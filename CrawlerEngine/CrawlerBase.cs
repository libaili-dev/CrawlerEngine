using System;
using System.Collections.Generic;
using System.IO;
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

        public Stream ProcessCrawling()
        {
            Stream responseStream = null;
            if (webRequest != null)
            {
                try
                {
                    HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;
                    //TODO
                    //get stream fro webResponse
                    responseStream = webResponse.GetResponseStream();
                    //important! close webResponse
                    webResponse.Close();
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
            return responseStream;
        }

        public async Task<Stream> ProcessCrawlingAsync()
        {
            Stream responseStream = null;
            if (webRequest != null)
            {
                try
                {
                    Task<WebResponse> responseTask = webRequest.GetResponseAsync();
                    // other logic which is not related to responseTask will continue


                    responseStream = (await responseTask).GetResponseStream();
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
            return responseStream;
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


        public object GetResponseContext(WebResponse webResponse)
        {
            object responseContext = null;
            switch (webResponse.ContentType)
            {
                case "text/html":

                    break;
                case "text/json":

                    break;
                case "text/xml":

                    break;
                default:
                    //unusual context type of response 
                    responseContext = GetResponseContextExt(webResponse);
                    break;
            }
            return responseContext;
        }

        public virtual object GetResponseContextExt(WebResponse webResponse)
        {
            return new NotImplementedException(String.Format("Context type of response is {0} which is not handled now, " +
                "you should implement it by override the method GetResponseContextExt", webResponse.ContentType));
        }
    }
}
