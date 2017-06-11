using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFGameShopWarehouseService.Extensions
{
    public static class Extensions
    {
        public static string WithDate(this string value)
        {
            return DateTime.Now + " " + value;
        }
    }
}
