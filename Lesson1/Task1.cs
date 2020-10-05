using System;


namespace Lesson1.Task1
{
    // Задание 1. Провести рефакторинг кода из раздела «Повторяющаяся логика», 
    // применяя внедрение зависимостей к классу EntityBase.

    public abstract class EntityBase
    {
        public long Id { get; private set; }

        private IIdGenerator _idGenerator;

        public EntityBase(IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
            if (_idGenerator != null)
            {
                Id = _idGenerator.CalculateId();
            }
        }

        public override string ToString()
        {
            return $"Id = {Id} ";
        }
    }

    public class Customer : EntityBase
    {
        public string Description { get; set; }

        public Customer(IIdGenerator idGenerator) : base(idGenerator)
        { }

        public override string ToString()
        {
            return $"Customer: {base.ToString()}; {Description}";
        }

    }

    public class Store : EntityBase
    {
        public Store(IIdGenerator idGenerator) : base(idGenerator)
        { }

        public override string ToString()
        {
            return "Store: " + base.ToString();
        }
    }

    public interface IIdGenerator
    {
        long CalculateId();
    }

    public class DefaultIdGenerator : IIdGenerator
    {
        public long CalculateId()
        {
            long id = DateTime.Now.Ticks;
            return id;
        }
    }

    public static class Task1
    {
        public static void MainTask1()
        {
            DefaultIdGenerator idGenerator = new DefaultIdGenerator();

            Customer c1 = new Customer(idGenerator);
            c1.Description =  "c1 description";
            Store s1 = new Store(idGenerator);

            Console.WriteLine(c1.ToString());
            Console.WriteLine(s1.ToString());

        }
    }
}
