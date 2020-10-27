namespace Task_lesson6
{
    interface IWorker : IPost
    {
        bool SendMoneyRequest(MoneyRequest request);
    }
}
