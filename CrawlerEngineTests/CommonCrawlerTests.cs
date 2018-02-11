using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrawlerEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

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


            var result = commonCrawler.ProcessCrawling();
            Assert.IsNotNull(result);

            for (int i = 0; i < 10; i++)
            {
                CommonCrawler loopCrawler = new CommonCrawler("CJMX", dicParams);
                Task<Stream> resultAsync = loopCrawler.ProcessCrawlingAsync();
                Console.WriteLine(string.Format("current loop number:{1}, Crawling:{0} , ", loopCrawler.CrawlerRequestConfig.RequestUrl, i.ToString()));
                var ret = await resultAsync;
                Console.WriteLine(string.Format("current loop number:{1}, Crawling:{0} , ", loopCrawler.CrawlerRequestConfig.RequestUrl, i.ToString()));
                if (ret != null)
                {
                    Console.WriteLine(string.Format("current loop number:{0}, Response is not Null.", i.ToString()));
                    // string content = commonCrawler.GetResponseContent(ret as Stream, "text/html").ToString();

                    using (StreamReader sr = new StreamReader(ret))
                    {
                        string ss = sr.ReadToEnd();
                        Console.Write(sr);
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("current loop number:{0}, Response is Null.", i.ToString()));

                }
            }
        }
    }
}