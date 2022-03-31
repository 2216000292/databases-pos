using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace databases_pos_vs.Common
{
    public class Utils
    {
        public static bool IsInt(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            int n = 0;
            return int.TryParse(obj.ToString(), out n);
        }
        public static bool IsDecimal(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            decimal n = 0;
            return decimal.TryParse(obj.ToString(), out n);
        }

    }
}
