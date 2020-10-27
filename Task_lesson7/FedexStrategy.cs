using System;


namespace Task_lesson7
{
    public class FedexStrategy : IShippingStrategy
    {
        public double Calculate(Order order)
        {
            return 5.0;
        }
    }
}
