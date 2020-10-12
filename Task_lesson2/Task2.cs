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

    /*
     Нужно внести изменения:
    1.  Добавить интерфейс предназначенный только для одежды
    2.  Перенести методы, предназначенные для одержды из IItem в интерфейс для одержды
    3.  Изменить наследования класса Clothes на IClothes
    4.  Добавить специализированные интерфейсы для каждого вида товара   

     * */
    interface IItem
    {
        void SetDiscount(double discount);
        void SetPromocode(string promocode);
        void SetPrice(double price);
    }

    interface IClothes : IItem
    {
        void SetColor(Color color);
        void SetSize(Size size);
        void SetMaterial(Material material);
    }

    interface IBook : IItem
    {
        string SetTitle(string title);
        string SetAuthor(string autor);
    }

    interface ICar : IItem
    {
        string SetMark(string mark);
        string SetModel(string model);
    }

    class Clothes : IClothes
    {
        public void SetColor(Color color) { }
        public void SetDiscount(double discount) { }
        public void SetMaterial(Material material) { }
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

    class Material
    {

    }

    class Task2
    {
    }
}
