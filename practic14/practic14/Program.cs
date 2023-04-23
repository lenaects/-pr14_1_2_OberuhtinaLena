using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
namespace practic14
{
    class Program
    {
        static void Main(string[] args)
        {
            //zad1
            Console.WriteLine("Задание 1");
            Stack<int> stac= new Stack<int>();
            Console.WriteLine("Введите n");
            //int.TryParse(Console.ReadLine(),out int n);
            int n = int.Parse(Console.ReadLine());
          
            for (int i = 1; i <= n; i++)
            {
                stac.Push(i);
            } 
          
            Console.WriteLine($"размерность стека {stac.Count()}");
            Console.WriteLine($"верхний элемент стека ={stac.Peek()}"); 
            Console.WriteLine($"размерность стека {stac.Count()}");
            Console.Write($"содержимое стека=");
            while (stac.Count > 0) Console.Write($"{stac.Pop()} ");          
            Console.WriteLine($"\nновая размерность стека {stac.Count()}");

            //zad2a
            Console.WriteLine("Задание 2А");
            bool balans = true;
            Console.WriteLine("введите математическое выражение");
             string vragen=Console.ReadLine();
            using (StreamWriter sw = new StreamWriter("t.txt")) sw.Write(vragen);
            Console.WriteLine("Выражение записанно");
            string sr = File.ReadAllText("t.txt");
            Stack<char> stac1 = new Stack<char>();
            int i1=0;         
            for(int i=0;i<sr.Length;i++)
            {
                char ch = sr[i];
                if (ch == '(') stac1.Push(ch);
                else if(ch==')')
                {
                    if (stac1.Count == 0) balans = false;
                    else stac1.Pop();
                }
                i1++;

            }
            if (balans && stac1.Count == 0) Console.WriteLine("Скобки сбалансированны");
            else if (stac1.Count == 0) Console.WriteLine($"Возможна лишняя скообка ), в позиции {i1}");
            else Console.WriteLine($"Возможна лишняя скобка (, в позиции {sr.Length - stac1.Count} ");
            //zad2b
            Console.WriteLine("Задание 2Б");
            string vragen1 = File.ReadAllText("t.txt");
            Stack<char> stac2 = new Stack<char>();
            for (int i = 0; i < vragen1.Length; i++)
            {
                char ch = vragen1[i];
                if (ch == '(') stac2.Push(ch);
                else if (ch == ')')
                {
                    if (stac2.Count > 0 && stac2.Peek() == '(') stac2.Pop();
                    else stac2.Push(ch);
                }

            }
            while (vragen1.Length > 0 && vragen1[0] == ')') vragen1 = vragen1.Remove(0, 1);
            while (vragen1.Length > 0 && vragen1[vragen1.Length-1] == '(') vragen1 = vragen1.Remove(vragen1[vragen1.Length - 1], 1);
            while(stac2.Count>0)
            {
                char ch = stac2.Pop();
                if (ch == '(') vragen1 += ')';
                else if (ch == ')') vragen1 = vragen1.Remove(vragen1.LastIndexOf(')'), 1);
            }
            File.WriteAllText("t1.txt", vragen1);
            Console.WriteLine($"Новое математическое выражение {vragen1}");
            Console.ReadLine();
        }
        
    }
}
