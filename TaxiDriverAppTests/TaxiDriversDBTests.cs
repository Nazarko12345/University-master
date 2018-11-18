using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taxi_Driver_WPF.IOTypes;

namespace Taxi_Tests
{
    [TestClass]
    public class TaxiDriversDBTests
    {
        [TestMethod]
        public void Test_ReadingFromFile()
        {
            DriversDB driversInfo = new DriversDB("../../Drivers.txt");
            driversInfo.ReadFromFile();
            Assert.AreEqual(driversInfo.AllDrivers.Count, 3);
        }

        [TestMethod]
        public void Test_GetDriverById()
        {
            DriversDB driversInfo = new DriversDB("../../Drivers.txt");
            driversInfo.ReadFromFile();
            Assert.AreEqual(driversInfo.GetDriverById(2).Id, Convert.ToUInt32(2));
        }
    }
}
