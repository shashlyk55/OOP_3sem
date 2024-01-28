using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    internal class Tennis : Object
    {
        public Tennis(string player, int wins, int loses)
        {
            Player = player;
            Wins = wins;
            Loses = loses;
        }

        public string Player { get; set;}
        public int Wins { get; set;}
        public int Loses { get; set;}

        public bool Equals(Tennis obj)
        {
            if((Loses == obj.Loses) && (Wins == obj.Wins))
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            Random random = new Random();
            Wins = random.Next(10);
            Loses = random.Next(10);
            return 0;
        }
        public override string ToString()
        {
            return ($"Имя: {Player}\nПобеды: {Wins}\nПоражения: {Loses}\n");
        }



    }
}
