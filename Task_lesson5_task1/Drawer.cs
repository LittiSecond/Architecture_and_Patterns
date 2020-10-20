using System;
using System.Drawing;


namespace Task_lesson5_task1
{
    class Drawer
    {

        private Graphics _graphics;
        

        public Drawer()
        {
            _graphics = GraphicHandler.Graphics;
            TimeHandler.Update += Draw;
        }

        public void Draw(int time)
        {
            GraphicHandler.Clear();

            _graphics?.DrawRectangle(Pens.DarkRed, 105, 55, 100, 50);
            _graphics?.DrawEllipse(Pens.DarkBlue, 105, 55, 50, 25);

            GraphicHandler.Render();
        }


    }
}
