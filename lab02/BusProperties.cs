using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Cars
{
	partial class Bus
	{
		public string DriverLastName
		{
			get
			{
				return _driverLastName;
			}
			set
			{
				bool flag = true;
				if (value != null)
				{
					foreach (var ch in value)
					{
						if ((ch > 'z' && ch < 'A') || (ch > 'я' && ch < 'А'))
						{
							flag = false;
						}
					}
				}
				if (flag)
				{
					_driverLastName = value;
				}
				else
				{
					Console.WriteLine("Некорректно введена фамилия водителя\n");
				}
			}
		}

		public string DriverInitials
		{
			get
			{
				return _driverInitials;
			}
			set
			{
				bool flag = true;
				if (value != null)
				{
					foreach (var ch in value)
					{
						if (((ch > 'z' && ch < 'A') || (ch > 'я' && ch < 'А')) && ch != '.')
						{
							flag = false;
						}
					}
				}
				if (flag)
				{
					_driverInitials = value;
				}
				else
				{
					Console.WriteLine("Некорректно введены инициалы водителя\n");
				}

				
			}
		}

		public int BusNumber
		{
			get
			{
				return _busNumber;
			}
			set
			{
				if (value > 0)
				{
					_busNumber = value;
				}
				else
				{
					Console.WriteLine("Некорректно введен номер автобуса\n");
				}
			}
		}

		public int RouteNumber
		{
			get
			{
				return _routeNumber;
			}
			set
			{
				if (value > 0)
				{
					_routeNumber = value;
				}
                else
                {
                    Console.WriteLine("Некорректно введен номер маршрута\n");
                }
            }
		}

		public string BusBrand
		{
			get
			{
				return _busBrand;
			}
			set
			{
                bool flag = true;
				if (value != null)
				{
					foreach (var ch in value)
					{
						if ((ch > 'z' && ch < 'A') || (ch > 'я' && ch < 'А'))
						{
							flag = false;
						}
					}
				}
                if (flag)
                {
                    _busBrand = value;
                }
                else
                {
                    Console.WriteLine("Некорректно введена марка автобуса\n");
                }
            }
		}

		public int StartYear
		{
			get
			{
				return _startYear;
			}
			private set
			{
				if (value > 0 && value < DateTime.Today.Year)
				{
					_startYear = value;
				}
				else
				{
					Console.WriteLine("Некорректно введен год\n");
				}
			}
		}

		public int Mileage
		{
			get
			{
				return _mileage;
			}
			set
			{
				if (value > 0)
				{
					_mileage = value;
				}
				else
				{
					Console.WriteLine("Некорректно введен пробег трнспорта\n");
				}
			}
		}
	}
}
