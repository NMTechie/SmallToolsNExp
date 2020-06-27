using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TasksAndTPL
{
    class OperationWithTask
    {
        public string GetPrintContent(string testInputParam)
        {
            List<WebsiteInfo> inputURLs = new List<WebsiteInfo>() { 
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.google.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.yahoo.in"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.microsoft.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.stackoverflow.com"},
                new WebsiteInfo(){ContentLength=0,WebsiteContent="",URL="https://www.youtube.com"}
            };
            inputURLs = DownLoadWebsiteContent(inputURLs);
            return FormatTheWebSiteContent(inputURLs);
        }

        private string FormatTheWebSiteContent(List<WebsiteInfo> inputURLs)
        {
            StringBuilder formattedString = new StringBuilder();
            foreach (WebsiteInfo item in inputURLs)
            {
                string str = $"The content size of URL {item.URL} is {item.ContentLength}";
                formattedString.Append(str);
                formattedString.Append(Environment.NewLine);
            }
            return formattedString.ToString();
        }

        private List<WebsiteInfo> DownLoadWebsiteContent(List<WebsiteInfo> urls)
        {
            WebClient httpClient = new WebClient();
            List<WebsiteInfo> list = new List<WebsiteInfo>();
            foreach (WebsiteInfo item in urls)
            {
                item.WebsiteContent = httpClient.DownloadString(new Uri(item.URL));
                item.ContentLength = item.WebsiteContent.Length;
                list.Add(item);
            }
            return list;
        }
    }
}
