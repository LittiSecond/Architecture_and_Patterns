using System;
using System.Drawing;


namespace Task_lesson5_task1
{
    class MyRect : IDrawShapeAPI
    {
        private Graphics _graphics;
        private Pen _pen;

        public MyRect(Graphics g, Pen pen)
        {
            _graphics = g;
            _pen = pen ?? Pens.Black;
        }

        public void DrawShape(Point point1, Point point2)
        {
            if (_graphics != null)
            {
                _graphics.DrawRectangle(_pen, point1.X, point1.Y, point2.X, point2.Y);
            }
        }
    }
}
