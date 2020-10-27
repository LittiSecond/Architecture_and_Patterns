using System;

namespace Task_lesson6
{
    class Director : Post
    {

        private double _approveLimit ;

        public Director(int id, string name) : base(id, name)
        {

        }

        public override bool WorkRequest(Request request)
        {
            if (Emoloyee == null)
            {
                Log("Worker::SendMoneyRequest: Ошибка. Работник на должность не назначен.");
                return false;
            }

            bool isApprove = false;

            if (request is MoneyRequest)
            {
                MoneyRequest moneyRequest = request as MoneyRequest;
                isApprove = WorkMoneyRequest(moneyRequest);
            }
            //else if (request is OtherType)  // обработка запросов других типов
            //{

            //}

            return isApprove;
        }

        private bool WorkMoneyRequest(MoneyRequest moneyRequest)
        {
            GenerateMessageToLogMoneyRequest(moneyRequest);
            //
            //  какой-то процесс рассмотрения назначения денег, 
            //    указанного в  request.Description
            //
            _approveLimit = 100000.0; // директор почему-то так решил

            return (moneyRequest.Summ <= _approveLimit);
        }


        private void GenerateMessageToLogMoneyRequest(MoneyRequest request)
        {
            string message = $"Директор {Emoloyee.Name} {Emoloyee.Surname} " +
                $" приступил к рассмотрению запроса на получениее суммы = {request.Summ}" +
                $" с назначением  \"{request.Description}\" ";
            Log(message);
        }
    }
}
