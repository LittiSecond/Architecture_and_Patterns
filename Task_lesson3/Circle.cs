namespace Task_lesson3
{
    class Circle : BaseShape
    {
        public double Radius { get; set; }

        public Circle()
        {
            Radius = 0;
            _type = ShapeType.Circle;
        }

        public Circle(double x, double y, double radius) : base(x, y)
        {
            Radius = radius;
            _type = ShapeType.Circle;
        }

        public Circle(Vector2 position, double radius) : base(position)
        {
            Radius = radius;
            _type = ShapeType.Circle;
        }

        public override string ToString()
        {
            return  $"{_type.ToString()} position = {Position}, " + 
                $"radius = {Radius} ";
        }

    }
}
