using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Visual_1
{

    public class HW1
    {
        public static long QueueTime(int[] customers, int n)
        {
            int[] CashDesk = new int[n]; //Массив под кассы
            int Time = 0;

            //Проверка, чтобы не выходить за пределы массива(для случая, когда покупателей меньше, чем касс)
            if (customers.Length < n)
            {
                n = customers.Length;
            }

            //Распределяем клиентов по свободным кассам
            for (int j = 0; j < n; j++)
            {
                CashDesk[j] = customers[j];
            }

            int i = n;
            while (i < customers.Length)
            {
                //Находим покупателя с минимальным временем обслуживания
                int minCustomer = CashDesk[0];
                for (int j = 1; j < n; j++)
                {
                    if (CashDesk[j] < minCustomer)
                    {
                        minCustomer = CashDesk[j];
                    }
                }

                //Считаем время, в то время когда освобождается какая-нибудь касса
                for (int j = 0; j < n; j++)
                {
                    CashDesk[j] -= minCustomer;
                }

                Time += minCustomer;

                //Присваиваем свободной кассе оставшегося покупателя
                for (int j = 0; j < n; j++)
                {
                    if (CashDesk[j] == 0 && i < customers.Length)
                    {
                        CashDesk[j] = customers[i];
                        i++;
                    }
                }
            }

            //Цикл, для нахождения последнего максимального времени обслуживания клиента
            int maxTime = 0;
            for (int j = 0; j < n; j++)
            {
                if (CashDesk[j] > maxTime)
                {
                    maxTime = CashDesk[j];
                }
            }
            return Time + maxTime;
        }
    }

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            int[] first = { 5, 3, 4 };
            Console.WriteLine("Одна касса работает. Всего времени: " + HW1.QueueTime(first, 1));

            int[] second = { 10, 2, 3, 3 };
            Console.WriteLine("Две кассы работает. Всего времени: " + HW1.QueueTime(second, 2));

            int[] third = { 2, 3, 10 };
            Console.WriteLine("Две кассы работает. Всего времени: " + HW1.QueueTime(third, 2));

            int[] fourth = { 1343, 1, 120 };
            Console.WriteLine("Три кассы работает. Всего времени: " + HW1.QueueTime(fourth, 3));

            int[] fifth = { };
            Console.WriteLine("Пять касс работает. Всего времени: " + HW1.QueueTime(fifth, 1));

            int[] sixth = { 47, 99 };
            Console.WriteLine("Три кассы работает. Всего времени: " + HW1.QueueTime(sixth, 3));

            int[] seventh = { 7, 5, 9, 3 };
            Console.WriteLine("Четыре кассы работает. Всего времени: " + HW1.QueueTime(seventh, 4));
        }
    }
}
