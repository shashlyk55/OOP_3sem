using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Collections.Concurrent;


namespace lab15
{
    /*
    1. Используя TPL создайте длительную по времени задачу (на основе 
Task) на выбор: 
 поиск простых чисел (желательно взять «решето Эратосфена»), 
 перемножение матриц, 
 умножение вектора размера 100000 на число, 
 создание множества Мандельброта 
 другой алгоритм. 
1) Выведите идентификатор текущей задачи, проверьте во время 
выполнения – завершена ли задача и выведите ее статус. 
2) Оцените производительность выполнения используя объект 
Stopwatch на нескольких прогонах. 
Дополнительно: 
Для сравнения реализуйте последовательный алгоритм. 
2. Реализуйте второй вариант этой же задачи с токеном отмены 
CancellationToken и  отмените задачу. 
3. Создайте три задачи с возвратом результата и используйте их для 
выполнения четвертой задачи. Например, расчет по формуле. 
4. Создайте задачу продолжения (continuation task) в двух вариантах: 
1) C ContinueWith - планировка на основе завершения множества 
предшествующих задач 
2) На основе объекта ожидания и методов GetAwaiter(),GetResult(); 
5. Используя Класс Parallel распараллельте вычисления циклов For(), 
ForEach(). Например, на выбор: обработку (преобразования) 
последовательности, генерация нескольких массивов по 1000000 
элементов, быстрая сортировка последовательности, обработка текстов 
(удаление, замена). Оцените производительность по сравнению с 
обычными циклами 
6. Используя Parallel.Invoke() распараллельте выполнение блока 
операторов.  
7. Используя Класс BlockingCollection реализуйте следующую задачу: 
Есть 5 поставщиков бытовой техники, они завозят уникальные товары 
на склад  (каждый по одному) и 10 покупателей – покупают все подряд, 
если товара нет - уходят. В вашей задаче: cпрос превышает 
предложение. Изначально склад пустой. У каждого поставщика своя 


скорость завоза товара. Каждый раз при изменении состоянии склада 
выводите наименования товаров на складе. 
8. Используя async и await организуйте асинхронное выполнение любого 
метода. 
     */
    internal class Program
    {
        static async Task Main()
        {

            // task1 
            // перемножение матриц
            Console.WriteLine("---task1---");
            Stopwatch stopwatch = new Stopwatch();

            int[,] InputMatrix(int[,] matr)
            {
                Random rand = new Random();
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                        matr[i, j] = rand.Next(0, 10);
                }
                return matr;
            }

            var cancelToken = new CancellationTokenSource();
            CancellationToken token = cancelToken.Token;

            int col1 = 10;
            int col2 = 8;
            int lines1 = 8;
            int lines2 = 12;

            int[,] matrix1 = new int[col1, lines1];
            int[,] matrix2 = new int[col2, lines2];

            InputMatrix(matrix1);
            InputMatrix(matrix2);

            Printing(token, matrix1);
            Console.WriteLine();
            Printing(token, matrix2);
            Console.WriteLine();

            //int[,] resMatrix = new int[col1, lines2];


