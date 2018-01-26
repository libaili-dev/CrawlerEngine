using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;
using System.IO;

namespace CrawlerEngine
{
    public static class CrawlerConfigHelper
    {
        private static string crawlerConfigFilePath = ConfigurationManager.AppSettings["CrawlerConfigFilePath"];
        private static List<RequestConfig> lstReqConfig = new List<RequestConfig>();


        static CrawlerConfigHelper()
        {
            //TODO  init lstReqConfig
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(crawlerConfigFilePath))
            {
                xmlDoc.Load(crawlerConfigFilePath);
                //Get all the crawler configuration to the static dictionary: lstReqConfig
            }
            else
            {
                throw new FileNotFoundException("Crawler configuration file is not found!", crawlerConfigFilePath);
            }
        }


        public static RequestConfig GetCrawlerRequestConfig(string key)
        {
            RequestConfig reqConfig = new RequestConfig();



            return reqConfig;
        }

    }
}
