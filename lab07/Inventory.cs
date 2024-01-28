using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lab07
{
    internal class Inventory
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private int cost;
        public int Cost { get { return cost; } set { cost = value; } }

        public Inventory(string name, int cost)
        {
            this.name = name;
            this.cost = cost;
        }

        public override string ToString()
        {
            return $"Имя: {name}\nЦена: {cost}\n";
        }


        
    }
}
