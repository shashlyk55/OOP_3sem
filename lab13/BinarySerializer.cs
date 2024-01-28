using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public class BinarySerializer : ISerializable
    {
        public void Serialization(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("info.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }
        public object Deserialization(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            object obj = null;

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                obj = formatter.Deserialize(fs);
            }

            return obj;
        }
    }
}
