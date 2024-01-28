using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    partial class Bus
    {
        private int _busNumber;
        private string _driverLastName;
        private string _driverInitials;
        private int _routeNumber;
        private string _busBrand;
        private int _startYear;
        private int _mileage;

        public const string NameOfCompany = "BelAvtoTrans";

        public readonly int Id;

        private static int _numberOfBuses = 0;
    }
}
