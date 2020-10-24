
namespace Task_lesson6
{
    class MoneyRequest : Request
    {

        
        public double Summ { get; private set; } 

        public MoneyRequest(string description, double summ) : base(description)
        {
            Summ = summ;
        }



    }
}
