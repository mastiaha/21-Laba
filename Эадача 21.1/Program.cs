using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Эадача_21._1
{
    class Program
    {
         static int[,] uchastok;
         static int m;
         static int n;


        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк двумерного массива");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов двумерного массива");
            m = Convert.ToInt32(Console.ReadLine());

            uchastok = new int[n, m];

            Thread sadovnik1 = new Thread(Sadovnik1);
            Thread sadovnik2 = new Thread(Sadovnik2);

            sadovnik1.Start();
            sadovnik2.Start();

            sadovnik1.Join();
            sadovnik2.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(uchastok[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void Sadovnik1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (uchastok[i, j] == 0)
                        uchastok[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }

        private static void Sadovnik2()
        {
            for (int i = m - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    if (uchastok[j, i] == 0)
                        uchastok[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
        
    }
}
