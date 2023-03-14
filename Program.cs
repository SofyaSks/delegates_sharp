using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace delegates_sharp
{
        // указатель - типизированная переменная, указывающая на адрес 
        // тип указателя - int 

        // ДЕЛЕГАТЫ
        // System.Delegate
        // безопасный ссылочный метод (указтель на метод) 

        // СОБЫТИЯ - EVENT
        // какое-то события провоцирует вызов других событий
        // какое-то состояние которое провоцирует реакции
    internal class Program
    {
        /*public delegate double CalcDel(double num1, double num2); // можно сразу инициализировать поля но все операции будут выполняться с этими полями
        public class Calculator
        {
            public double sum(double n1, double n2)
            {
                return n1 + n2;
            }

            public static double minus(double n1, double n2)
            {
                return n1 - n2;
            }

            public double mult(double n1, double n2)
            {
                return n1 * n2;
            }

            public double div(double n1, double n2)
            {
                if (n2!= 0)
                {
                    return n1 / n2;
                }
                throw new DivideByZeroException();
            }
        }*/



        // GENERIC DELEGATE - обобщённый делегат 

        public delegate T CalcDel <T>  ( T num1, T num2);
        //  public delegate T CalcDel <T, T2>  ( T num1, T2 num2);  // для двух разных типов 
        public class Calculator
        {
            public double sum_d(double n1, double n2)
            {
                return n1 + n2;
            }
            public int sum_i(int n1, int n2)
            {
                return n1 + n2;
            }
            public char sum_ch(char n1, char n2)
            {
                return (char)(n1 + n2);
            }
        }
        static void Main(string[] args)
        {

            /* Calculator c1 = new Calculator();
             WriteLine($"Enter expression: ");
             string exp = ReadLine();
             char s = ' ';
             foreach (var item in exp)
             {
                 if (item == '+' || item == '-' || item == '*' || item == '/' )
                 {
                     s = item;
                     break;
                 }
             }
             try
             {
                 string[] numbers = exp.Split(s);
                 CalcDel del = null;
                 switch (s)
                 {
                     case '+': del = new CalcDel(c1.sum);
                         break;
                     case '-':
                         del = new CalcDel(Calculator.minus); // функция static
                         break;
                     case '*':
                         del = new CalcDel(c1.mult);
                         break;
                     case '/':
                         del = c1.div; // делегат можно просто инициализировать методом - групповое преобразование метода
                         break;
                     default:
                         throw new InvalidOperationException();

                 }

                 double res = del(double.Parse(numbers[0]), double.Parse(numbers[1]));

                 WriteLine($"Result = {res} ");
             }
             catch (Exception ex)
             {
                 WriteLine(ex.Message);
             }*/


            // MULTICASTING DELEGATE

            /*CalcDel del = null;
            Calculator c1 = new Calculator();
            del = c1.sum;
            WriteLine($"{del(4.5, 2.5)}");
            WriteLine("******************************");
            del += c1.div; // подписка
            del += c1.mult; // подписка
            foreach(CalcDel item in del.GetInvocationList())
            {
                WriteLine($"{item(4.5, 2.5)}");
            }
            del -= c1.sum;
            WriteLine("******************************");
            foreach (CalcDel item in del.GetInvocationList())
            {
                WriteLine($"{item(4.5, 2.5)}");
            }*/

            Calculator c = new Calculator();
            CalcDel<int> delint = c.sum_i; // передаём указатель на функцию 
            WriteLine($"res = {delint(10, (int)20.5)}");
            WriteLine("******************************");

            CalcDel<double> deldouble = c.sum_d;
            WriteLine($"res = {deldouble(1.5, 20)}");
            WriteLine("******************************");

            CalcDel<char> delchar = c.sum_ch;
            WriteLine($"res = {delchar('5', '8')}");

            //readkey
            // запись на внешний файл
            //WriteLine(@)
        }
    }
}

