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
    public class RequestConfigTests
    {
        [TestMethod()]
        public void GetRequestUrlTest()
        {
            RequestConfig reqConfig = new RequestConfig();
            reqConfig.RequestUrl = "https://www.cnblogs.com/";
            Assert.AreEqual(reqConfig.RequestUrl, "https://www.cnblogs.com/");
        }
    }
}