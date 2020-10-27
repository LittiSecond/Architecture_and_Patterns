using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_lesson7
{
    /*
     * Задание 1. Реализовать шаблон «Стратегия» без использования делегатов. При решении задачи следует 
     * использовать следующий интерфейс: IShippingStrategy
     * */


    class Program
    {
        private static EmsStrategy _emsStrategy;
        private static UpsStrategy _upsStrategy;
        private static FedexStrategy _fedexStrategy;
        private static ShippingCostCalculator _shippingCostCalculator;

        static void Main(string[] args)
        {
            Initialize();

            Order order = new Order();

            double emsCost = _shippingCostCalculator.CalculateCost(order, _emsStrategy);
            double upsCost = _shippingCostCalculator.CalculateCost(order, _upsStrategy);
            double fidexCost = _shippingCostCalculator.CalculateCost(order, _fedexStrategy);

            Console.WriteLine($" EMS стоимость: {emsCost};\n UPS стоимость: {upsCost}; \n FedEx стоимость: {fidexCost} ");

            Console.ReadKey();

        }

        private static void Initialize()
        {
            _emsStrategy = new EmsStrategy();
            _upsStrategy = new UpsStrategy();
            _fedexStrategy = new FedexStrategy();
            _shippingCostCalculator = new ShippingCostCalculator();
        }
    }
}
