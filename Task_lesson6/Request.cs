namespace Task_lesson6
{
    abstract class Request
    {
        public string Description { get; protected set; }


        public Request(string description)
        {
            Description = description;
        }

    }
}
