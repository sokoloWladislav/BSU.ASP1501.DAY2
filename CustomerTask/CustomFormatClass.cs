using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CustomerTask
{
    class CustomFormatClass : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            Customer customer = arg as Customer;
            if (customer == null) return arg.ToString();
            return string.Format("Customer record: {0}, {0:C}", customer.Name, customer.ContactPhone);
        }

    }
}
