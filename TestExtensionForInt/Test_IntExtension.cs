using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtentionForIntTask;

namespace TestExtensionForInt
{
    [TestClass]
    public class Test_IntExtension
    {
        [TestMethod]
        public void Test_StringFormat16_16ToStringReturned10()
        {
            int number = 16;
            string expected = "10";

            string actual = String.Format(new IntExtension(), "{0:H}", 16);

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void Test_StringFormat16_458ToStringReturned1CA()
        //{
        //    int number = 458;
        //    string expected = "1CA";

        //    string actual = number.StringFormat16();

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void Test_StringFormat16_0ToStringReturned0()
        //{
        //    int number = 0;
        //    string expected = "0";

        //    string actual = number.StringFormat16();

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void Test_StringFormat16_Negative745ToStringReturned2E9()
        //{
        //    int number = -745;
        //    string expected = "-2E9";

        //    string actual = number.StringFormat16();

        //    Assert.AreEqual(expected, actual);
        //}
    }
}
