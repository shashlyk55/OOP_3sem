using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    static class StaticOperations
    {
        static public object SummaryMaxMin(this ListClass<float> spisok)
        {
            float sum = (float)spisok.list.Min() + (float)spisok.list.Max();
            return sum;
        }
        static public object SummaryMaxMin(this ListClass<int> spisok)
        {
            float sum = (float)spisok.list.Min() + (float)spisok.list.Max();
            return sum;
        }
        static public object SummaryMaxMin(this ListClass<double> spisok)
        {
            float sum = (float)spisok.list.Min() + (float)spisok.list.Max();
            return sum;
        }

        static public object DifferenceMaxMin(this ListClass<float> spisok)
        {
            object dif = (float)spisok.list.Max() - (float)spisok.list.Min();
            return dif;
        }
        static public object DifferenceMaxMin(this ListClass<int> spisok)
        {
            object dif = (int)spisok.list.Max() - (int)spisok.list.Min();
            return dif;
        }
        static public object DifferenceMaxMin(this ListClass<double> spisok)
        {
            object dif = (int)spisok.list.Max() - (int)spisok.list.Min();
            return dif;
        }

        static public int CountOfElements(this ListClass<float> spisok)
        {
            int count = 0;
            foreach (var element in spisok.list)
            {
                count++;
            }
            return count;
        }
        static public int CountOfElements(this ListClass<int> spisok)
        {
            int count = 0;
            foreach (var element in spisok.list)
            {
                count++;
            }
            return count;
        }
        static public int CountOfElements(this ListClass<double> spisok)
        {
            int count = 0;
            foreach (var element in spisok.list)
            {
                count++;
            }
            return count;
        }
        static public int CountOfElements(this ListClass<string> spisok)
        {
            int count = 0;
            foreach (var element in spisok.list)
            {
                count++;
            }
            return count;
        }
        static public string StrTrim(this string str, int length) => str.Substring(0, length);

        static public object ListSum(this ListClass<float> spisok)
        {
            float sum = 0;
            foreach (var element in spisok.list)
            {
                sum += (float)element;
            }
            return sum;
        }
        static public object ListSum(this ListClass<int> spisok)
        {
            float sum = 0;
            foreach (var element in spisok.list)
            {
                sum += (float)element;
            }
            return sum;
        }
        static public object ListSum(this ListClass<double> spisok)
        {
            float sum = 0;
            foreach (var element in spisok.list)
            {
                sum += (float)element;
            }
            return sum;
        }
    }
}
