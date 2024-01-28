using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Создать класс Bus: Фамилия  и  инициалы  водителя, 
Номер автобуса, Номер маршрута, Марка, Год начала 
эксплуатации, Пробег. Свойства и конструкторы должны 
обеспечивать проверку корректности.  Добавить метод 
вывода возраста автобуса. 
Создать массив объектов. Вывести: 
a)  список автобусов для заданного номера маршрута; 
b)  список автобусов, которые эксплуатируются больше 
заданного срока; */

namespace lab10
{
	internal partial class Bus
	{
		public Bus(int busNumber, int routeNumber, short startYear, int mileage, string driverLastName, string driverInitials, string busBrand = "MAZ")
		{

		}

		public Bus(int busNumber, int routeNumber, string busBrand = "MAZ")
		{
			_numberOfRoute = routeNumber;
			_numberOfBus = busNumber;
			_brandOfBus = busBrand;
			_numberOfBuses++;

			Id = GetHashCode();
		}

		public Bus(string driverLastName ,int busNumber ,int routeNumber, int startYear, int mileage)
		{
			_driversLastName = driverLastName;
            _numberOfBus = busNumber;
            _numberOfRoute = routeNumber;
            _yearOfStart = startYear;
			_countOfMiles = mileage;

			_numberOfBuses++;
			Id = GetHashCode();
		}


		public int GetAgeOfBus()
		{
			int currentYear = DateTime.Now.Year;
			return currentYear - this._yearOfStart;
		}
		public string GetDriver()
		{
			return _driversLastName + _driversInitials;
		}
		public override string ToString()
		{
			return ($"Компания: {Bus.NameOfCompany}\nid: {this.Id}\n" +
				$"Водитель: {this._driversLastName} {this._driversInitials}\n" +
				$"Марка автобуса: {this._brandOfBus}\nНомер автобуса: {this._numberOfBus}\n" +
				$"Год начала эксплуатации: {this._yearOfStart}\nПробег: {this._countOfMiles}\n" +
				$"Маршрут #{this._numberOfRoute}");
		}
		public override bool Equals(object bus)
		{
			if (bus == null || (bus is Bus))
			{
				return false;
			}

			Bus obj = bus as Bus;
			return obj._yearOfStart == obj._yearOfStart;
		}

		public override int GetHashCode()
		{
			return _numberOfBus ^ _yearOfStart;
		}

		
	}
}
