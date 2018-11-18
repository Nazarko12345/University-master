using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TaxiDriverApp.DataTypes;

namespace TaxiDriverApp.IOTypes
{
	public class ClientsDB
	{
		private string fileName;
		private List<TaxiClient> allClients;

		public List<TaxiClient> AllClients
		{
			get
			{
				return allClients;
			}

			set
			{
				if (value.Count == 0)
				{
					throw new ArgumentOutOfRangeException("ClientsDB is empty");
				}

				allClients = value;
			}
		}

		public ClientsDB(string _fileName)
		{
			allClients = new List<TaxiClient>();
			fileName = _fileName;
		}

		public void ReadFromFile()
		{
			string[] allLines = File.ReadAllLines(fileName);
			foreach (string line in allLines)
			{
				string[] lineElems = line.Split(' ');
				allClients.Add(new TaxiClient(Convert.ToUInt32(lineElems[0]), lineElems[1], lineElems[2]));
			}
		}

		public void WriteToFile()
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				foreach (TaxiClient client in allClients)
				{
					writer.WriteLine(client);
				}
			}
		}

		public TaxiClient GetClientById(uint clientId)
		{
			TaxiClient searchResult = new TaxiClient();
			foreach (TaxiClient client in allClients)
			{
				if (client.Id == clientId)
				{
					searchResult = client;
					break;
				}
			}

			return searchResult;
		}
	}
}
