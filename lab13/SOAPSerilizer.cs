using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;
using System.Runtime.InteropServices.ComTypes;

namespace lab13
{
    public class SOAPSerializer : ISerializable
    {
        public void Serialization(object obj)
        {
            SoapFormatter formatter = new SoapFormatter();

            using (FileStream fs = new FileStream("info.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }
        public object Deserialization(string path)
        {
            object obj = null;

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                SoapFormatter formatter = new SoapFormatter();
                obj = formatter.Deserialize(fs);
            }

            return obj;
        }
    }
}
