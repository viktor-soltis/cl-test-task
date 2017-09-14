using System;
using System.Collections.Generic;
using Task1;
using Task2;
using Task3;

namespace CardlyticsTestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunTask1();
            //RunTask2Int();
            //RunTask2String();
            //RunTask3();

            Console.ReadLine();
        }

        public static void RunTask1()
        {
            var triangleTyper = new TriangleTyper(0, 12, 17);

            Console.WriteLine(triangleTyper.GetTriangleType());

            triangleTyper.SideA = 12;

            Console.WriteLine(triangleTyper.GetTriangleType());

            triangleTyper.SideC = 12;

            Console.WriteLine(triangleTyper.GetTriangleType());
        }

        public static void RunTask2Int()
        {
            var linkedList = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLast(i);
            }

            var result = linkedList.NthToLast(5);

            Console.WriteLine(result.Value);
        }

        public static void RunTask2String()
        {
            var linkedList = new LinkedList<string>();

            for (int i = 0; i < 100; i++)
            {
                linkedList.AddLast(string.Format("String is {0}", i));
            }
            var result = linkedList.NthToLast(5);

            Console.WriteLine(result.Value);
        }

        public static void RunTask3()
        {
            var primeNumbers = new PrimeNumbers();

            primeNumbers.PrintPrimeFactorsToConsoleFromFile(@"primeCandidates.txt");
        }
    }
}
