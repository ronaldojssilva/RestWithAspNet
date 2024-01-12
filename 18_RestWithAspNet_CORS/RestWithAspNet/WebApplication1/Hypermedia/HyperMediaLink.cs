using System.Text;

namespace RestWithAspNet.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; }
        private string href;
        public string Href
        {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(href);
                    return sb.Replace("%2f","/").ToString();
                }
            }
            set 
            { 
                href = value;
            }
        }// quando tem uma barra na url o .net converte / em %2f exemplo localhost:8080%2fapi
        public string Type { get; set; }
        public string Action { get; set; }
    }
}
