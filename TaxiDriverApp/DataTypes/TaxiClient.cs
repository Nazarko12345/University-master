using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiDriverApp.DataTypes
{
	public class TaxiClient
	{
		private uint id;
		private string name;
		private string phoneNumber;

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
					throw new ArgumentOutOfRangeException("Client Id cant be < than 0");
				}

				id = value;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				if (String.IsNullOrEmpty(value))
				{
					throw new ArgumentOutOfRangeException("Name cant be empty");
				}
				name = value;
			}
		}

		public string PhoneNumber
		{
			get
			{
				return phoneNumber;
			}

			set
			{
				if (value.Length < 10 || value.Length > 13)
				{
					throw new ArgumentOutOfRangeException("Phone number is incorrect");
				}
				phoneNumber = value;
			}
		}

		public TaxiClient()
		{
		}

		public TaxiClient(uint _id, string _name, string _phoneNumber)
		{
			Id = _id;
			Name = _name;
			PhoneNumber = _phoneNumber;
		}

		public override string ToString()
		{
			return String.Format("{0} {1} {2}", Id, Name, PhoneNumber);
		}
	}
}
