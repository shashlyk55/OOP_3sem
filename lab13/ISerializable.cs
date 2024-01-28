using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    internal interface ISerializable
    {
        void Serialization(object obj);
        object Deserialization(string path);
    }
}
