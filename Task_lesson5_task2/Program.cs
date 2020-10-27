using System;

namespace Task_lesson5_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyMath someMath = new ProxyMath();

            double d1 = getFromClientFirstParameter();
            double d2 = getFromClientSecondParameter();

            double plus = someMath.plus(d1, d2);
            double minus = someMath.minus(d1, d2);
            double multiply = someMath.multiply(d1, d2);
            double divide = someMath.divide(d1, d2);

            Console.WriteLine($"plus = {plus}\nminus = {minus}\nmultiply = {multiply}\ndivide = {divide}");

            Console.ReadKey();
        }

        private static double getFromClientFirstParameter()
        {
            return 16.0;
        }

        private static double getFromClientSecondParameter()
        {
            return -0.8;
        }
    }
}
