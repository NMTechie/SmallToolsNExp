using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAndTPL
{
    class WebsiteInfo
    {
        public string URL { get; set; }
        public string WebsiteContent { get; set; }
        public int ContentLength { get; set; }
    }
    /// <summary>
    /// This is required to wrap individual info as this will hold all the information which will be iterated to print
    /// </summary>
    class ListOfWebsiteInfo
    {
        public List<WebsiteInfo> WebSiteInfos { get; set; } = new List<WebsiteInfo>();
        public int Progress { get; set; }
    }
}
