using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    // № 1 Основы CLR и .NET. Типы. Массивы, кортежи и строки  
    internal class Programm
	{
		static void Main()
		{
			Console.WriteLine("-----Типы-----");


			int i = 52;
			Console.WriteLine(i + "\nВведите значение типа int: ");
			i = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine(i);
			Console.WriteLine();

			uint ui = 33;
			Console.WriteLine(ui + "\nВведите значение типа uint: ");
			ui = Convert.ToUInt32(Console.ReadLine());
			Console.WriteLine(ui);
			Console.WriteLine();

			short s = 30;
			Console.WriteLine(s + "\nВведите значение типа short: ");
			s = Convert.ToInt16(Console.ReadLine());
			Console.WriteLine(s);
			Console.WriteLine();

			ushort us = 26;
			Console.WriteLine(us + "\nВведите значение типа ushort: ");
			us = Convert.ToUInt16(Console.ReadLine());
			Console.WriteLine(us);
			Console.WriteLine();

			long l = 87;
			Console.WriteLine(l + "\nВведите значение типа long: ");
			l = Convert.ToInt64(Console.ReadLine());
			Console.WriteLine(l);
			Console.WriteLine();

			ulong ul = 68;
			Console.WriteLine(ul + "\nВведите значение типа ulong: ");
			ul = Convert.ToUInt64(Console.ReadLine());
			Console.WriteLine(ul);
			Console.WriteLine();

			byte b = 2;
			Console.WriteLine(b + "\nВведите значение типа byte: ");
			b = Convert.ToByte(Console.ReadLine());
			Console.WriteLine(b);
			Console.WriteLine();

			sbyte sb = 5;
			Console.WriteLine(sb + "\nВведите значение типа sbyte: ");
			sb = Convert.ToSByte(Console.ReadLine());
			Console.WriteLine(sb);
			Console.WriteLine();

			float f = 2.6f;
			Console.WriteLine(f + "\nВведите значение типа float: ");
			f = Convert.ToSingle(Console.ReadLine());
			Console.WriteLine(f);
			Console.WriteLine();

			double d = 5.1;
			Console.WriteLine(d + "\nВведите значение типа double: ");
			d = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine(d);
			Console.WriteLine();

			decimal dc = 3.65m;
			Console.WriteLine(dc + "\nВведите значение типа decimal: ");
			dc = Convert.ToDecimal(Console.ReadLine());
			Console.WriteLine(dc);
			Console.WriteLine();

			char ch = 'c';
			Console.WriteLine(ch + "\nВведите значение типа char: ");
			ch = (char)Console.Read();
			Console.WriteLine(ch);
			Console.WriteLine();

			string str = "hello, world";
			Console.WriteLine(str + "\nВведите строку: ");
			str = Console.ReadLine();
			Console.WriteLine(str);
			Console.WriteLine();

			bool flag = true;
			Console.WriteLine(flag + "\nВведите значение типа bool: ");
			flag = bool.Parse(Console.ReadLine());
			Console.WriteLine(flag + "\n\n\n");

			d = ui;
			f = us;
			ui = ch;
			dc = ul;
			ui = us;

			d = (double)f;
			ch = (char)i;
			i = (int)l;
			f = (float)d;
			dc = (decimal)f;

			object boxedInt = i, boxedFloat = f, boxedBool = b, boxedChar = ch, boxedString = str;
			int unboxedInt = (int)boxedInt;
			float unboxedFloat = (float)boxedFloat;
			bool unboxedBool = (bool)boxedBool;
			char unboxedChar = (char)boxedChar;
			string unboxedString = (string)boxedString;


			var value = 5;
			//value = str;

			int? nullable = null;
			string nullableString = null;

			

			Console.WriteLine("-----Строки-----");

			string literal1 = "Hello, world";
			string literal2 = "a";

			String string1 = "ab";
			String string2 = "cde";
			String string3 = "1234";

			String resultString = string1 + string2;
			resultString = String.Copy(string3);
			resultString = literal1.Substring(0,5);
			String[] words = literal1.Split(',');
			resultString = literal1.Insert(6, " beautiful");
			resultString = resultString.Remove(6, 10);

			Console.WriteLine($"строка {string3} состоит из цифр");   // Интерполяция

			String voidString = "";
			String nullString = null;

			bool nullOrEmpty = string.IsNullOrEmpty(voidString);
			nullOrEmpty = string.IsNullOrEmpty(nullString);

			StringBuilder strBuild = new StringBuilder();
			strBuild.Append("Hello,");
			strBuild.Insert(6, " world");
			strBuild.Remove(0, 7);
			String result = strBuild.ToString();



			Console.WriteLine("-----Массивы-----");

			Random rand = new Random();

			int[,] matrix = new int[3, 4];

			for(int row = 0; row < 3; row++)
			{
				for(int col = 0; col < 4; col++)
				{
					Console.Write(matrix[row, col] = rand.Next(0, 9));
					Console.Write(' ');
				}
				Console.WriteLine();
			}

			Console.WriteLine();

			string[] text = { "red", "green", "yellow", "blue", "pink" };

			Console.WriteLine($"Size of array: {text.Length}");

			foreach(var word in text)
			{
				Console.WriteLine(word);
			}

			int changePosition = Convert.ToInt32(Console.Read());
			string changingString = Console.ReadLine();
			text[changePosition] = changingString;

			double[][] array = new double[3][];
			array[0] = new double[2];
			array[1] = new double[3];
			array[2] = new double[4];

			for (int row = 0; row < array.Length; row++)
			{
				for (int col = 0; col < array[row].Length; col++)
				{
					array[row][col] = double.Parse(Console.ReadLine());
				}
			}

			for (int row = 0; row < array.Length; row++)
			{
				for (int col = 0; col < array[row].Length; col++)
				{
					Console.Write(array[row][col]);
					Console.Write(' ');
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			var array1 = new[] { 1, 4, 2, 7 };



			Console.WriteLine("-----Кортежи-----");

			(int, string, char, string, ulong) touple = (7, "car", 'f', "human", 147852369);

			Console.WriteLine(touple.ToString());
			Console.WriteLine($"\n{touple.Item1}\n{touple.Item5}\n{touple.Item3}\n");

			var writer = ("Steven", "King", 75);

			//(string firstName, string lastName, int age) = writer;

			var firstName = writer.Item1;
			var lastName = writer.Item2;
			var age = writer.Item3;

			Console.WriteLine($"{firstName} {lastName} {age} y.o.");

            var (_, name, _) = writer;
			Console.WriteLine(name);

			var touple1 = (1, "a");
			var touple2 = (1, "a");
			var touple3 = (1, "b");

			bool areEqual = touple1 == touple2;
			bool areNotEqual = touple1 != touple3;

			var numbers = new[] { 1, 2, 4, 5, 7 };
			var dayOfWeek = "Friday";

			(int, int, int, char) Function(int[] arr,string stroka)
			{
				int max = arr[0], min = arr[0], sum = 0;
				char firstLetter = stroka[0];
				foreach(var number in arr)
				{
					if(number > max)
					{
						max = number;
					}
					if (number < min)
					{
						min = number;
					}
					sum += number;
				}
				return (max,min,sum,firstLetter);
			}

			var res = Function(numbers, dayOfWeek);

			int sum1()
			{
				int maxInt = int.MaxValue, sum;
				unchecked
				{
					sum = maxInt + 5;
				}
				return sum;
			}

			int sum2()
			{
				int maxInt = int.MaxValue, sum;
				checked
				{
					sum = maxInt + 17;
				}
				return sum;
			}

			int a = sum1();
			a = sum2();
        }
    }
}
