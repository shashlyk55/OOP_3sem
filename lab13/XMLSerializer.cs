using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace lab13
{
    public class XMLSerializer : ISerializable
    {
        public void Serialization(object obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Tennis));

            using (FileStream fs = new FileStream("info.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, obj as Tennis);
            }
        }
        public object Deserialization(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Tennis));
            object obj = null;

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                obj = xmlSerializer.Deserialize(fs);
            }

            return obj;
        }
        public void SerializationList(List<Tennis> list)
        {
            //JavaScriptSerializer jSearializer = new JavaScriptSerializer();
            string jsonData = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(@"listInfo.xml", jsonData);
        }
        public List<Tennis> DeserializationList(string path)
        {
            List<Tennis> list = null;
            string json = File.ReadAllText(path);
            list = System.Text.Json.JsonSerializer.Deserialize<List<Tennis>>(json);
            return list;
        }
    }
}
