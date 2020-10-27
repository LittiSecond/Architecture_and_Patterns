namespace Task_lesson6
{
    class Emoloyee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public Post Post { get; set; }

        public Emoloyee(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

    }
}
