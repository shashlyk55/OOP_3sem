using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06
{
    internal class Bench : Inventory, ISport
    {
        public Bench(int cost)
        {
            _weight = 0f;
            CountOfPeople = 0;
            CountOfThingsInInventory++;
            Cost = cost;
        }
        public const string Name = "Скамейка";
        //protected int _cost;
        //public int Cost { get { return _cost; } set { _cost = value; } }
        private int _countOfPeople;
        public int CountOfPeople { get { return _countOfPeople; } set { _countOfPeople = value; } }
        private float _weight;
        public float GetWeight()
        {
            return _weight;
        }
        public void SetWeight(float weight)
        {
            _weight = weight;
        }
        public override string ToString()
        {
            return ($"{Name}\nЦена: {Cost}\nВес: {_weight}\nМаксимальное число людей на скамейке: {CountOfPeople}\n");
        }

    }
    internal class Bars : Inventory, ISport
    {
        public Bars(int cost)
        {
            CountOfThingsInInventory++;
            Cost = cost;

        }
        public const string Name = "Брусья";
        //protected int _cost;
        //public int Cost { get { return _cost; } set { _cost = value; } }
        private float _maxWeightOnBars;
        private float _weight;
        public float GetMaxWeight()
        {
            return _weight;
        }
        public void SetMaxWeight(float maxWeight)
        {
            _maxWeightOnBars = maxWeight;
        }
        public float GetWeight()
        {
            return _maxWeightOnBars;
        }
        public void SetWeight(float weight)
        {
            _weight = weight;
        }
        public override string ToString()
        {
            return ($"{Name}\nЦена: {Cost}\nМаксимальный вес на брусьях: {_maxWeightOnBars}\n");
        }
    }
    internal class Mats : Inventory, ISport
    {
        public Mats(int cost)
        {
            CountOfThingsInInventory++;
            Cost = cost;
        }
        public const string Name = "Маты";
        //private float _cost;
        //public float Cost { get { return _cost; } set { _cost = value; } }
        private float _weight;
        public float GetWeight()
        {
            return _weight;
        }
        public void SetWeight(float weight)
        {
            _weight = weight;
        }

        public override string ToString()
        {
            return ($"{Name}\nЦена: {Cost}\nВес: {_weight}\n");
        }
    }
    internal abstract class Ball : Inventory, ISport
    {
        public abstract void SetWeight(float weight);

        public abstract float GetWeight();
        public abstract void Playing();
        public abstract void Shot();


    }
    internal sealed class BasketBall : Ball, ISport
    {
        public BasketBall(int cost)
        {
            CountOfThingsInInventory++;
            Cost = cost;
        }
        public const string Name = "Баскетбольный мяч";
        //private float _cost;
        //public float Cost { get { return _cost; } set { _cost = value; } }
        private float _weight;
        public override float GetWeight()
        {
            return _weight;
        }
        void ISport.SetWeight(float weight)
        {
            _weight = weight;
        }
        public override void SetWeight(float weight)
        {
            _weight = weight;
        }
        public override void Playing()
        {
            Console.WriteLine("Играем в баскетбол\n");
        }
        public override void Shot()
        {
            Console.WriteLine("бросок баскетбольного мяча\n");
        }

        public override string ToString()
        {
            return ($"{Name}\nЦена: {Cost}\n");
        }
    }
    internal sealed class VolleyBall : Ball, ISport
    {
        public VolleyBall(int cost)
        {
            CountOfThingsInInventory++;
            Cost = cost;
        }
        public const string Name = "Волейбольный мяч";
        //private float _cost;
        //public float Cost { get { return _cost; } set { _cost = value; } }
        private float _weight;
        public override float GetWeight()
        {
            return _weight;
        }
        public override void SetWeight(float weight)
        {
            _weight = weight;
        }
        public override void Playing()
        {
            Console.WriteLine("Играем в волейбол\n");
        }
        public override void Shot()
        {
            Console.WriteLine("бросок волейбольного мяча\n");
        }
        public override string ToString()
        {
            return ($"{Name}\nЦена: {Cost}\n");
        }

    }

}
