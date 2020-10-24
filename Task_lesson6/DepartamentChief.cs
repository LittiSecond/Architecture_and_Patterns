namespace Task_lesson6
{
    class DepartamentChief : Post, IDepartamentChief
    {
        private double _approveLimit;

        public double ApproveLimit
        {
            set
            {
                _approveLimit = value;
            }
        }

        public DepartamentChief(int id, string name) : base(id, name)
        {
            _approveLimit = 0.0;
        }

        public override bool WorkRequest(Request request)
        {
            // рассмотрение запроса. Начальник в результате рассмотрения может:
            //      - одобрить самостоятельно;
            //      - отклонить самостоятельно;
            //      - отправить на рассмотрение вышестоящему начальнику.

            RequestWorkResultType requestResult;
            bool isApprove = false;

            if (Emoloyee != null)
            {


                if (request is MoneyRequest)
                {
                    MoneyRequest moneyRequest = request as MoneyRequest;
                    requestResult = WorkMoneyRequest(moneyRequest);
                }
                //else if (request is OtherType)  // обработка запросов других типов
                //{

                //}
                else  // неизвестный тип запроса
                {
                    requestResult = RequestWorkResultType.TransmitHigher;
                }

                if (requestResult == RequestWorkResultType.TransmitHigher)
                {
                    if (Chiff != null)
                    {
                        isApprove = Chiff.WorkRequest(request);
                    }
                }
                else
                {
                    isApprove = requestResult == RequestWorkResultType.Approve;
                }
            }
            else
            {
                Log("Worker::SendMoneyRequest: Ошибка. Работник на должность не назначен.");
            }

            return isApprove;
        }

        private RequestWorkResultType WorkMoneyRequest(MoneyRequest request)
        {
            RequestWorkResultType result;

            GenerateMessageToLogMoneyRequest(request);

            //
            //  какой-то процесс рассмотрения назначения денег, 
            //    указанного в  request.Description
            //

            result = RequestWorkResultType.Approve;

            if (request.Summ > _approveLimit)
            {
                result = RequestWorkResultType.TransmitHigher;
            }

            return result;
        }

        private void GenerateMessageToLogMoneyRequest(MoneyRequest request)
        {
            string message = $"Начальник {Emoloyee.Name} {Emoloyee.Surname} " +
                $" приступил к рассмотрению запроса на получениее суммы = {request.Summ}" +
                $" с назначением  \"{request.Description}\" ";
            Log(message);
        }

    }
}
