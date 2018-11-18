using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiDriverApp.DataTypes
{
	public class TaxiOrder
	{
		private uint id;
		private TaxiClient client;
		private TaxiDriver driver;
		private DateTime arriveTime;
		private string dispatch;
		private string destination;
		private uint roadTime;
		private uint cost;
		private bool isDone;

		public uint Id
		{
			get
			{
				return id;
			}

			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Id cant be <0");
				}

				id = value;
			}
		}

		public TaxiClient Client
		{
			get
			{
				return client;
			}

			set
			{
				client = value;
			}
		}

		public TaxiDriver Driver
		{
			get
			{
				return driver;
			}

			set
			{
				driver = value;
			}
		}

		public DateTime ArriveTime
		{
			get
			{
				return arriveTime;
			}

			set
			{
				arriveTime = value;
			}
		}

		public string Dispatch
		{
			get
			{
				return dispatch;
			}

			set
			{
				if (value == null)
				{
					throw new ArgumentOutOfRangeException("Dispatch is not set!");
				}
				dispatch = value;
			}
		}

		public string Destination
		{
			get
			{
				return destination;
			}

			set
			{
				if (value.Equals(dispatch))
				{
					throw new ArgumentOutOfRangeException("Destination and dispatch are the same place!");
				}
				destination = value;
			}
		}

		public uint RoadTime
		{
			get
			{
				return roadTime;
			}

			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Road time can only be >= than 0!");
				}
				roadTime = value;
			}
		}

		public uint Cost
		{
			get
			{
				return cost;
			}

			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Cost must be >= than 0!");
				}
				cost = value;
			}
		}

		public bool IsDone
		{
			get
			{
				return isDone;
			}

			set
			{
				isDone = value;
			}
		}

		public TaxiOrder()
		{
		}

		public TaxiOrder(uint _id, TaxiClient _client, TaxiDriver _driver, DateTime _arrive, string _dispatch, string _destination, uint _roadTime, uint _cost = 0, bool _isDone = false)
		{
			Id = _id;
			Client = _client;
			Driver = _driver;
			ArriveTime = _arrive;
			Dispatch = _dispatch;
			Destination = _destination;
			RoadTime = _roadTime;
			Cost = _cost;
			IsDone = _isDone;
		}

		public override string ToString()
		{
			return String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", Id, Client.Id, Driver.Id, ArriveTime.ToString("yyyy-MM-dd_HH:mm"), Dispatch, Destination, RoadTime, Cost, IsDone);
		}
	}
}
