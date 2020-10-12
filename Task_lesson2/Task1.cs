using System;


namespace Task_lesson2.Task1
{
    /*
     Задание 1. Применить принцип открытости / закрытости. Класс OrderRepository изначально был 
    реализован для работы с заказами, хранящимися в MySQL. Но однажды нам потребовалось 
    реализовать работу с данными о заказах, например, через API стороннего веб-сервиса. 
    Какие изменения нам надо будет внести?
     */

    /*
     Нужно внести изменения:
     1. в классе OrderRepository сделать публичные методы виртуальными;
     2. добавить класс дла работы со сторониим веб-сервисом, наследованным от OrderRepository
     3. переопределить методы в добавленном классе
     */

    class Order
    {
        int orderId;
        string Name;
    }

    class OrderRepository
    {
        public virtual Order Load(int orderId) 
        {
            Order order = new Order();
            //
            //  Извлечения данных из базы данных MySQL и сохранение в order.
            //
            return order;
        }

        public virtual void Save(Order order) 
        {
            // действия с БД MySQL
        }

        public virtual void Update(Order order) 
        {
            // действия с БД MySQL
        }

        public virtual void Delete(Order order) 
        {
            // действия с БД MySQL
        }
    }

    class OrderExternalServis : OrderRepository
    {
        public override Order Load(int orderId)
        {
            Order order = new Order();
            //
            //  Получение данных от стороннего сервиса и сохранение в order.
            //
            return order;
        }

        public override void Save(Order order)
        {
            // действия со сторонним сервисом 
        }

        public override void Update(Order order)
        {
            // действия со сторонним сервисом 
        }

        public override void Delete(Order order)
        {
            // действия со сторонним сервисом 
        }
    }


    class Task1
    {
    }

}
