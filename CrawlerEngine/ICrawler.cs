using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerEngine
{
    public interface ICrawler
    {
        void InitWebRequest(RequestConfig reqConfig);

        Stream ProcessCrawling();

        Task<Stream> ProcessCrawlingAsync();
    }
}
