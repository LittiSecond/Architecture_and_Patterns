using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1.Task1
{
    // Задание 1. Провести рефакторинг кода из раздела «Повторяющаяся логика», 
    // применяя внедрение зависимостей к классу EntityBase.

    public abstract class EntityBase
    {
        public long Id { get; private set; }

        public EntityBase()
        {
            Id = CalculateId();
        }

        private long CalculateId()
        {
            long id = DateTime.Now.Ticks;
            return id;
        }
    }

    public class Customer : EntityBase
    {
        public string Description { get; set; }

        public Customer()
        { }
    }

    public class Store : EntityBase
    {
        public Store()
        { }
    }


    public static class Task1
    {
        public static void MainTask1()
        {
            Console.WriteLine("MainTask1");
        }
    }
}