            stopwatch.Start();
            Task<int[,]> matrixMullTask = Task.Run(async () =>
            {
                int[,] resMatrix = new int[col1, lines2];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        for (int k = 0; k < matrix1.GetLength(1); k++)
                        {
                            resMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                            token.ThrowIfCancellationRequested();
                        }
                    }
                }
                await Task.Delay(2000);
                return resMatrix;
            }, token);

            
            var task = new Task(() => Printing(token, matrixMullTask.Result));
            task.Start();
            task.Wait();
            stopwatch.Stop();   

            if (matrixMullTask.IsCompleted)
            {
                Console.WriteLine("Задача завершена");
                Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds}");
            }
            else
                Console.WriteLine("Задача не завершена");
            Console.WriteLine($"Task Id: {matrixMullTask.Id} Статус: {matrixMullTask.Status}");

            // task 2
            Console.WriteLine("---task2---");
            await Task.Delay(1000);
            cancelToken.Cancel();

            try
            {
                await matrixMullTask;
                await task;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Задача была отменена");
            }

            if (matrixMullTask.IsCompleted)
            {
                Console.WriteLine("Задача завершена");
            }
            else
                Console.WriteLine("Задача не завершена");
            Console.WriteLine($"Task Id: {matrixMullTask.Id} Статус: {matrixMullTask.Status}");

            // task 3 4

            // formula = a! * b - c
            Console.WriteLine("---task3 4---");
            try
            {
                var cancelToken1 = new CancellationTokenSource();
                CancellationToken token1 = cancelToken.Token;

                int N = 5;
                int a = 2, b = 3;

                Task<int> t1 = new Task<int>(() =>
                {
                    int res = 1;
                    if (N == 0) return 1;
                    for (int i = 1; i <= N; i++)
                        res *= i;
                    return res;
                });
                Task<int> t2 = t1.ContinueWith(res => t1.Result * a);
                Task<int> t3 = t2.ContinueWith(res => t2.Result - b);

                t1.Start();
                
                Console.WriteLine($"Результат {N}! * {a} - {b} = {t3.Result}");

                Task<int> awaiteTask = new Task<int>(() =>
                {
                    int res = 1;
                    if (N == 0) return 1;
                    for (int i = 1; i <= N; i++)
                        res *= i;
                    return res;
                });

                TaskAwaiter<int> awaiter = awaiteTask.GetAwaiter();
                awaiter.OnCompleted(() =>
                {
                    int res = 0;
                    if (!t1.IsFaulted) res = awaiter.GetResult();
                    Console.WriteLine($"Результат через Awaiter: {N}! = {awaiteTask.Result}");
                });
                awaiteTask.Start();
                awaiteTask.Wait();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // task 5 6
            Console.WriteLine("---task5 6---");
            try
            {
                CancellationTokenSource ts = new CancellationTokenSource();
                CancellationToken tok = ts.Token;
                int[] arr1 = new int[1000000];
                int[] arr2 = new int[1000000];
                int[] arr3 = new int[1000000];
                Random r = new Random();

                Parallel.For(0, 1000000, x =>
                {
                    arr1[x] = r.Next(0, 10);
                    arr2[x] = r.Next(0, 10);
                    arr3[x] = r.Next(0, 10);
                });

                Parallel.Invoke(
                    () => { for (int i = 0; i < arr1.Length; i++) arr1[i] = i; },
                    () => { for (int i = 0; i < arr2.Length; i++) arr2[i] = i * 10; },
                    () => { for (int i = 0; i < 30; i++) Console.Write($"{arr3[i]} "); }
                );
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();

            // task 8
            //Используя async и await организуйте асинхронное выполнение любого метода.
            try
            {
                Console.WriteLine("---task8---");
                async Task MethodAsync()
                {
                    Console.WriteLine("Рассчет");
                    await Task.Run(() => Factorial(4));
                    Console.WriteLine("Конец рассчета");
                }

                async void Factorial(int n)
                {
                    int res = 1;
                    if (n == 0)
                    {
                        Console.WriteLine($"{n}! = {res}");
                        return;
                    }
                    for (int i = 1; i <= n; i++)
                    {
                        res *= i;
                    }
                    Console.WriteLine($"{n}! = {res}");
                    return;
                }
                MethodAsync();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // task 7
            /*
             * Используя Класс BlockingCollection реализуйте следующую задачу: 
            Есть 5 поставщиков бытовой техники, они завозят уникальные товары 
            на склад  (каждый по одному) и 10 покупателей – покупают все подряд, 
            если товара нет - уходят. В вашей задаче: cпрос превышает 
            предложение. Изначально склад пустой. У каждого поставщика своя 
            скорость завоза товара. Каждый раз при изменении состоянии склада 
            выводите наименования товаров на складе. 
             */
            
            try
            {
                BlockingCollection<string> sklad = new BlockingCollection<string>();
                Random r = new Random();
                Task[] consumers = new Task[10]
                {
                    new Task(() => { while (true){ Thread.Sleep(r.Next(200, 1000));
                                            sklad.Add("table");}}),
                    new Task(() => { while (true){Thread.Sleep(r.Next(200, 1000));
                                            sklad.Add("chair");}}),
                    new Task(() => { while (true){Thread.Sleep(r.Next(200, 1000));
                                            sklad.Add("armchair");}}),
                    new Task(() => { while (true){Thread.Sleep(r.Next(200, 1000));
                                            sklad.Add("sofa");}}),
                    new Task(() => { while (true){Thread.Sleep(r.Next(200, 1000));
                                            sklad.Add("bed");}}),
                    new Task(() => { while (true){Thread.Sleep(r.Next(200, 1000));
                                            sklad.Add("wardrobe");}}),
                    new Task(() => { while (true){Thread.Sleep(r.Next(200, 1000));
                                            sklad.Add("car");}}),
                    new Task(() => { while (true){Thread.Sleep(r.Next(200,- 1000));
                                            sklad.Add("washmacine");}}),
                    new Task(() => { while (true){Thread.Sleep(r.Next(200, 1000));
                                            sklad.Add("microwave");}}),
                    new Task(() => { while (true){Thread.Sleep(r.Next(200, 1000));
                                            sklad.Add("table");}})
                };

                Task[] producers = new Task[5]
                {
                new Task(() =>{while(true){Thread.Sleep(r.Next(500, 2000));
                                         sklad.Take();}}),
                new Task(() =>{while(true){Thread.Sleep(r.Next(500, 2000));
                                         sklad.Take();}}),
                new Task(() =>{while(true){Thread.Sleep(r.Next(500, 2000));
                                         sklad.Take();}}),
                new Task(() =>{while(true){Thread.Sleep(r.Next(500, 2000));
                                         sklad.Take();}}),
                new Task(() =>{while(true){Thread.Sleep(r.Next(500, 2000));
                                         sklad.Take();}})
                };

                foreach(var t in consumers)
                    if (t.Status != TaskStatus.Running)
                        t.Start();
                foreach (var t in producers)
                    if (t.Status != TaskStatus.Running)
                        t.Start();

                

                int count = 1;
                while (true)
                {
                    if (sklad.Count != 0)
                    {
                        Thread.Sleep(300);
                        Console.Clear();
                        Console.WriteLine("---task7---");
                        Console.WriteLine("- - - Store - - -");
                        foreach(var item in sklad)
                            Console.WriteLine(item);
                    }
                }

                Console.WriteLine("Рабочий день окончен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Producer(int id, BlockingCollection<string> collection)
        {
            
            Random random = new Random();
            while (true)
            {
                string product = $"Товар от поставщика {id}";
                collection.Add(product);
                Console.WriteLine($"Добавлен товар: {product}");
                Console.WriteLine($"Склад: {string.Join(", ", collection)}");
                Task.Delay(random.Next(500, 4000)).Wait();
            }
        }
        static void Customer(int id, BlockingCollection<string> collection)
        {
            while (true)
            {
                Random random = new Random();
                string product = collection.Take();
                Console.WriteLine($"Покупатель {id} купил товар {product}");
                Console.WriteLine($"Склад: {string.Join(", ", collection)}");
                Task.Delay(random.Next(500, 3000)).Wait();
            }
        }
        static async Task Printing(CancellationToken token, int[,] matrix)
        {
            token.ThrowIfCancellationRequested();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                    Thread.Sleep(1);
                }
                Console.WriteLine();
            }
            await Task.Delay(1000);
        }
        
    }
}
