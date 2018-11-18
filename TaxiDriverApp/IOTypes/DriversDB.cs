using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TaxiDriverApp.DataTypes;

namespace TaxiDriverApp.IOTypes
{
	public class DriversDB
	{
		private string fileName;
		private List<TaxiDriver> allDrivers;

		public List<TaxiDriver> AllDrivers
		{
			get
			{
				return allDrivers;
			}

			set
			{
				if (value.Count == 0)
				{
					throw new ArgumentOutOfRangeException("DriversDB is empty");
				}

				allDrivers = value;
			}
		}

		public DriversDB(string _fileName)
		{
			allDrivers = new List<TaxiDriver>();
			fileName = _fileName;
		}

		public void ReadFromFile()
		{
			string[] allLines = File.ReadAllLines(fileName);
			foreach (string line in allLines)
			{
				string[] lineElems = line.Split(' ');
				allDrivers.Add(new TaxiDriver(Convert.ToUInt32(lineElems[0]), lineElems[1], lineElems[2], Convert.ToUInt32(lineElems[3]), lineElems[4], Convert.ToUInt32(lineElems[5]), Convert.ToUInt32(lineElems[6]), Convert.ToDouble(lineElems[7])));
			}
		}

		public void UpdateDriver(TaxiDriver driverToUpdate)
		{
			for (int i = 0; i < allDrivers.Count; ++i)
			{
				if (allDrivers[i].Id == driverToUpdate.Id)
				{
					allDrivers[i] = driverToUpdate;
					break;
				}
			}
		}

		public void WriteToFile()
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				foreach (TaxiDriver driver in allDrivers)
				{
					writer.WriteLine(driver);
				}
			}
		}

		public TaxiDriver FindDriver(string surname, string name)
		{
			TaxiDriver searchResult = new TaxiDriver();
			foreach (TaxiDriver driver in allDrivers)
			{
				if (driver.Surname == surname && driver.Name == name)
				{
					searchResult = driver;
					break;
				}
			}

			return searchResult;
		}

		public TaxiDriver GetDriverById(uint driverId)
		{
			TaxiDriver searchResult = new TaxiDriver();
			foreach (TaxiDriver driver in allDrivers)
			{
				if (driver.Id == driverId)
				{
					searchResult = driver;
					break;
				}
			}

			return searchResult;
		}
	}
}
