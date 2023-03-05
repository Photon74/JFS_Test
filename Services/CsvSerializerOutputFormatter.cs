using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Collections;
using System.Text;

namespace JFS_Test.Services
{
    public class CsvSerializerOutputFormatter : TextOutputFormatter
    {
        public CsvSerializerOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var csv = new StringBuilder();
            var type = GetTypeOf(context.Object);

            csv.AppendLine(
                string.Join<string>(
                    ",", type.GetProperties().Select(x => x.Name)
                )
            );

            foreach (var obj in (IEnumerable<object>)context.Object)
            {
                var vals = obj.GetType().GetProperties().Select(
                    pi => new
                    {
                        Value = pi.GetValue(obj, null)
                    }
                );

                var values = new List<string>();
                foreach (var val in vals)
                {
                    if (val.Value != null)
                    {
                        var tmpval = val.Value.ToString();

                        if (tmpval.Contains(","))
                            tmpval = string.Concat("\"", tmpval, "\"");

                        tmpval = tmpval.Replace("\r", " ", StringComparison.InvariantCultureIgnoreCase);
                        tmpval = tmpval.Replace("\n", " ", StringComparison.InvariantCultureIgnoreCase);

                        values.Add(tmpval);
                    }
                    else
                    {
                        values.Add(string.Empty);
                    }
                }
                csv.AppendLine(string.Join(",", values));
            }
            return context.HttpContext.Response.WriteAsync(csv.ToString(), selectedEncoding);
        }

        private static Type GetTypeOf(object obj)
        {
            Type type = obj.GetType();
            Type itemType;
            if (type.GetGenericArguments().Length > 0)
            {
                itemType = type.GetGenericArguments()[0];
            }
            else
            {
                itemType = type.GetElementType();
            }
            return itemType;
        }

        protected override bool CanWriteType(Type type)
        {
            return typeof(IEnumerable).IsAssignableFrom(type);
        }
    }
}
