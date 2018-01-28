using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrawlerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CrawlerEngine.Tests
{
    [TestClass()]
    public class CommonCrawlerTests
    {
        [TestMethod()]
        public async Task CommonCrawlerTest()
        {
            Dictionary<string, string> dicParams = new Dictionary<string, string>
            {
                { "date", "2018-01-10" },
                { "exchange", "sz" },
                {"stockcode","300666" }
            };
            CommonCrawler commonCrawler = new CommonCrawler("CJMX", dicParams);
            Assert.IsNotNull(commonCrawler);


            CommonCrawler commonCrawler2 = new CommonCrawler("CJMX");
            Assert.IsNotNull(commonCrawler2);


            var result = commonCrawler.ProcessCrawling() as HttpWebResponse;
            var resultCode = result.StatusCode;
            Assert.AreEqual(resultCode, HttpStatusCode.OK);

            for (int i = 0; i < 10; i++)
            {
                Task<WebResponse> resultAsync = commonCrawler.ProcessCrawlingAsync();
                Console.WriteLine(string.Format("current loop number:{1}, Crawling:{0} , ", commonCrawler.CrawlerRequestConfig.RequestUrl, i.ToString()));
                var ret = await resultAsync;
                Console.WriteLine(string.Format("current loop number:{1}, Crawling:{0} , ", commonCrawler.CrawlerRequestConfig.RequestUrl, i.ToString()));
                var statusCode = (ret as HttpWebResponse).StatusCode;
                Console.WriteLine("Status Code :{0}", statusCode);
            }
        }
    }
}