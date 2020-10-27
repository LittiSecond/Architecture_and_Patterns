namespace Task_lesson6
{
    class Worker : Post, IWorker
    {


        public Worker(int id, string name) : base(id, name)
        {

        }

        public bool SendMoneyRequest(MoneyRequest request)
        {
            if (Emoloyee != null)
            {
                GenerateMessageToLogMoneyRequest(request);

                if (Chiff != null)
                {
                    return Chiff.WorkRequest(request);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Log("Worker::SendMoneyRequest: Ошибка. Работник на должность не назначен.");
                return false;
            }
        }

        public override bool WorkRequest(Request request)
        {
            throw new System.NotImplementedException();
        }

        private void GenerateMessageToLogMoneyRequest(MoneyRequest request)
        {
            string message = $"Работник {Emoloyee.Name} {Emoloyee.Surname} " +
                $" обратился к руководителю с просьбой на получениее суммы = {request.Summ}" + 
                $" с назначением  \"{request.Description}\" ";
            Log(message);
        }
    }
}
