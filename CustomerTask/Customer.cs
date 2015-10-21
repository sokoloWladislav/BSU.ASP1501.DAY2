using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CustomerTask
{
    public class Customer : IFormattable
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch(format.ToUpper())
            {
                case "G":
                    return String.Format(provider, "Custom record: {0}", Name);
                case "R":
                    return String.Format(provider, "Custom record: {0:C}", Revenue);
                case "P":
                    return String.Format(provider, "Csutom record: {0}", ContactPhone);
                case "A":
                    return String.Format(provider, "Custom record: {0}, {1}, {2}", Name, ContactPhone, Revenue);
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));

            }
        }








        private string StringFormat1()
        {
            NumberFormatInfo format = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            format.CurrencyDecimalSeparator = ".";
            format.CurrencyDecimalDigits = 2;
            format.CurrencySymbol = "";
           
            return String.Format(format, "Customer record: {0}, {1:C}, {2}", Name, Revenue, ContactPhone);
        }

        private string StringFormat2()
        {
            return String.Format("Customer record: {0}", ContactPhone);
        }

        private string StringFormat3()
        {
            NumberFormatInfo format = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            format.CurrencyDecimalSeparator = ".";
            format.CurrencyDecimalDigits = 2;
            format.CurrencySymbol = "";
            return String.Format(format, "Customer record: {0}, {1:C}", Name, Revenue);
        }

        private string StringFormat4()
        {
            return String.Format("Customer record: {0}", Name);
        }

        private string StringFormat5()
        {
            return String.Format("Customer record: {0}", Revenue);
        }
    }
}
