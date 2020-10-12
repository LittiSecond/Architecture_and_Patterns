namespace Task_lesson3
{
    class Square : BaseShape
    {
        public double Side { get; set; }

        public Square()
        {
            Side = 0;
            _type = ShapeType.Square;
        }

        public Square(double x, double y, double side) : base(x, y)
        {
            Side = side;
            _type = ShapeType.Square;
        }

        public Square(Vector2 position, double side) : base(position)
        {
            Side = side;
            _type = ShapeType.Square;
        }

        public override string ToString()
        {
            return $"{_type.ToString()} position = {Position}, side = {Side} ";
        }

    }
}
