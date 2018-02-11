using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
                    HttpStatusCode statusCode = webResponse.StatusCode;
                    string responseContentEncoding = webResponse.ContentEncoding;
                    long responseContentLength = webResponse.ContentLength;
                    // Response ContextType
                    string responseContentType = webResponse.ContentType;
                    //TODO
                    //get stream from webResponse
                    responseStream = webResponse.GetResponseStream();

                    //important! close webResponse
                    //leave the caller to call the method CloseResponseStream() to close the responseStream here

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


        public object GetResponseContent(Stream responseStream, string contentType)
        {
            object responseContent = null;
            // TODO 
            using (StreamReader sr = new StreamReader(responseStream))
            {
                switch (contentType)
                {
                    case "text/html":
                    case "text/json":
                        {
                            string strContent = sr.ReadToEnd();
                            responseContent = strContent;
                        }
                        break;
                    case "text/xml":
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(sr.ReadToEnd());
                        responseContent = xmlDoc;
                        break;
                    default:
                        //unusual context type of response 
                        throw new NotSupportedException(string.Format("Resonse content with {0} type is not supported now!", contentType));
                }
            }
            return responseContent;
        }

        public virtual object GetResponseContextExt(WebResponse webResponse)
        {
            return new NotImplementedException(String.Format("Context type of response is {0} which is not handled now, " +
                "you should implement it by override the method GetResponseContextExt", webResponse.ContentType));
        }
    }
}
