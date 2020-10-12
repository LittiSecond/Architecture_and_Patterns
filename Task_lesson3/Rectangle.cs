namespace Task_lesson3
{
    class Rectangle : BaseShape
    {
        public double Width { get; set; }
        public double Heigth { get; set; }

        public Rectangle()
        {
            Init(0, 0);
        }

        public Rectangle(double x, double y, double width, double heigth) : base(x, y)
        {
            Init(width, heigth);
        }

        public Rectangle(Vector2 position, double width, double heigth)
            : base(position)
        {
            Init(width, heigth);
        }

        private void Init(double width, double heigth)
        {
            Width = width;
            Heigth = heigth;
            _type = ShapeType.Rectangle;
        }

        public override string ToString()
        {
            return $"{_type.ToString()} position = {Position}, " +
                $"width = {Width}, heigth = {Heigth} ";
        }

    }
}
