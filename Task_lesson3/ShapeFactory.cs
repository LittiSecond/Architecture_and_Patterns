using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_lesson3
{
    class ShapeFactory
    {
        
        // Вариант 1 фабрики  

        public BaseShape CreateShape(ShapeType type, Vector2 position, double param1, double param2 = 0)
        {
            BaseShape shape = null;

            switch (type)
            {
                case ShapeType.Circle:
                    shape = new Circle(position, param1);
                    break;
                case ShapeType.Square:
                    shape = new Square(position, param1);
                    break;
                case ShapeType.Rectangle:
                    shape = new Rectangle(position, param1, param2);
                    break;
                default:
                    shape = new BaseShape(position);
                    break;
            }

            return shape;
        }

        //----------------------   Вариант 2

        public Circle CreateCircle(Vector2 position, double radius)
        {
            return new Circle(position, radius);
        }

        public Square CreateSquare(Vector2 position, double side)
        {
            return new Square(position, side);
        }

        public Rectangle CreateRectangle(Vector2 position, double width, double heigth)
        {
            return new Rectangle(position, width, heigth);
        }


    }
}
