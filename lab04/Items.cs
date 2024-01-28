using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
	internal class Bench : Inventory, ISport
	{
		public Bench()
		{
			_weight = 0f;
			CountOfPeople = 0;
			countOfThings++;
		}
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
            return ($"Скамейка\nВес: {_weight}\nМаксимальное число людей на скамейке: {CountOfPeople}\n");
        }

	}
	internal class Bars : Inventory, ISport
	{
		public Bars()
		{
			countOfThings++;
		}
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
            return ($"Брусья\nМаксимальный вес на брусьях: {_maxWeightOnBars}\n");
        }
    }
	internal class Mats : Inventory, ISport
	{
		public Mats()
		{
			countOfThings++;
		}
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
            return ($"Маты\nВес: {_weight}\n");
        }
    }
	internal abstract class Ball : Inventory, ISport
	{
		public abstract void SetWeight(float weight);

		public abstract float GetWeight();
		public abstract void Playing();
		public abstract void Shot();

    
    }
    /*internal abstract class Ball : Inventory, ISport
	{
		public abstract void SetWeight(float weight);

		public abstract float GetWeight();
		public abstract void Playing();
		public virtual void Shot()
        {
            Console.WriteLine("бросок мяча");
        }

    
    }*/
	internal sealed class BasketBall : Ball, ISport
	{
		public BasketBall()
		{
			countOfThings++;
		}
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
            return ($"Баскетбольный мяч\n");
        }
    }
	internal sealed class VolleyBall : Ball, ISport
	{
		public VolleyBall()
		{
            countOfThings++;
        }
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
			return ("Волейбольный мяч\n");
		}

	}

}
