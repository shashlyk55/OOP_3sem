using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace lab11
{
    static class Reflector
    { 
        // Получение сборки в которой находится класс
        static public string GetAssembly(string className) 
        {
            Type? type = Type.GetType(className);
            if (type == null)
                throw new Exception("Не существует такого класса!");

            if (type != null)
            {
                Assembly assembly = type.Assembly;
                return $"Класс {className} находится в сборке {assembly.FullName}";
            }
            else
            {
                return $"Класс {className} не найден.";
            }
        }
        // Получение всех публичных конструкторов
        static public ConstructorInfo[] PublicConstructors(string className) 
        {
            Type? type = Type.GetType(className);

            if(type == null)
                throw new Exception("Не существует такого класса!");
            
            ConstructorInfo[] constructors = type.GetConstructors();
            return constructors;
        }
        // Получение всех публичных методов класса
        static public IEnumerable<string> GetMethods(string className)
        {
            Type? type = Type.GetType(className);
            if (type == null)
                throw new Exception("Не существует такого класса!");
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            return methods.Select(method => method.Name);

        }
        // Получение раализованных классом интерфейсов
        static public Type[] GetInterfaces(string className)
        {
            Type? type = Type.GetType(className);
            if (type == null)
                throw new Exception("Не существует такого класса!");
            Type[] interfaces = type.GetInterfaces();
            return interfaces;
        }
        
        // Получение методов с заданным типом параметра
        static public IEnumerable<MethodInfo> GetMethods(string className, Type parameter)
        {
            Type? type = Type.GetType(className);

            List<MethodInfo> list = new List<MethodInfo>();

            if (type == null)
                throw new Exception("Не существует такого класса!");
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach(var method in methods)
            {
                ParameterInfo[] parameters = method.GetParameters();
                foreach(var param in parameters)
                    if(param.ParameterType == parameter)
                        list.Add(method);
            }
            return list;
        }
        // Вызов указанного метода
        static public void Invoke(object obj, string name, params object[] parameters)
        {
            Type? type = obj.GetType();
            var method = type.GetMethod(name);
            if (method == null) throw new Exception("Метод не найден в классе!");
            else
            {
                if (method.GetParameters().Length == parameters.Length)
                    method.Invoke(obj, parameters);
                else throw new Exception("Неверное количество параметров!");
            }
        }
        // Создание объекта указанного типа
        static public T Create<T>(Type type) => (T)Activator.CreateInstance(type);
        
    }
}
