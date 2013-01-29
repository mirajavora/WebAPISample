using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace WebApiBlog.Core.MediaFormatters
{
    public class VCardMediaFormatter : MediaFormatterBase, IMediaFormatter
    {
        public VCardMediaFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/x-vcard")); 
        }

    }
}