using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace lab11
{
    /*
     1. Для изучения .NET Reflection API напишите статический класс Reflector, 
    который собирает информацию и будет содержать методы выполняющие 
    исследования класса (принимают в качестве параметра имя класса) и 
    записывающие информацию в файл (формат тестовый, json или xml):  
    a. Определение имени сборки, в которой определен класс; 
    b. есть ли публичные конструкторы; 
    c. извлекает все общедоступные публичные методы класса 
    (возвращает IEnumerable<string>); 
    d. получает информацию о полях и свойствах класса (возвращает 
    IEnumerable<string>); 
    e. получает все реализованные классом интерфейсы (возвращает 
    IEnumerable<string>); 
    f. выводит по имени класса имена методов, которые содержат 
    заданный (пользователем) тип параметра (имя класса передается 
    в качестве аргумента);  
    g. метод Invoke, который вызывает метод класса, при этом значения 
    для его параметров необходимо 1) прочитать из текстового файла 
    (имя класса и имя метода передаются в качестве аргументов) 2) 
    сгенерировать, используя генератор значений для каждого типа. 
    Параметрами метода Invoke должны быть : объект, имя метода, 
    массив параметров. 
    Продемонстрируйте  работу «Рефлектора» для исследования типов на  созданных 
    вами классах не менее двух (предыдущие лабораторные работы)  и  стандартных 
    классах .Net. 
    2. Добавьте в Reflector обобщенный метод Create, который создает объект 
    переданного типа (на основе имеющихся публичных конструкторов) и возвращает 
    его пользователю. 
     */
    interface IClass { }

    class MyClass : IClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public MyClass(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public MyClass()
        {

        }
        public void f1(string s) { }
        public int f2(string s) { return s.Count(); }
        public bool f3() { return 2 > 0; }
        public int f4(int a) { return a ^ a; }
        private int prF(int b) { return b; }
        public int Met(string str, int c) 
        { 
            Console.WriteLine(str);
            Console.WriteLine(c * c);
            return c * c;
        }
    }


    internal class Program
    {
        static void Main()
        {
            string path = "Reflection.txt";
            string file = "Params.txt";
            try
            {
                var a = new MyClass();

                using(StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(Reflector.GetAssembly("lab11.MyClass"));
                    Console.WriteLine(Reflector.GetAssembly("lab11.MyClass"));

                    writer.WriteLine();
                    Console.WriteLine();

                    
                    var list = Reflector.PublicConstructors("lab11.MyClass");
                    if(list.Length != 0)
                    {
                        writer.WriteLine("Публичные конструкторы: ");
                        Console.WriteLine("Публичные конструкторы: ");
                        foreach (var item in list)
                        {
                            Console.WriteLine(item);
                            writer.WriteLine(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Отсутствуют публичные конструкторы");
                        writer.WriteLine("Отсутствуют публичные конструкторы");
                    }


                    writer.WriteLine();
                    Console.WriteLine();

                    var methods = Reflector.GetMethods("lab11.MyClass");
                    if (methods.Count() != 0)
                    {
                        writer.WriteLine("Публичные методы: ");
                        Console.WriteLine("Публичные методы: ");
                        foreach (var method in methods)
                        {
                            Console.WriteLine(method);
                            writer.WriteLine(method);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Отсутствуют публичные методы");
                        writer.WriteLine("Отсутствуют публичные методы");
                    }
                    writer.WriteLine();
                    Console.WriteLine();

                    var interfaces = Reflector.GetInterfaces("lab11.MyClass");
                    if(interfaces.Count() != 0)
                    {
                        writer.WriteLine("Реализованные интерфейсы:");
                        Console.WriteLine("Реализованные интерфейсы:");
                        foreach(var i in interfaces)
                        {
                            writer.WriteLine(i);
                            Console.WriteLine(i);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Отсутствуют реализованные интерфейсы");
                        writer.WriteLine("Отсутствуют реализованные интерфейсы");
                    }
                    writer.WriteLine();
                    Console.WriteLine();

                    var parmMethods = Reflector.GetMethods("lab11.MyClass", typeof(int));
                    if(interfaces.Count() != 0)
                    {
                        writer.WriteLine($"Методы с заданным параметром:");
                        Console.WriteLine($"Методы с заданным параметром:");
                        foreach(var method in parmMethods)
                        {
                            writer.WriteLine(method);
                            Console.WriteLine(method);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Отсутствуют такие методы");
                        writer.WriteLine("Отсутствуют такие методы");
                    }
                    writer.WriteLine();
                    Console.WriteLine();


                }
                using(StreamReader reader = new StreamReader(file))
                {
                    string line;
                    string name = reader.ReadLine();
                    List<object> parameters = new List<object>();
                    
                    while((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(':');
                        if(parts.Length == 2)
                        {
                            string type = parts[0].Trim();
                            string value = parts[1].Trim();

                            switch (type)
                            {
                                case "int":
                                    int iValue = int.Parse(value);
                                    parameters.Add(iValue);
                                    break;
                                case "double":
                                    double dValue = double.Parse(value);
                                    parameters.Append(dValue);
                                    break;
                                case "bool":
                                    bool bValue = bool.Parse(value);
                                    parameters.Append(bValue);
                                    break;
                                case "char":
                                    char sValue = char.Parse(value);
                                    parameters.Append(sValue);
                                    break;
                                case "string":
                                    parameters.Add(value);
                                    break;
                            }
                        }
                    }
                     
                    if(name != null && parameters != null)
                    {
                        Console.WriteLine("Вызов функции:");
                        Reflector.Invoke(a, name, parameters.ToArray());
                    }

                }
                Console.WriteLine();

                var obj = Reflector.Create<MyClass>(typeof(MyClass));
                Console.WriteLine(obj != null ? "Объект создан" : "Объект не был создан");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }
    }
}