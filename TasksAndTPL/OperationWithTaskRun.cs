using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TasksAndTPL
{
    class OperationWithTaskRun
    {   
        internal  string FormatTheWebSiteContent(WebsiteInfo inputURLs)
        {
            StringBuilder formattedString = new StringBuilder();
            string str = $"The content size of URL {inputURLs.URL} is {inputURLs.ContentLength}";
            formattedString.Append(str);
            formattedString.Append(Environment.NewLine);
            return formattedString.ToString();
        }

        internal WebsiteInfo DownLoadWebsiteContent(WebsiteInfo urls)
        {
            WebClient httpClient = new WebClient();
            urls.WebsiteContent = httpClient.DownloadString(new Uri(urls.URL));
            urls.ContentLength = urls.WebsiteContent.Length;            
            return urls;
        }

        
        public async Task<List<WebsiteInfo>> DownLoadWebsiteContentAsyncWithCallBack(List<WebsiteInfo> urls,IProgress<ListOfWebsiteInfo> progressedURLs)
        {
            WebClient httpClient = new WebClient();
            List<WebsiteInfo> list = new List<WebsiteInfo>();
            ListOfWebsiteInfo listOfWebsiteInfo = new ListOfWebsiteInfo();

            foreach (WebsiteInfo item in urls)
            {
                item.WebsiteContent = await httpClient.DownloadStringTaskAsync(new Uri(item.URL));
                item.ContentLength = item.WebsiteContent.Length;
                list.Add(item);

                listOfWebsiteInfo.WebSiteInfos = list;
                listOfWebsiteInfo.Progress = (list.Count * 100) / urls.Count;
                progressedURLs.Report(listOfWebsiteInfo);
            }
            return list;
        }

        internal string FormatTheWebSiteContent(List<WebsiteInfo> result)
        {
            StringBuilder formattedString = new StringBuilder();
            foreach (WebsiteInfo item in result)
            {
                string str = $"The content size of URL {item.URL} is {item.ContentLength}";
                formattedString.Append(str);
                formattedString.Append(Environment.NewLine);
            }
            return formattedString.ToString();
        }


    }
   
}
