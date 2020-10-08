using System;


namespace Task_lesson2.Task1
{
    /*
     Задание 1. Применить принцип открытости / закрытости. Класс OrderRepository изначально был 
    реализован для работы с заказами, хранящимися в MySQL. Но однажды нам потребовалось 
    реализовать работу с данными о заказах, например, через API стороннего веб-сервиса. 
    Какие изменения нам надо будет внести?
     */

    class Order
    {
        int orderId;
        string Name;
    }

    class OrderRepository
    {
        public Order Load(int orderId) { return ... }
        public void Save(Order order) { ... }
        public void Update(Order order) { ... }
        public void Delete(Order order) { ... }
    }

    class Task1
    {
    }

}
