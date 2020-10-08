using System;
using System.Collections.Generic;

namespace Lesson1.Task2
{
    // Задание 2. Реализовать программу из раздела «Повторяющиеся фрагменты кода» с помощью делегата Func.

    public static class Constants
    {
        public static readonly string Address = "Москва, Россия";
        public static readonly string Format = "{0} - {1}, адрес {2}, возраст {3}";
    }

    public static class Task2
    {

        public static readonly string Address = Constants.Address;
        public static readonly string Format = Constants.Format;

        private static string DummyFunc()
        {
            return CreateString("Петя", "школьный друг", 30);
        }

        private static string DummyFuncAgain()
        {
            return CreateString("Вася", "сосед", 54);
        }

        private static string DummyFuncMore()
        {
            return CreateString("Николай", "сын", 4);
        }

        private static string CreateString(string name, string description,
                                           int age)
        {
            return string.Format(Format, name, description, Address, age);
        }

        private static void MakeAction(Func<string> action)
        {
            string methodName = action.Method.Name;
            Console.WriteLine("Начало работы метода {0}", methodName);
            Console.WriteLine(action());
            Console.WriteLine("Окончание работы метода {0}", methodName);
        }

        private static List<Func<string>> GetActionSteps()
        {
            return new List<Func<string>>
            {
                 DummyFunc,
                 DummyFuncAgain,
                 DummyFuncMore
            };
        }

        public static void MainTask2()
        {
            List<Func<string>> actions = GetActionSteps();
            foreach (var action in actions)
            {
                MakeAction(action);
            }

            Console.ReadLine();
        }

        // Считаю такой вариант лучше, а городить, то что сделано в двух методах выше, не нужно,
        // так как оно сильно усложняет программу

        //public static void MainTask2()
        //{
        //    MakeAction(DummyFunc);
        //    MakeAction(DummyFuncAgain);
        //    MakeAction(DummyFuncMore);

        //    Console.ReadLine();
        //}

    }
}
