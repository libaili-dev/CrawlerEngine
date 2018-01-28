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

            this.requestClient = WebRequest.Create(reqConfig.RequestUrl) as HttpWebRequest;
            ServicePointManager.DefaultConnectionLimit = Int32.MaxValue;
            InitWebRequest(reqConfig);

            CrawlerRequestConfig = reqConfig;
        }



    }
}
