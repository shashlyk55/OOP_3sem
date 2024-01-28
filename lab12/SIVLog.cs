using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{

    /*
    1. Создать класс XXXLog. Он должен отвечать за работу с текстовым файлом 
    xxxlogfile.txt. в который записываются все действия пользователя и 
    соответственно методами записи в текстовый  файл, чтения, поиска нужной 
    информации. 
        a. Используя данный класс выполните запись всех 
        последующих действиях пользователя с указанием действия, 
        детальной информации (имя файла, путь) и времени 
        (дата/время) 

    6.Найдите и выведите сохраненную информацию в файле xxxlogfile.txt о 
    действиях пользователя за определенный  день/ диапазон времени/по 
    ключевому слову. Посчитайте количество записей в нем. Удалите  часть 
    информации, оставьте только записи за текущий час. 
    */

    static public class SIVLog
    {
        static public int GetCountOfNotes(string logFile)
        {
            int count = 0;
            using(StreamReader reader = new StreamReader(logFile))
            {
                while(reader.ReadLine() != null)
                {
                    count++;
                }
            }
            return count;
        }
        static public string GetInfoForPeriod(string logFile, string startPeriod, string endPeriod)
        {
            string text = "";
            string buffer;
            string[] arr1;
            string[] arrDate;
            string date;
            string[] arr2;
            string day, month, year;
            int count = 0;

            string sDay, sMonth, sYear;
            string eDay, eMonth, eYear;

            sDay = startPeriod.Split('.')[0];
            sMonth = startPeriod.Split('.')[1];
            sYear = startPeriod.Split('.')[2];
            
            eDay = endPeriod.Split('.')[0];
            eMonth = endPeriod.Split('.')[1];
            eYear = endPeriod.Split('.')[2];

            bool comp(string a, string b)
            {
                return Convert.ToInt32(a) >= Convert.ToInt32(b);
            }

            using (StreamReader reader = new StreamReader(logFile))
            {
                while (reader != null || !reader.EndOfStream)
                {
                    buffer = reader.ReadLine();
                    if (buffer == null) break; 
                    arr1 = buffer.Split(';');
                    arrDate = arr1[0].Split(' ');
                    date = arrDate[0];

                    arr2 = date.Split('.');
                    day = arr2[0];
                    month = arr2[1];
                    year = arr2[2];

                    if (comp(eYear, year) && comp(year, sYear) && comp(eMonth, month) && comp(month, sMonth) && comp(eDay, day) && comp(day, sDay))
                    {
                        Console.WriteLine(buffer);
                    }
                }
                
            }


            return text;

        }

    }
}
