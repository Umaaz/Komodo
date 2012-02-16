using System.Net;

namespace Komodo.Scraper.Net
{
    public static class Checker
    {
        public static bool CheckNetConnection(string url)
        {
            var code = (HttpStatusCode)0;
            var pass = true;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Proxy = null;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                code = response.StatusCode;
            }
            catch (WebException)
            {
                pass = false;
            }
            if (code != HttpStatusCode.OK)
            {
                pass = false;
            }
            return pass;
        }
    }
}
