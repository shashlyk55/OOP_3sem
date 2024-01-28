using lab13;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web.Script.Serialization;
using System.Xml;

namespace lab13
{
    public class JSONSerializer : ISerializable
    {
        public void Serialization(object obj)
        {
            using (FileStream fs = new FileStream("info.json", FileMode.OpenOrCreate))
            {
                System.Text.Json.JsonSerializer.Serialize(fs, obj);
            }
        }
        public object Deserialization(string path)
        {
            object obj = null;

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                obj = System.Text.Json.JsonSerializer.Deserialize<Tennis>(fs);
            }

            return obj;
        }
        public void SerializationList(List<Tennis> list)
        {
            //JavaScriptSerializer jSearializer = new JavaScriptSerializer();
            string jsonData = JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"listInfo.json", jsonData);
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
