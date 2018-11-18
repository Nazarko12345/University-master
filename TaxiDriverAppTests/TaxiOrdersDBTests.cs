using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taxi_Driver_WPF.IOTypes;
using Taxi_Driver_WPF.DataTypes;
using System.Collections.Generic;

namespace Taxi_Tests
{
    [TestClass]
    public class TaxiOrdersDBTests
    {
        [TestMethod]
        public void Test_ReadingFromFile()
        {
            ClientsDB clientsInfo = new ClientsDB("../../Clients.txt");
            clientsInfo.ReadFromFile();
            DriversDB driversInfo = new DriversDB("../../Drivers.txt");
            driversInfo.ReadFromFile();
            OrdersDB ordersInfo = new OrdersDB("../../Orders.txt", clientsInfo, driversInfo);
            ordersInfo.ReadFromFile();
            Assert.AreEqual(ordersInfo.AllOrders.Count, 8);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_AllOrdersProperty()
        {
            ClientsDB clientsInfo = new ClientsDB("../../Clients.txt");
            clientsInfo.ReadFromFile();
            DriversDB driversInfo = new DriversDB("../../Drivers.txt");
            driversInfo.ReadFromFile();
            OrdersDB ordersInfo = new OrdersDB("../../Orders.txt", clientsInfo, driversInfo);
            List<TaxiOrder> lst = ordersInfo.AllOrders;
        }
    }
}
