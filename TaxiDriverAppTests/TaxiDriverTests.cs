using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taxi_Driver_WPF.DataTypes;

namespace Taxi_Tests
{
    [TestClass]
    public class TaxiDriverTests
    {
        [TestMethod]
        public void Test_TaxiDriverConstructorAndProperties()
        {
            TaxiDriver driver = new TaxiDriver(1, "Радомський", "Модест", 20, "BC1789AM", 5, 50, 189.75);
            Assert.AreEqual(driver.Surname, "Радомський");
            Assert.AreEqual(driver.Name, "Модест");
            Assert.AreEqual(driver.Age, Convert.ToUInt32(20));
            Assert.AreEqual(driver.CarNumber, "BC1789AM");
            Assert.AreEqual(driver.Experience, Convert.ToUInt32(5));
            Assert.AreEqual(driver.CostPerMinute, Convert.ToUInt32(50));
            Assert.AreEqual(driver.PayCheck, 189.75);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_TaxiDriverPopertiesException()
        {
            TaxiDriver driver = new TaxiDriver(1, "Радомський", "Модест", 20, "BC1789AM", 5, 50, 189);
            //not valid age
            driver.Age = 17;
        }
    }
}
