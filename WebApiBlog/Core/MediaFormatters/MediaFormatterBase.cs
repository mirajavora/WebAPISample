using System;
using System.Net.Http.Formatting;
using WebApiBlog.Models;

namespace WebApiBlog.Core.MediaFormatters
{
    public abstract class MediaFormatterBase : MediaTypeFormatter
    {
        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            if(type == null)
            {
                throw new ArgumentNullException("type");
            }

            return type == typeof(Contact);
        }
    }
}