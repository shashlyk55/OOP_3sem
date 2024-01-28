using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07
{
    public interface ICollection<T>
    {
        void Delete(int id);
        void Add(params T[] value);
        void Print();
        string ToString();
        
    }
}
