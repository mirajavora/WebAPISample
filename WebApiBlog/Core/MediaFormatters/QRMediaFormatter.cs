using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApiBlog.Models;

namespace WebApiBlog.Core.MediaFormatters
{
    public class QrMediaFormatter : MediaFormatterBase, IMediaFormatter
    {
        private const string ApiEndpoint = "http://chart.apis.google.com/chart";

        public QrMediaFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/png"));   
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream stream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
        {
            return Task.Factory.StartNew(() => WriteQrStream(type, value, stream, content.Headers));
        }

        private void WriteQrStream(Type type, object value, Stream stream, HttpContentHeaders contentHeaders)
        {
            var contact = value as Contact;
            var values = new Dictionary<string, string>()
                             {
                                 {"cht", "qr"},
                                 {"chs", "300x300"},
                                 {"chld", "H|0"},
                             };
            values.Add("chl", String.Format("{0}%0D%0A{1}", HttpUtility.UrlEncode(contact.Name), HttpUtility.UrlEncode(contact.Email)));
            var endPointUrl = BuildUrl(values);

            using(var client = new WebClient())
            {
                var data = client.DownloadData(endPointUrl);
                stream.Write(data, 0, data.Length);
            }
        }

        private string BuildUrl(IDictionary<string, string> values)
        {
            return string.Concat(ApiEndpoint, QueryString(values));
        }

        private string QueryString(IDictionary<string, string> queryStringItems)
        {
            var stringBuilder = new StringBuilder();
            var joinCharacter = "?";
            foreach (var key in queryStringItems.Keys)
            {
                stringBuilder.AppendFormat("{0}{1}={2}", joinCharacter, key, queryStringItems[key]);
                joinCharacter = "&";
            }

            return stringBuilder.ToString();
        }
    }
}