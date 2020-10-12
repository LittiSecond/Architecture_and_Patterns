using System;


namespace Task_lesson3
{
    //
    // 1. Применить шаблон «Фабрика» для создания объектов, описывающих геометрические фигуры (круг, квадрат, прямоугольник).
    //

    class Program
    {
        static void Main(string[] args)
        {
            // вариант фабрики 1

            ShapeFactory factory = new ShapeFactory();
            BaseShape[] shapes = {
                new Circle(1, 2, 3),
                new Square(4, 5, 6),
                new Rectangle(7, 8, 9, 10),
            };

            foreach (BaseShape shape in shapes)
            {
                Console.WriteLine($"Фигура: {shape}");
            }

            Console.WriteLine("-----------------");

            //  вариант фабрики 2

            BaseShape[] shapes2 = {
                factory.CreateCircle( new Vector2(11, 12), 13),
                factory.CreateSquare(new Vector2(14, 15), 16),
                factory.CreateRectangle(new Vector2(17, 18), 19, 20),
            };

            foreach (BaseShape shape in shapes2)
            {
                Console.WriteLine($"Фигура: {shape}");
            }

            Console.ReadKey();
        }
    }
}
