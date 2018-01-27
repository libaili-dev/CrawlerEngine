using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;
using System.IO;
using System.Net.Http;

namespace CrawlerEngine
{
    public static class CrawlerConfigHelper
    {
        private static string crawlerConfigFilePath = ConfigurationManager.AppSettings["CrawlerConfigFilePath"];
        private static List<RequestConfig> lstRequestConfig = new List<RequestConfig>();


        static CrawlerConfigHelper()
        {
            //TODO  init lstReqConfig
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(crawlerConfigFilePath))
            {
                try
                {
                    xmlDoc.Load(crawlerConfigFilePath);
                    //Get all the crawler configuration and save to the static dictionary: lstReqConfig
                    ConvertCrawlerConfiguration(xmlDoc, lstRequestConfig);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                throw new FileNotFoundException("Crawler configuration file is not found!", crawlerConfigFilePath);
            }
        }

        private static void ConvertCrawlerConfiguration(XmlDocument xmlDoc, List<RequestConfig> lstReqCfg)
        {
            XmlNodeList crawlerNodes = xmlDoc.SelectNodes("//Crawlers/Crawler");
            if (crawlerNodes != null)
            {
                foreach (XmlNode configNode in crawlerNodes)
                {
                    CrawlerRequestConfig curCrawlerReqConfig = new CrawlerRequestConfig();
                    curCrawlerReqConfig.CrawlerKey = configNode.Attributes["key"].Value;
                    curCrawlerReqConfig.CrawlerDescription = configNode.Attributes["description"].Value;

                    if (!string.IsNullOrEmpty(curCrawlerReqConfig.CrawlerKey))
                    {
                        curCrawlerReqConfig.Source = configNode.SelectSingleNode("Request/@source").Value;

                        if (configNode.SelectSingleNode("Request/Url/Address") != null)
                        {
                            curCrawlerReqConfig.RequestUrl = configNode.SelectSingleNode("Request/Url/Address").InnerText;
                        }

                        if (configNode.SelectSingleNode("Request/Url/Pattern") != null)
                        {
                            curCrawlerReqConfig.RequestUrlPattern = configNode.SelectSingleNode("Request/Url/Pattern").InnerText;
                        }

                        if (configNode.SelectSingleNode("Request/Method") != null && !string.IsNullOrEmpty(configNode.SelectSingleNode("Request/Method").InnerText.Trim()))
                        {
                            curCrawlerReqConfig.RequestMethod = configNode.SelectSingleNode("Request/Method").InnerText.Trim().ToUpper();
                        }
                        else
                        {
                            //set HttpMethod as Get
                            curCrawlerReqConfig.RequestMethod = HttpMethod.Get.ToString().ToUpper();
                        }

                        if (configNode.SelectSingleNode("Request/ContentType") != null)
                        {
                            curCrawlerReqConfig.ContentType = configNode.SelectSingleNode("Request/ContentType").InnerText;
                        }

                        //TODO other configuration item to be done

                        lstReqCfg.Add(curCrawlerReqConfig);
                    }
                }
            }

        }


        public static RequestConfig GetCrawlerRequestConfig(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                return lstRequestConfig.FirstOrDefault<RequestConfig>(cfg => (cfg as CrawlerRequestConfig).CrawlerKey.Equals(key, StringComparison.CurrentCultureIgnoreCase));
            }
            return null;
        }

    }
}
