using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace WebApiBlog.Core.MediaFormatters
{
    public class VCardFormatter : MediaTypeFormatter
    {
        public VCardFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/x-vcard")); 
        }

        public override bool CanReadType(Type type)
        {
            throw new NotImplementedException();
        }

        public override bool CanWriteType(Type type)
        {
            throw new NotImplementedException();
        }
    }
}