using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task_lesson5_task1
{
    static class Program
    {

        private static Drawer _drawer;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();

            GraphicHandler.Init(form);
            GraphicHandler.BackgroundColor = Color.Gray;

            _drawer = new Drawer();

            TimeHandler.Start();

            Application.Run(form);

        }
    }
}
