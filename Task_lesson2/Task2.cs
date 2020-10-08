using System;


namespace Task_lesson2.Task2
{
    /*
     2. Принцип разделения интерфейсов.Товары в магазине могут иметь промокод, 
    скидку, у них есть цена, состояние и т. д. Если этот товар – одежда, для 
    нее устанавливается материал, из которого она сделана, ее цвет и размер. 
    Какие изменения нужно внести в код, чтобы описать произвольные товары 
    (книги, автомобили и т. п.), соблюдая принципы SOLID? 
     */

    interface IItem
    {
        void SetDiscount(double discount);
        void SetPromocode(string promocode);

        void SetColor(Color color);
        void SetSize(Size size);

        void SetPrice(double price);
    }

    class Clothes : IItem
    {
        public void SetColor(Color color) { }
        public void SetDiscount(double discount) { }
        public void SetPrice(double price) { }
        public void SetPromocode(string promocode) { }
        public void SetSize(Size size) { }
    }

    struct Color
    {
        int color;
    }

    struct Size
    {
        int size;
    }

    class Task2
    {
    }
}
