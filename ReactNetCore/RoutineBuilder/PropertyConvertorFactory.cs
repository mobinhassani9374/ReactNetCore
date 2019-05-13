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

                    var value = propInfo.GetValue(model.FirstOrDefault());

                    //if (propInfo.PropertyType == typeof(Int32))
                    //{
                    //    value = ((int)value).ToPersianNumbers();
                    //}
                    //if (propInfo.PropertyType == typeof(Int32?))
                    //{
                    //    value = ((int?)value)?.ToPersianNumbers();
                    //}
                    if (propInfo.PropertyType == typeof(bool))
                    {
                        if ((bool)value)
                            value = "بلی";
                        else value = "خیر";
                    }
                    if (propInfo.PropertyType == typeof(bool?))
                    {
                        if (((bool?)value).HasValue)
                        {
                            if (((bool?)value).Value)
                            {
                                value = "بلی";
                            }
                            else
                            {
                                value = "خیر";
                            }
                        }
                    }
                    if (propInfo.PropertyType == typeof(DateTime))
                    {
                        value = ((DateTime)value).ToPersianDateTextify();
                    }
                    if (propInfo.PropertyType == typeof(DateTime?))
                    {
                        value = ((DateTime?)value)?.ToPersianDateTextify();
                    }

                    p[properties[i].Name] = value.ToString().ToPersianNumbers();
                }

                result.Add(p);
            });

            return result;
        }
    }
}
