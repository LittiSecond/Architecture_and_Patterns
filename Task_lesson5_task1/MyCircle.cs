using System;
using System.Drawing;

namespace Task_lesson5_task1
{
    class MyCircle : IDrawShapeAPI
    {
        private Graphics _graphics;
        private Pen _pen;

        public MyCircle(Graphics g, Pen pen)
        {
            _graphics = g;
            _pen = pen ?? Pens.Black;
        }

        public void DrawShape(Point point1, Point point2)
        {
            if (_graphics != null)
            {
                _graphics.DrawEllipse(_pen, point1.X, point1.Y, point2.X, point2.Y);
            }
        }
    }
}
