using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrawlerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerEngine.Tests
{
    [TestClass()]
    public class CrawlerRequestConfigTests
    {
        [TestMethod()]
        public void GetRequestUrlTest()
        {
            CrawlerRequestConfig crawlerReqConfig = new CrawlerRequestConfig();
            crawlerReqConfig.RequestUrlPattern = "https://zhidao.baidu.com/notice/get/unreadcount?iswrap={iswrap}&t={timestamp}";
            Dictionary<string, string> dicParams = new Dictionary<string, string>
            {
                { "iswrap", "0" },
                { "timestamp", "1512841098876" }
            };
            crawlerReqConfig.UrlParas = dicParams;
            Assert.AreEqual(crawlerReqConfig.RequestUrl.ToString(), "https://zhidao.baidu.com/notice/get/unreadcount?iswrap=0&t=1512841098876");

            RequestConfig reqConfig = crawlerReqConfig as RequestConfig;
            Assert.AreEqual(reqConfig.RequestUrl.ToString(), "https://zhidao.baidu.com/notice/get/unreadcount?iswrap=0&t=1512841098876");

            CrawlerRequestConfig crawlerTestHelper = CrawlerConfigHelper.GetCrawlerRequestConfig("CJMX") as CrawlerRequestConfig;
            crawlerTestHelper.UrlParas = dicParams;
            string testCrawlerUrl = crawlerTestHelper.RequestUrl;
            Assert.AreEqual(crawlerTestHelper.RequestUrl.ToString(), "http://market.finance.sina.com.cn/downxls.php?date={date}&symbol={indicetype}{stockcode}");

        }
    }
}