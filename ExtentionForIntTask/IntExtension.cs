using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionForIntTask
{
    public static class IntExtension
    {
        public static string StringFormat16(this int number)
        {
            string result = "0";
            if (number != 0)
            {
                bool isNegative = (number < 0) ? true: false;
                char[] digits = "0123456789ABCDEF".ToCharArray();
                StringBuilder sb = new StringBuilder();
                if (isNegative)
                    number *= -1;
                while (number != 0)
                {
                    sb.Insert(0, digits[number % 16]);
                    number /= 16;
                }
                if (isNegative)
                    sb.Insert(0, "-");
                result = sb.ToString();
            }
            return result;
        }
    }
}
