using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TaxiDriverApp.DataTypes;

namespace TaxiDriverApp.IOTypes
{
	public class OrdersDB
	{
		private string fileName;
		private List<TaxiOrder> allOrders;
		private ClientsDB clientsInfo;
		private DriversDB driversInfo;

		public List<TaxiOrder> AllOrders
		{
			get
			{
				if (allOrders.Count == 0)
				{
					throw new ArgumentOutOfRangeException("Orders are empty");
				}
				return allOrders;
			}

			set
			{
				if (value.Count == 0)
				{
					throw new ArgumentOutOfRangeException("Orders are empty");
				}
				allOrders = value;
			}
		}

		public OrdersDB(string _fileName, ClientsDB _clientsInfo, DriversDB _driversInfo)
		{
			allOrders = new List<TaxiOrder>();
			fileName = _fileName;
			clientsInfo = _clientsInfo;
			driversInfo = _driversInfo;
		}

		public void ReadFromFile()
		{
			string[] allLines = File.ReadAllLines(fileName);
			foreach (string line in allLines)
			{
				string[] lineElems = line.Split(' ');
				allOrders.Add(new TaxiOrder(Convert.ToUInt32(lineElems[0]), clientsInfo.GetClientById(Convert.ToUInt32(lineElems[1])), driversInfo.GetDriverById(Convert.ToUInt32(lineElems[2])), DateTime.Parse(lineElems[3].Replace("_", " ")), lineElems[4], lineElems[5], Convert.ToUInt32(lineElems[6]), Convert.ToUInt32(lineElems[7]), Convert.ToBoolean(lineElems[8])));
			}
		}

		public void UpdateOrder(TaxiOrder orderToUpdate)
		{
			for (int i = 0; i < allOrders.Count; ++i)
			{
				if (allOrders[i].Id == orderToUpdate.Id)
				{
					allOrders[i] = orderToUpdate;
					break;
				}
			}
		}

		public void WriteToFile()
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				foreach (TaxiOrder order in allOrders)
				{
					writer.WriteLine(order);
                }
			}
		}
	}
}
