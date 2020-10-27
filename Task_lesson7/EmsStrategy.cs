using System;


namespace Task_lesson7
{
    public class EmsStrategy : IShippingStrategy
    {
        public double Calculate(Order order)
        {
            return 3.0;
        }
    }
}
