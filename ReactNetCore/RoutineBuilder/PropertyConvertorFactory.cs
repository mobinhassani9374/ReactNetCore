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
            List<object> result = new List<object>();

            var properties = typeof(T).GetProperties().ToList();

            model.ForEach(c =>
            {
                dynamic MyDynamic = new ExpandoObject();

                var p = MyDynamic as IDictionary<String, object>;

                properties.ForEach(i =>
                {
                    p[i.Name] = i.GetValue(typeof(T).GetProperties(), null);
                });

                result.Add(p);
            });

            return result;
        }
    }
}
