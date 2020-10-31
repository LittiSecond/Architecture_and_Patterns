using System;
using System.Windows.Forms;

namespace Task_lesson8
{
    /*
     * Задание 1. Используя шаблон MVC, разработать следующее приложение: на форме расположен 
     * textbox,  listbox и button. После ввода текста в textbox введенная строка добавляется в 
     * коллекцию значений в модели, а затем добавленная строка отображается в listbox.
     * */


    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();
            StringContainerModel model = new StringContainerModel();
            StringContainerController controller = new StringContainerController(form, model);
            form.StringContainerController = controller;
            form.StringContainerModelEventer = model;

            Application.Run(form);
        }
    }
}
