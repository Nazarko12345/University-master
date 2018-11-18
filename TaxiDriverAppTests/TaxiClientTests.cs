using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taxi_Driver_WPF.DataTypes;

namespace Taxi_Tests
{
    [TestClass]
    public class TaxiClientTests
    {
        [TestMethod]
        public void Test_TaxiClientConstructorAndProperties()
        {
            TaxiClient client = new TaxiClient(1, "Модест", "+380966784576");
            Assert.AreEqual(client.Name, "Модест");
            Assert.AreEqual(client.PhoneNumber, "+380966784576");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_TaxiClientPopertiesException()
        {
            TaxiClient client = new TaxiClient(1, "Модест", "+380966784576");
            //not valid phone number
            client.PhoneNumber = "+380966784576000";
        }
    }
}
