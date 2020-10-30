using System;


namespace Task_lesson7
{
    public class UpsStrategy : IShippingStrategy
    {
        public double Calculate(Order order)
        {
            return 4.0;
        }
    }
}
