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

        public override string ToString()
        {
            return $"Id = {Id} ";
        }
    }

    public class Customer : EntityBase
    {
        public string Description { get; set; }

        public Customer()
        { }

        public override string ToString()
        {
            return $"Customer: {base.ToString()}; {Description}";
        }

    }

    public class Store : EntityBase
    {
        public Store()
        { }

        public override string ToString()
        {
            return "Store: " + base.ToString();
        }
    }


    public static class Task1
    {
        public static void MainTask1()
        {
            Customer c1 = new Customer();
            c1.Description =  "c1 description";
            Store s1 = new Store();

            Console.WriteLine(c1.ToString());
            Console.WriteLine(s1.ToString());

        }
    }
}
