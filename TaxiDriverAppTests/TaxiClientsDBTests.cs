using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taxi_Driver_WPF.IOTypes;

namespace Taxi_Tests
{
    [TestClass]
    public class TaxiClientsDBTests
    {
        [TestMethod]
        public void Test_ReadingFromFile()
        {
            ClientsDB clientsInfo = new ClientsDB("../../Clients.txt");
            clientsInfo.ReadFromFile();
            Assert.AreEqual(clientsInfo.AllClients.Count, 5);
        }

        [TestMethod]
        public void Test_GetClientById()
        {
            ClientsDB clientsInfo = new ClientsDB("../../Clients.txt");
            clientsInfo.ReadFromFile();
            Assert.AreEqual(clientsInfo.GetClientById(1).Id, Convert.ToUInt32(1));
        }
    }
}
