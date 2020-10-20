using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task_lesson5_task1
{
    static class GraphicHandler
    {
        private static BufferedGraphicsContext _context;
        private static BufferedGraphics _buffer;

        // размеры поля
        private static int _width;
        private static int _height;

        public static Color BackgroundColor { get; set; }
        public static Graphics Graphics => _buffer?.Graphics;

        public static void Init(Form form)
        {
            if (form == null)
            {
                throw new ArgumentException();
            }
                
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            _width = form.ClientSize.Width;
            _height = form.ClientSize.Height;
            BackgroundColor = form.BackColor;
            _buffer = _context.Allocate(g, new Rectangle(0, 0, _width, _height));
        }

        public static void Clear()
        {
            _buffer?.Graphics.Clear(BackgroundColor);
        }

        public static void Render()
        {
            _buffer?.Render();
        }

    }
}
