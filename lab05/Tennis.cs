using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    internal class Tennis : Object
    {
        private enum MultipleWinner
        {
            OnceTime = 1,
            TwoTime,
            ThreeTime,
            FourTime,
            FiveTime,
            SixTime,
            SevenTime
        }
        private struct Info
        {
            public string Name { get; set; }
            public int Wins { get; set; }
            public int Loses { get; set; }
            public MultipleWinner WinStreak { get; set; }
        }
        Info info = new Info();


        public Tennis(string player, int wins, int loses, int winStreak)
        {
            
            info.Name = player;
            info.Wins = wins;
            info.Loses = loses;
            info.WinStreak = (MultipleWinner)winStreak;
        }


        public bool Equals(Tennis obj)
        {
            if ((info.Loses == obj.info.Loses) && (info.Wins == obj.info.Wins))
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            Random random = new Random();
            info.Wins = random.Next(10);
            info.Loses = random.Next(10);
            return 0;
        }
        public override string ToString()
        {
            return ($"Имя: {info.Name}\nПобеды: {info.Wins}\nПоражения: {info.Loses}\nБеспроигрышных матчей: {(int)info.WinStreak}\n");

        }
        


    }
}
