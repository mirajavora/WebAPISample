using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace WebApiBlog.Core.MediaFormatters
{
    public class ImageFormatter : MediaTypeFormatter
    {
        public ImageFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpeg"));   
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