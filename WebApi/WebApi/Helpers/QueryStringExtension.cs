using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApi.Helpers
{
    public static class QueryStringExtension
    {
        /// <summary>
        /// serialize an object into query-string format
        /// Usage:
        /// string queryString = foo.GetQueryString();
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetQueryString(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }
    }
}
