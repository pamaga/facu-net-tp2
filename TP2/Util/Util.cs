using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public static class Util
    {
        public static string DateToDb(string date)
        {
            string[] arr = date.Split('/');
            Array.Reverse(arr);
            return string.Join("-", arr);
        }

        public static string DbToDdate(string date)
        {
            string[] arr = date.Split('-');
            Array.Reverse(arr);
            return string.Join("/", arr);
        }
    }
}
