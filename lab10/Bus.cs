using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    /*Создать класс Bus: Фамилия  и  инициалы  водителя, 
    Номер автобуса, Номер маршрута, Марка, Год начала 
    эксплуатации, Пробег. Свойства и конструкторы должны 
    обеспечивать проверку корректности.  Добавить метод 
    вывода возраста автобуса. 
    Создать массив объектов. Вывести: 
    a)  список автобусов для заданного номера маршрута; 
    b)  список автобусов, которые эксплуатируются больше 
    заданного срока; */
    internal partial class Bus
    {
        private int _numberOfBus;
        private string _driversLastName;
        private string _driversInitials;
        private int _numberOfRoute;
        private string _brandOfBus;
        private int _yearOfStart;
        private int _countOfMiles;

        public const string NameOfCompany = "BelAvtoTrans";

        public readonly int Id;

        private static int _numberOfBuses = 0;

        public int BusCount { get { return _numberOfBuses; } }

        public string DriverLastName
        {
            get => _driversLastName;
            set
            {
                bool flag = true;
                if (value != null || value != "")
                    foreach (var ch in value)
                    {
                        if ((ch > 'z' && ch < 'A') || (ch > 'я' && ch < 'А'))
                            flag = false;
                    }
                if (flag) _driversLastName = value;

                else throw new Exception("Некорректно введена фамилия водителя\n");

            }
        }

        public string DriverInitials
        {
            get => _driversInitials;
            set
            {
                bool flag = true;
                if (value != null || value != "")
                    foreach (var ch in value)
                    {
                        if (((ch > 'z' && ch < 'A') || (ch > 'я' && ch < 'А')) && ch != '.')
                            flag = false;
                    }

                if (flag) _driversInitials = value;

                else throw new Exception("Некорректно введены инициалы водителя\n");
            }
        }

        public int BusNumber
        {
            get => _numberOfBus;
            set
            {
                if (value > 0) _numberOfBus = value;
                else throw new Exception("Некорректно введен номер автобуса\n");
            }
        }

        public int RouteNumber
        {
            get { return _numberOfRoute; }
            set
            {
                if (value > 0) _numberOfRoute = value;
                else throw new Exception("Некорректно введен номер маршрута\n");
            }
        }

        public string BusBrand
        {
            get => _brandOfBus;
            set
            {
                if (value != null || value != "") _brandOfBus = value;
                else throw new Exception("Некорректно введена марка автобуса");
            }
        }

        public int StartYear
        {
            get => _yearOfStart;
            private set
            {
                if (value > 0 && value < DateTime.Today.Year) _yearOfStart = value;
                else throw new Exception("Некорректно введен год\n");
            }
        }

        public int Mileage
        {
            get => _countOfMiles;
            set
            {
                if (value > 0) _countOfMiles = value;
                else throw new Exception("Некорректно введен пробег трнспорта");
            }
        }
    }
}
