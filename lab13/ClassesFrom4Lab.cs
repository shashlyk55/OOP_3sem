using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace lab13
{
    [Serializable]
    public class Tennis
    {
        public Tennis() { }
        public Tennis(string player, int wins, int loses)
        {
            Player = player;
            this.wins = wins;
            this.loses = loses;
        }
        
        private int loses;
        private int wins;
        public string Player { get; set; }
        public int Wins { get { return wins; } set { wins = value; } }
        //[JsonIgnore]
        public int Loses { get { return loses; } set { loses = value; } }

        public bool Equals(Tennis obj)
        {
            if ((Loses == obj.Loses) && (Wins == obj.Wins))
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            Random random = new Random();
            //Wins = random.Next(10);
            //Loses = random.Next(10);
            return 0;
        }
        public override string ToString()
        {
            return ($"Имя: {Player}\nПобеды: {wins}\nПоражения: {loses}\n");
        }
    }
        [Serializable]
    public abstract class Inventory
    {
        static protected int countOfThings = 0;
        public static int GetCountOfThings => countOfThings;
    }
    [Serializable]
    public abstract class Ball : Inventory
    {
        public abstract void SetWeight(float weight);
        public abstract float GetWeight();
        public abstract void Playing();
        public abstract void Shot();
    }
    [Serializable]
    internal sealed class BasketBall : Ball
    {
        private float _weight;
        public float Weight { get { return _weight; } }
        [NonSerialized]
        [JsonIgnore]
        public readonly string name = "basket";

        public BasketBall()
        {
            //countOfThings++;
        }
        public BasketBall(float weight)
        {
            _weight = weight;
            countOfThings++;
        }
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
            Console.WriteLine("Играем в баскетбол\n");
        }
        public override void Shot()
        {
            Console.WriteLine("бросок баскетбольного мяча\n");
        }

        public override string ToString()
        {
            return $"Баскетбольный мяч\nВес: {_weight}\n{name}";
        }
    }
    [Serializable]
    public class VolleyBall : Ball
    {
        private float _weight;
        [NonSerialized]
        [JsonIgnore]
        public readonly string name = "volley";
        public VolleyBall()
        {
            countOfThings++;
        }
        public VolleyBall(float weight)
        {
            _weight = weight;
            countOfThings++;
        }
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
            return $"Волейбольный мяч\nВес: {_weight}\n{name}";
        }

    }
}
