using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CM = System.Configuration.ConfigurationManager;

namespace ProxyHelper
{
    public partial class GetUrl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Process(Context);
        }

        private void Process(HttpContext context)
        {
            var url = HttpUtility.UrlDecode(context.Request["url"]);
            var proxy = new WebProxy(CM.AppSettings["ProxyUrl"], true, null, new NetworkCredential(CM.AppSettings["ProxyUser"], CM.AppSettings["ProxyPassword"]));

            using (var client = new WebClient())
            {
                client.Proxy = proxy;
                var data = client.DownloadString(url);

                context.Response.Write(data);
            }
        }
    }
}