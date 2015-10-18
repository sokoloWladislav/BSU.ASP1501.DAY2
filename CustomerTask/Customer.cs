using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CustomerTask
{
    public delegate string StringFormat();
    public class Customer
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }
        private static List<StringFormat> stringFormates = new List<StringFormat>();
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
            stringFormates.Add(StringFormat1);
            stringFormates.Add(StringFormat2);
            stringFormates.Add(StringFormat3);
            stringFormates.Add(StringFormat4);
            stringFormates.Add(StringFormat5);
        }

        public string Show(int index)
        {
            return stringFormates[index]();
        }

        public static void AddNewStringFormat(StringFormat s)
        {
            stringFormates.Add(s);
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
