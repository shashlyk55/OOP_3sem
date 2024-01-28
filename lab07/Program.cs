using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace lab07
{
    /*
    1. Создайте обобщенный интерфейс с операциями добавить, удалить, 
    просмотреть. 
    2. Возьмите за основу лабораторную № 3 «Перегрузка операций» и 
    сделайте из нее обобщенный тип (класс) CollectionType<T>, в который 
    вложите обобщённую коллекцию. Наследуйте в обобщенном классе интерфейс 
    из п.1. Реализуйте необходимые методы. 
    3. Проверьте использование обобщения для стандартных типов данных (в 
    качестве стандартных типов использовать целые, вещественные и т.д.).  
    4. Определить пользовательский класс, который будет использоваться в 
    качестве параметра обобщения. Для пользовательского типа взять класс из 
    лабораторной  №4 «Наследование».  
    5. Добавьте методы сохранения объектов обобщённого типа 
    CollectionType<T>  в файл и чтения из него ( на выбор: текстовый | xml | json).
    */
    internal class Program
    {
        static void Main()
        {
            Collection<int> arr = new Collection<int>(2, 7, 4);
            
            try
            {
                Console.WriteLine(arr[8]);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            try
            {
                arr.Add(8, 9);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();

            Collection<Inventory> items = new Collection<Inventory>();

            Inventory ball = new Inventory("мяч", 10);
            Inventory bars = new Inventory("брусья", 30);
            Inventory bench = new Inventory("скамейка", 20);

            try
            {
                items.Add(ball, bars, bench);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            items.Print();

            ICollection <Inventory> icollect = new Collection<Inventory>();
            icollect.Add(ball, bench);

            string xmlFile = "Gym.xml";


            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclar;
            xmlDeclar = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(xmlDeclar);
            XmlElement xmlRoot = xmlDoc.CreateElement("gym");

            XmlElement itemElement;
            XmlElement costElement;
            XmlAttribute nameAttr;

            XmlText nameText;
            XmlText costText;

            for (int i = 0; i < items.Count; i++)
            {
                itemElement = xmlDoc.CreateElement("item");
                costElement = xmlDoc.CreateElement("cost");
                nameAttr = xmlDoc.CreateAttribute("name");

                nameText = xmlDoc.CreateTextNode(items[i].Name);
                costText = xmlDoc.CreateTextNode(Convert.ToString(items[i].Cost) + "$");

                nameAttr.AppendChild(nameText);
                itemElement.Attributes.Append(nameAttr);
                costElement.AppendChild(costText);

                itemElement.AppendChild(costElement);
                xmlRoot.AppendChild(itemElement);
                xmlDoc.AppendChild(xmlRoot);

                xmlDoc.Save(xmlFile);
            }
        }
    }
}
