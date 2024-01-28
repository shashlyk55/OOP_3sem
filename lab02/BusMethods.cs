using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/*Создать класс Bus: Фамилия  и  инициалы  водителя, 
Номер автобуса, Номер маршрута, Марка, Год начала 
эксплуатации, Пробег. Свойства и конструкторы должны 
обеспечивать проверку корректности.  Добавить метод 
вывода возраста автобуса. 
Создать массив объектов. Вывести: 
a)  список автобусов для заданного номера маршрута; 
b)  список автобусов, которые эксплуатируются больше 
заданного срока; */

namespace Cars
{
	partial class Bus
	{
		public Bus(int busNumber , int routeNumber, short startYear, int mileage, string driverLastName = null, string driverInitials = null, string busBrand = "MAZ")
		{
			_driverLastName = driverLastName;
			_driverInitials = driverInitials;
			_busNumber = busNumber;
			_routeNumber = routeNumber;
			_busBrand = busBrand;
			_startYear = startYear;
			_mileage = mileage;

			Id = GetHashCode();
		}

		public Bus(string lastName, int busNumber, short startYear)
		{
			_startYear = startYear;
			_driverLastName = lastName;
			_busNumber = busNumber;
			_numberOfBuses++;
			
			Id = GetHashCode();
		}

		public Bus(int busNumber,  int routeNumber, string busBrand = "MAZ")
		{
			_routeNumber = routeNumber;
			_busNumber = busNumber;
			_busBrand = busBrand;
			_numberOfBuses++;
			
			Id = GetHashCode();
		}

		//private Bus() { }


		public void ChangeingBusDrivers(ref Bus bus1, ref Bus bus2)
		{
			string buffer = bus1._driverLastName;
			bus1._driverLastName = bus2._driverLastName;
			bus2._driverLastName = buffer;

			buffer = bus1._driverInitials;
			bus1._driverInitials = bus2._driverInitials;
			bus2._driverInitials = buffer;
		}


		public int GetAgeOfBus()
		{
			int currentYear = DateTime.Now.Year;
			return currentYear - this._startYear;
		}
		public string GetDriver()
		{
			return _driverLastName + _driverInitials;
		}
		public override string ToString()
		{
			return($"Компания: {Bus.NameOfCompany}\nid: {this.Id}\n" +
				$"Водитель: {this._driverLastName} {this._driverInitials}\n" +
				$"Марка автобуса: {this._busBrand}\nНомер автобуса: {this._busNumber}\n" +
				$"Год начала эксплуатации: {this._startYear}\nПробег: {this._mileage}\n" +
				$"Маршрут #{this._routeNumber}");
		}
		public override bool Equals(object bus)
		{
			if (bus == null || (bus is Bus))
			{
				return false;
			}

			Bus obj = bus as Bus;
			return obj._startYear == (bus as Bus)._startYear;
		}

		public override int GetHashCode()
		{
			return _busNumber ^ _startYear;
		}
	}
}
