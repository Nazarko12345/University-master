using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiDriverApp.DataTypes
{
	public class TaxiDriver
	{
		private uint id;
		private string surname;
		private string name;
		private uint age;
		private string carNumber;
		private uint experience;
		private uint costPerMinute;
		private double payCheck;

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
					throw new ArgumentOutOfRangeException("Driver id cant be < 0");
				}
				id = value;
			}
		}

		public string Surname
		{
			get
			{
				return surname;
			}

			set
			{
				if (String.IsNullOrEmpty(value))
				{
					throw new ArgumentOutOfRangeException("Drive surname cant be empty");
				}
				surname = value;
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
					throw new ArgumentOutOfRangeException("Drive name cant be empty");
				}
				name = value;
			}
		}

		public uint Age
		{
			get
			{
				return age;
			}

			set
			{
				if (value < 18)
				{
					throw new ArgumentOutOfRangeException("Driver is too young!");
				}
				age = value;
			}
		}

		public string CarNumber
		{
			get
			{
				return carNumber;
			}

			set
			{
				if (String.IsNullOrEmpty(value))
				{
					throw new ArgumentOutOfRangeException("Car Number cant be empty");
				}
				carNumber = value;
			}
		}

		public uint Experience
		{
			get
			{
				return experience;
			}

			set
			{
				if (value < 2)
				{
					throw new ArgumentOutOfRangeException("Drive has a small experience");
				}
				experience = value;
			}
		}

		public uint CostPerMinute
		{
			get
			{
				return costPerMinute;
			}

			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("Cost per minute cant be less then 0");
				}

				costPerMinute = value;
			}
		}

		public double PayCheck
		{
			get
			{
				return payCheck;
			}

			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("PayCheck cnat be < than 0");
				}
				payCheck = value;
			}
		}

		public TaxiDriver()
		{
			PayCheck = 0;
		}

		public TaxiDriver(uint _id, string _surname, string _name, uint _age, string _carNumber, uint _experience, uint _cost, double _pay = 0)
		{
			Id = _id;
			Surname = _surname;
			Name = _name;
			Age = _age;
			CarNumber = _carNumber;
			Experience = _experience;
			CostPerMinute = _cost;
			PayCheck = _pay;
		}

		public override string ToString()
		{
			return String.Format("{0} {1} {2} {3} {4} {5} {6} {7}", Id, Surname, Name, Age, CarNumber, Experience, CostPerMinute, PayCheck);
		}
	}
}
