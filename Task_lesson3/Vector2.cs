namespace Task_lesson3
{
    struct Vector2
    {
        public double X;
        public double Y;

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector2(Vector2 other)
        {
            X = other.X;
            Y = other.Y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
