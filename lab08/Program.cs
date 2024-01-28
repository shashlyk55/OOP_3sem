using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace lab08
{
    
    internal class Program
    {
        static void Main()
        {
            try
            {
                User Alex = new User(1.2f, 40);
                User Nick = new User(1, 0);

                Alex.Upgraded += (message) => Console.WriteLine("Alex: " + message);
                Alex.Withdrawn += (message) => Console.WriteLine("Alex: " + message);
                Nick.Worked += (message) => Console.WriteLine("Nick: " + message);

                Alex.WorkApp(100);  // Alex не подписан на событие Worked/Working
                Alex.UpgradeApp(0.2f);
                Alex.Withdraw(150);

                Nick.WorkApp(270);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ///////////////////////
            //StringProcessing operator = new StringProcessing();

            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            string str1 = "Hello world fjfeh";
            string str2 = "world";

            Func<string, string, string> StrOp;

            Predicate<string> IsEmpty = (s1) =>
            {
                return (s1 == "" || s1 == null);
            };

            StringProcessing.Printing += (s) => Console.WriteLine("Строка: " + s);

            StringProcessing.DeletePunctuation(ref str);
            StringProcessing.DelGaps(ref str);
            StringProcessing.ConvertToNumbers(ref str);

            StrOp = (s1, s2) => s1 + s2;    // конкатенация

            Console.WriteLine(StrOp(str1,str2));

            StrOp += (s1, s2) =>            // удаление подстроки в строке
            {
                int i;
                while (s1.IndexOf(s2) != -1)
                {
                    s1 = s1.Replace(s2, "");
                }
                return s1;
            };
            Console.WriteLine(StrOp(str1,str2));

            Console.WriteLine(IsEmpty(str) ? "Строка пустая" : "Строка не пустая");




        }
    }
}
