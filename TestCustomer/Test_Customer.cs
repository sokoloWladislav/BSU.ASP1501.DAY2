using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerTask;
using System.Globalization;

namespace TestCustomer
{
    [TestClass]
    public class Test_Customer
    {
        [TestMethod]
        public void Test_Show_Format1()
        {
            string Name = "Jeffrey Richter";
            string ContactPhone = "+1 (425) 555-0100";
            decimal Revenue = 1000000;
            NumberFormatInfo format = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            format.CurrencyDecimalSeparator = ".";
            format.CurrencyDecimalDigits = 2;
            format.CurrencySymbol = "";
            string expected = String.Format(format, "Customer record: {0}, {1:C}, {2}", Name, Revenue, ContactPhone);

            Customer customer = new Customer(Name, ContactPhone, Revenue);
            string actual = customer.Show(0); 

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Show_Format2()
        {
            string Name = "Jeffrey Richter";
            string ContactPhone = "+1 (425) 555-0100";
            decimal Revenue = 1000000;
            string expected = "Customer record: +1 (425) 555-0100";

            Customer customer = new Customer(Name, ContactPhone, Revenue);
            string actual = customer.Show(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Show_Format3()
        {
            string Name = "Jeffrey Richter";
            string ContactPhone = "+1 (425) 555-0100";
            decimal Revenue = 1000000;
            NumberFormatInfo format = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            format.CurrencyDecimalSeparator = ".";
            format.CurrencyDecimalDigits = 2;
            format.CurrencySymbol = "";
            string expected = String.Format(format, "Customer record: {0}, {1:C}", Name, Revenue);

            Customer customer = new Customer(Name, ContactPhone, Revenue);
            string actual = customer.Show(2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Show_Format4()
        {
            string Name = "Jeffrey Richter";
            string ContactPhone = "+1 (425) 555-0100";
            decimal Revenue = 1000000;
            string expected = "Customer record: Jeffrey Richter";

            Customer customer = new Customer(Name, ContactPhone, Revenue);
            string actual = customer.Show(3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Show_Format5()
        {
            string Name = "Jeffrey Richter";
            string ContactPhone = "+1 (425) 555-0100";
            decimal Revenue = 1000000;
            string expected = "Customer record: 1000000";

            Customer customer = new Customer(Name, ContactPhone, Revenue);
            string actual = customer.Show(4);

            Assert.AreEqual(expected, actual);
        }
    }
}
