using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerEngine.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Crawler Engine Test Console");
            Console.WriteLine("============================");

            Task.Run(() => TestCrawler());

            Console.ReadLine();
        }

        private static async Task TestCrawler()
        {
            Dictionary<string, string> dicParams = new Dictionary<string, string>
            {
                { "date", "2018-01-10" },
                { "exchange", "sz" },
                {"stockcode","300666" }
            };
            CommonCrawler commonCrawler = new CommonCrawler("CJMX", dicParams);


            CommonCrawler commonCrawler2 = new CommonCrawler("CJMX");


            var result = commonCrawler.ProcessCrawling();

            for (int i = 0; i < 1000; i++)
            {
                Task<Stream> resultAsync = commonCrawler.ProcessCrawlingAsync();
                Console.WriteLine(string.Format("current loop number:{1}, Crawling:{0} , ", commonCrawler.CrawlerRequestConfig.RequestUrl, i.ToString()));
                var ret = await resultAsync;
                Console.WriteLine(string.Format("current loop number:{1}, Crawling:{0} , ", commonCrawler.CrawlerRequestConfig.RequestUrl, i.ToString()));
                if (ret != null)
                {
                    Console.WriteLine(string.Format("current loop number:{0}, Response is NOT Null. ", i.ToString()));
                }
                else
                {
                    Console.WriteLine(string.Format("current loop number:{0}, Response is Null. ", i.ToString()));

                }
            }
        }
    }
}
