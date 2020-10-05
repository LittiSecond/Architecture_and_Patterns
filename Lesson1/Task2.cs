using System;


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
        private static void DummyFunc()
        {
            WriteToConsole("Петя", "школьный друг", 30);
        }

        private static void DummyFuncAgain()
        {
            WriteToConsole("Вася", "сосед", 54);
        }

        private static void DummyFuncMore()
        {
            WriteToConsole("Николай", "сын", 4);
        }

        private static void WriteToConsole(string name, string description,
                                           int age)
        {
            Console.WriteLine(Format, name, description, Address, age);
        }

        public static void MainTask2()
        {
            Console.WriteLine("Начало работы метода DummyFunc");
            DummyFunc();
            Console.WriteLine("Окончание работы метода DummyFunc");

            Console.WriteLine("Начало работы метода DummyFuncAgain");
            DummyFuncAgain();
            Console.WriteLine("Окончание работы метода DummyFuncAgain");

            Console.WriteLine("Начало работы метода DummyFuncMore");
            DummyFuncMore();
            Console.WriteLine("Окончание работы метода DummyFuncMore");

            Console.ReadLine();
        }
    }
}
