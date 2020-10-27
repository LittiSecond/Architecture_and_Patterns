using System;


namespace Task_lesson7
{
    public class ShippingCostCalculator
    {
        public double CalculateCost(Order order, IShippingStrategy strategy)
        {
            if (strategy == null)
            {
                throw new ArgumentException();
            }

            return strategy.Calculate(order);
        }

    }
}
