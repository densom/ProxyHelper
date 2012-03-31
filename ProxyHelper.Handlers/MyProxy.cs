using System.Configuration;
using System.Net;
using System.Security;
using System.Web;
using CM=System.Configuration.ConfigurationManager;
namespace ProxyHelper.Handlers
{
    public class MyProxy : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var url = HttpUtility.UrlDecode(context.Request["url"]);
            var proxy = new WebProxy(@"http://proxy.sherwinproxy.com", true, null, new NetworkCredential(CM.AppSettings["ProxyUser"], CM.AppSettings["ProxyPassword"]));

            using (var client = new WebClient())
            {
                client.Proxy = proxy;
                var data = client.DownloadString(url);

                context.Response.Write(data);
            }

//            context.Response.Write(string.Format("Url: {0}", url));
        }

        #endregion
    }
}
