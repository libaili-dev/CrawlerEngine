using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerEngine
{
    public class CommonCrawler : CrawlerBase
    {
        private static CrawlerRequestConfig reqConfig;

        public CommonCrawler(string crawlerKey) : base(reqConfig)
        {
            reqConfig = CrawlerConfigHelper.GetCrawlerRequestConfig(crawlerKey) as CrawlerRequestConfig;
        }


    }
}
