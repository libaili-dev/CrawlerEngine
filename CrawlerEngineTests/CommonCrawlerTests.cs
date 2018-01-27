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
    public class CommonCrawlerTests
    {
        [TestMethod()]
        public void CommonCrawlerTest()
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

        }
    }
}