/* Задание:
 * 1. Используя шаблон «Цепочка обязанностей», реализовать следующую задачу: 
 * сотрудник компании желает получить одобрение на получение некоторой суммы денег. 
 * Для получения одобрения сотрудник обращается к непосредственному руководителю. 
 * Руководитель не имеет полномочий одобрить выделение такой суммы денег (может 
 * одобрить меньшую сумму) и обращается к своему руководителю (директору компании).
 * Директор компании может одобрить или отклонить запрос и отправить ответ сотруднику.
 * */

using System;

namespace Task_lesson6
{
    class Program
    {
        private static Staff _staff;
        private static ConsoleLogger _logger;

        static void Main(string[] args)
        {
            _logger = new ConsoleLogger();

            _staff = new Staff();
            _staff.Logger = _logger;

            LoadStaff(_staff);

            Console.WriteLine("----------");

            SendRequestToGetMoney(204 ,35000.1);

            Console.WriteLine("----------");

            SendRequestToGetMoney(204, 21000.8);

            Console.WriteLine("----------");

            SendRequestToGetMoney(204, 140000.0);

            Console.WriteLine("----------");

            Console.ReadKey();
        }

        private static void SendRequestToGetMoney(int workerId, double summ)
        {
            IPost post = _staff.GetPost(workerId);
            IWorker worker = post as IWorker;
            if (worker != null)
            {
                MoneyRequest request = new MoneyRequest("На дополнительные командировочные расходы.", summ);

                bool isApprove = worker.SendMoneyRequest(request);

                if (isApprove)
                {
                    _logger.Log($"Запрос на сумму {summ} одобрен.");
                }
                else
                {
                    _logger.Log($"Запрос на сумму {summ} отклонён.");
                }
            }

        }

        /// <summary>
        /// ------ Заглушка. Тут штат сотрудников как-бы загружается из БД ----
        /// </summary>
        /// <param name="staff"></param>
        private static void LoadStaff(Staff staff)
        {
            staff.AddPost(PostType.Director,  101, "Директор");
            staff.AddPost(PostType.DepartamentChief, 302, "Начальник отдела 1");
            staff.AddPost(PostType.DepartamentChief, 203, "Начальник отдела 2");
            staff.AddPost(PostType.Worker, 204, "Ведущий инженер - технический писатель");
            staff.AddPost(PostType.Worker, 305, "Техник");
            staff.AddPost(PostType.Worker, 106, "Советник директора");
            staff.AddPost(PostType.Worker, 207, "Ответственный за делопроизводство");

            staff.SetInferrior(101, 106);
            staff.SetInferrior(101, 302);
            staff.SetInferrior(101, 203);
            staff.SetInferrior(302, 305);
            staff.SetInferrior(203, 204);
            staff.SetInferrior(203, 207);
            staff.SetInferrior(101, 203);

            staff.AddEmployee(1001, "ИмяРаботника1", "ФамилияРаботника1");
            staff.AddEmployee(1002, "ИмяДиректора", "ФамилияДиректора");
            staff.AddEmployee(1003, "ИмяНачальника3", "ФамилияНачальника3");
            staff.AddEmployee(1004, "ИмяНачальника4", "ФамилияНачальника4");
            staff.AddEmployee(1005, "ИмяИнженера5", "ФамилияИнженера5");
            staff.AddEmployee(1006, "ИмяТехника6", "ФамилияТехника6");
            staff.AddEmployee(1007, "ИмяСекритория7", "ФамилияСекритория7");

            staff.SetEmployeeToPost(1001, 106);
            staff.SetEmployeeToPost(1002, 101);
            staff.SetEmployeeToPost(1003, 203);
            staff.SetEmployeeToPost(1004, 302);
            staff.SetEmployeeToPost(1005, 204);
            staff.SetEmployeeToPost(1006, 305);
            staff.SetEmployeeToPost(9999, 207);

            SetApproveLimit();
        }

        private static void SetApproveLimit()
        {
            IPost post = _staff.GetPost(203);
            IDepartamentChief chief = post as IDepartamentChief;
            if (chief != null)
            {
                chief.ApproveLimit = 30000.0;
            }
        }
    }
}
