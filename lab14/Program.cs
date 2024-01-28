using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace lab14
{
    /*
     1. Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет, 
время запуска, текущее состояние, сколько всего времени использовал процессор и т.д. 
2. Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки, 
загруженные в домен. Создайте новый домен. Загрузите  туда сборку. Выгрузите домен. 
3. Создайте в отдельном потоке следующую задачу расчета (можно сделать sleep для 
задержки) и записи в файл и на консоль  простых чисел от 1 до n (задает пользователь). 
Вызовите методы управления потоком (запуск, приостановка, возобновление и т.д.) Во 
время выполнения выведите  информацию о  статусе потока, имени, приоритете, числовой 
идентификатор и т.д.  
4. Создайте два потока. Первый выводит четные числа, второй нечетные до n и 
записывают их  в общий файл и на консоль. Скорость расчета чисел у потоков – разная. 
a. Поменяйте приоритет одного из потоков. 
b. Используя средства синхронизации организуйте работу потоков, таким образом, 
чтобы 
i. выводились сначала четные, потом нечетные числа 
ii. последовательно выводились одно четное, другое нечетное. 
5. Придумайте и реализуйте повторяющуюся задачу на основе класса Timer 
     */
    internal class Program
    {
        static void Main()
        {
            try
            {
                Process[] process = Process.GetProcesses();
                Console.WriteLine("Процессы: ");
                foreach (Process p in process)
                {
                    Console.WriteLine($"ID: {p.Id} {p.ProcessName} Приоритет: {p.BasePriority} Время запуска: {p.StartTime} Состояние: {p.Responding} Время работы: {p.TotalProcessorTime}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();

            AppDomain newDomain = AppDomain.CreateDomain("NewDomain");
            try
            {
                AppDomain myApp = AppDomain.CurrentDomain;
                Assembly[] assemblies = myApp.GetAssemblies();

                Console.WriteLine($"Имя: {myApp.FriendlyName} Конфигурация: {myApp.SetupInformation}");

                Console.WriteLine("Сборки загруженные в домен:");
                foreach (Assembly assembly in assemblies)
                {
                    Console.WriteLine(assembly);
                }
                Console.WriteLine();

                newDomain.Load(assemblies[0].GetName());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                AppDomain.Unload(newDomain);
            }
            Console.WriteLine();

            try
            {
                int n = 4;
                Thread thread1 = new Thread(GetNumbers);
                thread1.Start(n);

                Console.WriteLine($"Поток: {thread1.Name} Статус: {thread1.ThreadState} Приоритет: {thread1.Priority} ID: {thread1.ManagedThreadId}");


                thread1.Join();
                Console.WriteLine("\nJoin after thread1 completing");
                thread1.Abort();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();

            try
            {
                int n = 23;
                Thread threadEvenNums = new Thread(EvenNums);
                Thread threadOddNums = new Thread(OddNums);

                //threadEvenNums.Priority = ThreadPriority.Normal;
                //threadOddNums.Priority = ThreadPriority.AboveNormal;

                threadEvenNums.Start(n);

                threadOddNums.Start(n);
                threadEvenNums.Join();
                threadOddNums.Join();


                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
                
            try
            { 
                void PrintMessage(object obj) => Console.WriteLine($"Time: {DateTime.Now.ToString("HH:mm:ss")}");
                Timer timer = new Timer(new TimerCallback(PrintMessage), null, 0, 1000);

                Console.WriteLine("this is a timer");
                Thread.Sleep(5000);

                timer.Dispose();
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void GetNumbers(object n)
        {
            using (StreamWriter sw = new StreamWriter("testThreading.txt"))
            {
                for (int i = 1; i <= (int)n; i++)
                {
                    Console.Write(i);
                    sw.Write(i);
                    Thread.Sleep(700);
                }
            }
        }
        static object lockObject = new object();
        static void EvenNums(object n)
        {
            for (int i = 0; i <= (int)n; i += 2)
            {
                lock (lockObject)
                {
                    File.AppendAllText("Numbers.txt", $"{i} ");
                    Console.Write($"{i} ");
                    Thread.Sleep(200);
                }
            }
        }

        static void OddNums(object n)
        {
            for (int i = 1; i <= (int)n; i += 2)
            {
                lock (lockObject)
                {
                    File.AppendAllText("Numbers.txt", $"{i} ");
                    Console.Write($"{i} ");
                    Thread.Sleep(700);
                }
            }
        }
    }
}
