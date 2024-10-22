using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ec.com.naturisa.mobile.feedcontrol.Helpers
{
    public partial class StringExtensions
    {

        public static string BuildQueryString<T>(T obj) where T : class
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var url = new StringBuilder("?");
            var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);

                if (value == null) continue;

                if (property.PropertyType == typeof(DateTime?) && value is DateTime dateTimeValue)
                {
                    url.Append($"{property.Name}={dateTimeValue:yyyy-MM-dd}&");
                }
                else if (property.PropertyType.IsArray && value is Array arrayValue)
                {
                    foreach (var item in arrayValue)
                    {
                        url.Append($"{property.Name}={item}&");
                    }
                }
                else if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                {
                    url.Append($"{property.Name}={value.ToString().ToLower()}&");
                }
                else if (property.PropertyType == typeof(string) && !string.IsNullOrEmpty(value.ToString()))
                {
                    url.Append($"{property.Name}={Uri.EscapeDataString(value.ToString())}&");
                }
                else if (property.PropertyType.IsPrimitive || property.PropertyType.IsValueType)
                {
                    url.Append($"{property.Name}={value}&");
                }
            }

            if (url.Length > 1)
                url.Length--;

            return url.ToString();
        }



    }
}
