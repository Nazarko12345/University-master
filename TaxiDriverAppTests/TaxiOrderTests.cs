using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taxi_Driver_WPF.DataTypes;

namespace Taxi_Tests
{
    [TestClass]
    public class TaxiOrderTests
    {
        [TestMethod]
        public void Test_TaxiOrderConstructorAndProperties()
        {
            TaxiClient client = new TaxiClient(2, "Модест", "+380966784576");
            TaxiDriver driver = new TaxiDriver(3, "Радомський", "Модест", 20, "BC1789AM", 5, 50, 189.75);
            TaxiOrder order = new TaxiOrder(1, client, driver, Convert.ToDateTime("2017-12-22 17:30"), "Шевченка,44", "Зелена,12", 123);
            Assert.AreEqual(order.Client.Id, client.Id);
            Assert.AreEqual(order.Driver.Id, driver.Id);
            Assert.AreEqual(order.ArriveTime, Convert.ToDateTime("2017-12-22 17:30"));
            Assert.AreEqual(order.Dispatch, "Шевченка,44");
            Assert.AreEqual(order.Destination, "Зелена,12");
            Assert.AreEqual(order.RoadTime, Convert.ToUInt32(123));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_TaxiOrderPopertiesException()
        {
            TaxiOrder order = new TaxiOrder();
            order.Dispatch = "Виговського,123";
            //Destination equals to Dispatch
            order.Destination = "Виговського,123";
        }
    }
}
