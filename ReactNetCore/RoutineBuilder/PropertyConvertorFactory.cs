using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DNTPersianUtils.Core;

namespace ReactNetCore.RoutineBuilder
{
    public class PropertyConvertorFactory<T> where T : class
    {
        public static List<object> Convert(List<T> model)
        {
            var result = new List<object>();

            var obj = typeof(T);

            var properties = obj.GetProperties();

            model.ForEach(c =>
            {
                var dynamic = new ExpandoObject();

                var p = dynamic as IDictionary<String, object>;

                for (int i = 0; i < properties.Length; i++)
                {
                    var propInfo = c.GetType().GetProperty(properties[i].Name);

                    p[properties[i].Name] = propInfo.GetValue(model.FirstOrDefault());
                }

                result.Add(p);
            });

            return result;
        }
    }
}
