using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerEngine
{
    public class CommonCrawler : CrawlerBase
    {
        public CrawlerRequestConfig CrawlerRequestConfig { get; }
        
        public CommonCrawler(string crawlerKey, Dictionary<String, String> dicParameters = null)
        {
            CrawlerRequestConfig reqConfig = CrawlerConfigHelper.GetCrawlerRequestConfig(crawlerKey) as CrawlerRequestConfig;
            reqConfig.UrlParas = dicParameters;
            //CrawlerRequestConfig here is to store the request configuration and it is set as readonly in case of invaild modification.
            CrawlerRequestConfig = reqConfig;

            // convert webRequest in CrawlerBase to be HttpWebRequest type
            this.webRequest = WebRequest.Create(reqConfig.RequestUrl) as HttpWebRequest;
            //unlock the limitation of http request connection counts
            ServicePointManager.DefaultConnectionLimit = Int32.MaxValue;

            //Initialize the WebRequest Client using reqConfig(request configuration items)
            InitWebRequest(reqConfig);


        }



    }
}
