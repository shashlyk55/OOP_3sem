using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Создайте пять методов пользовательской обработки строки (например, 
удаление знаков препинания, добавление символов, замена на заглавные, 
удаление лишних пробелов и т.п.) 
*/

namespace lab08
{
    internal class StringProcessing
    {
        static public event Action<string> Printing;
         
        static public void DeletePunctuation(ref string s)
        {
            string res = "";
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',' || s[i] == '.' || s[i] == ';' || s[i] == ':')
                    continue;
                res += s[i];
            }
            s = res;

            if (Printing != null) Printing(s);
        }
        static public void DelGaps(ref string str)
        {
            string res = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ' && str[i - 1] == ' ')
                    while (str[i] == ' ') i++;
                res += str[i];
            }
            str = res;

            if (Printing != null) Printing(str);
        }

        static public void ConvertToNumbers(ref string s)
        {
            string res = "";
            for(int i = 0; i < s.Length; i++)
            {
                res += (int)s[i];
            }
            s = res;

            if (Printing != null) Printing(s);
        }

        
        

    }
}
