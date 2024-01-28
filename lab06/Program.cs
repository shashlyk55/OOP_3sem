using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab06
{
    /*
	 1) Создайте иерархию классов исключений (собственных) – 3 типа и более. 
Сделайте наследование пользовательских типов исключений от 
стандартных классов .Net (например, Exception,  IndexOutofRange). 
2) Смоделируйте и обработайте как минимум пять различных 
исключительных ситуаций на основе своих и стандартных исключений. 
Например, не позволять при инициализации объектов передавать 
неверные данные, обрабатывать ошибки при работе с памятью и ошибки 
работы  с файлами, деление на ноль, неверный индекс, нулевой указатель 
и т. д. 
3) В конце поставьте универсальный обработчик catch. 
4) Используйте классический вид try-catch-finally. 
5) Продемонстрируйте возможность многоразовой обработки одного 
исключения и проброс его выше по стеку вызовов. 
6) Обработку исключений вынести в main. При обработке выводить 
специфическую информацию о месте, диагностику и причине 
исключения. Последним должен быть блок, который отлавливает все 
исключения (finally). 
7) Добавьте код в одной из функций макрос Assert. Объясните что он 
проверяет, как будет выполняться программа в случае не выполнения 
условия. Объясните назначение Assert.  
8) Ознакомьтесь с классами Debug и Debugger: 
	 */
    internal class Program
	{
		static void Main()
		{
			Tennis player1 = new Tennis("John", 10, 3, 2);
			Tennis player2 = new Tennis("Carl", 7, 3, 5);

			Console.WriteLine(player1.Equals(player2));
			Console.WriteLine();
			player2.GetHashCode();
			Console.WriteLine(player2.ToString());


			
			ISport mats1 = new Mats(30);
			ISport basketball1 = new BasketBall(50);
			ISport volleyball1 = new VolleyBall(45);
			ISport bench1 = new Bench(15);
			Bars bars2 = new Bars(12);
			Inventory basketball2 = new BasketBall(49);
			Inventory volleyball2 = new VolleyBall(48);
			Inventory bench2 = new Bench(19);
			Ball ball1 = new BasketBall(500);

			Console.WriteLine(Inventory.GetCountOfThings());

			bench1.SetWeight(100);

			Console.WriteLine();

			bars2.SetMaxWeight(200);
			bars2.SetWeight(150);
			Console.WriteLine(bars2.ToString());

			mats1.SetWeight(50);    //из инерфейса
			ball1.SetWeight(20);    //через абстр класс

			Console.WriteLine();

			basketball1 = ball1;

			ball1 = basketball1 as Ball;

			if (basketball1 is Ball)
			{
				Console.WriteLine($"basketball1 is Ball\n");
			}

			ball1.Playing();
			ball1.Shot();
			Printer printer = new Printer();

			Inventory[] arr = { bars2, mats1 as Inventory, basketball2, ball1 };

			foreach (var item in arr)
			{
				Console.WriteLine(printer.IAmPrinting(item));
			}
			Console.WriteLine("----------------------");

			Gym gym = new Gym(500);
			Gym gym1 = new Gym();



			gym.Add(volleyball1 as Inventory);
			gym.Add(bench2);
			gym.Add(bars2);
			//gym.Add(ball1);
			Controller.Sorting(gym);
			gym.ShowList();

			Console.WriteLine("------");

			gym1 = Controller.FindThings(gym, 10, 50);
			gym1.ShowList();

			Console.WriteLine("----------------------");

			try
			{
				Inventory mats3 = new Mats(3300);
				gym.Add(mats3);
			}
			catch (NumberException ex)
			{
				Console.WriteLine("Ошибка: " + ex.Message);
			}
			catch
			{
				Console.WriteLine("Ошибка!Ошибка!Ошибка!");
			}

			Debugger.Launch();

			Gym gym2 = new Gym();
			try
			{
				Inventory mats2 = new Mats(33);
				gym.Set(-3, mats2);
			}
			catch(NumberException ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}\n{ex.StackTrace}");
            }
			catch (ArrayException ex)
			{
				Console.WriteLine($"Ошибка: {ex.outOfRange}\n{ex.StackTrace}"); ;
			}
            catch
            {
                Console.WriteLine("Ошибка!Ошибка!Ошибка!");
            }
            finally
			{
				Console.WriteLine("Продолжение работы программы.\n");
			}

			//Debugger.Break();

			try
			{
				Controller.Sorting(gym2);
			}
			catch (SortException ex)
			{
				Console.WriteLine("Ошибка: " + ex.Message);
			}
            catch
            {
                Console.WriteLine("Ошибка!Ошибка!Ошибка!");
            }
            finally
			{
				Console.WriteLine("Продолжение работы программы.\n");
			}


			Debug.WriteLine("Программа работает!");
			try
			{
				Inventory bench7 = new Bench(-45);
			}
			catch (NumberException ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}\n{ex.StackTrace}");
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}\n{ex.StackTrace}");
			}

			Debug.Assert(!gym2.IsEmpty(), "Список пуст!\n");
			
		}
	}
}
