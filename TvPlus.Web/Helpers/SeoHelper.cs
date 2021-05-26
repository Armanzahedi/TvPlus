using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvPlus.Web.Helpers
{
    public static class SeoHelper
    {
        public static string SeoFriendlyString(this string str)
        {
            str = str.ToLower().Replace('_',' ').Replace(' ', '-');
            return str;
        }
    }
}
