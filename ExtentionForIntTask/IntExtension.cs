using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ExtentionForIntTask
{
    public class IntExtension : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if(formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(int))
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                }

            if(format.ToUpper() != "H")
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                }

            int number = (int)arg;
            string result = "0";
            if (number != 0)
            {
                bool isNegative = (number < 0) ? true : false;
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

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    }
}
