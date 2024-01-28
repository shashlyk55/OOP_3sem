using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;


/*
 1. Из лабораторной №4 выберите класс с наследованием и/или 
композицией/агрегацией для сериализации. Выполните 
сериализацию/десериализацию объекта используя форматы:   
a. Binary, 
b. SOAP, 
c. JSON, 
d. XML. 
Запретите сериализацию одного из членов вашего класса и 
продемонстрируйте отсутствие данного элемента в результате работы 
сериализаторов 
Все сериализаторы должен реализовывать общий интерфейс. Выбор и 
использование сериализатора следует реализовать таким образом, чтобы 
добавление нового сериализатора не требовало изменения существующего 
кода 
2. Создайте коллекцию (массив) объектов и выполните 
сериализацию/десериализацию – возможность сохранения и загрузки 
спсика объектов в/из файла.  
3. Используя XPath напишите два селектора для вашего XML документа. 
4. Используя Linq to XML (или Linq to JSON) создайте новый xml (json) - 
документ и напишите несколько запросов.
*/

namespace lab13
{
    internal class Program
    {
        static void Main()
        {
            // Исходный объект
            Tennis game = new Tennis("Bob", 1, 2);

            // JSON сериализация
            JSONSerializer serializer = new JSONSerializer();

            serializer.Serialization(game);
            Tennis jsonRestoredPastry = serializer.Deserialization("info.json") as Tennis;

            Console.WriteLine("JSON десериализация:");
            Console.WriteLine(jsonRestoredPastry);

            Console.WriteLine();

            // XML сериализация
            XMLSerializer xmlSerializer = new XMLSerializer();

            xmlSerializer.Serialization(game);
            Tennis xmlRestoredPastry = xmlSerializer.Deserialization("info.xml") as Tennis;

            Console.WriteLine("XML десериализация:");
            Console.WriteLine(xmlRestoredPastry);

            Console.WriteLine();

            // SOAP сериализация
            SOAPSerializer soapSerializer = new SOAPSerializer();

            soapSerializer.Serialization(game);
            Tennis soapRestoredPastry = soapSerializer.Deserialization("info.soap") as Tennis;

            Console.WriteLine("SOAP десериализация:");
            Console.WriteLine(soapRestoredPastry);

            Console.WriteLine();

            // Binary сериализация
            BinarySerializer binarySerializer = new BinarySerializer();

            binarySerializer.Serialization(game);
            Tennis binaryRestoredPastry = binarySerializer.Deserialization("info.dat") as Tennis;

            Console.WriteLine("Binary десериализация:");
            Console.WriteLine(binaryRestoredPastry);

            Console.WriteLine();

            // JSON сериализация списка
            List<Tennis> pastryArr = new List<Tennis> {
                new Tennis("Billy", 10, 5),
                new Tennis("Paul", 3, 7),
                new Tennis("Max", 8, 4),
                new Tennis("Tom", 1, 9)
            };

            serializer.SerializationList(pastryArr);
            List<Tennis> jsonRestoredPastryArr = serializer.DeserializationList("listInfo.json");

            Console.WriteLine("JSON десериализация списка:");
            foreach (var p in jsonRestoredPastryArr)
                Console.WriteLine(p);

            Console.WriteLine();


            // XPath
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("info.xml");

            XmlElement xRoot = xDoc.DocumentElement;

            // Список всех дочерних узлов
            Console.WriteLine("Список всех дочерних узлов: ");
            XmlNodeList allNodes = xRoot?.SelectNodes("*");
            if (!(allNodes is null))
                foreach (XmlNode node in allNodes)
                    Console.Write($"{node.Name} ");

            // Конкретный узел с названием Wins
            Console.WriteLine("\n\nУзел с именем Wins: ");
            XmlNode wins = xRoot?.SelectSingleNode("Wins");
            Console.WriteLine($"Wins: {wins.InnerText}");

            // LINQ to XML
            XDocument xdoc = new XDocument(
                new XElement("Sport",
                    new XElement("Tennis",
                        new XElement("Name", "A"),
                        new XElement("Wins", 25),
                        new XElement("Loses", 4)
                    ),
                    new XElement("Tennis",
                        new XElement("Name", "B"),
                        new XElement("Wins", 15),
                        new XElement("Loses", 1)
                    ),
                    new XElement("Tennis",
                        new XElement("Name", "C"),
                        new XElement("Wins", 17),
                        new XElement("Loses", 1)
                    ),
                    new XElement("Tennis",
                        new XElement("Name", "D"),
                        new XElement("Wins", 11),
                        new XElement("Loses", 7)
                    ),
                    new XElement("Tennis",
                        new XElement("Name", "E"),
                        new XElement("Wins", 22),
                        new XElement("Loses", 2)
                    )
                )
            );
            
            xdoc.Save(@"xPath.xml");

            bool allAreExpensive = xdoc.Element("Sport").Elements("Tennis")
                .All(x => Convert.ToInt32(x.Element("Wins").Value) > 10);

            Console.WriteLine($"Победы у каждого игрока болбше 10: {allAreExpensive}");

            Console.WriteLine();

            var lightPastryList = xdoc.Elements("Sport")
                .Elements("Tennis")
                .Where(x => Convert.ToInt32(x.Element("Wins").Value) <= 18 )
                .Select(x => new {
                    Name = x.Element("Name").Value,
                    Wins = x.Element("Wins").Value,
                    Loses = x.Element("Loses").Value,
                }
                );

            foreach (var light in lightPastryList)
            {
                Console.WriteLine($"Name: {light.Name}\n" +
                    $"Wins: {light.Wins}\n" +
                    $"Loses: {light.Loses}\n"
                    );
            }
        }
    }
}
