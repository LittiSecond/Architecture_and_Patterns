namespace Task_lesson3
{
    class  BaseShape
    {

        protected Vector2 _position;
        protected ShapeType _type;

        public virtual Vector2 Position 
        { 
            get
            {
                return _position;
            }            
            set
            {
                _position = value;
            }
        
        }
        public ShapeType Type => _type;

        public BaseShape()
        {
            //Position = new Vector2();
            _position.X = 0;
            _position.Y = 0;
            _type = ShapeType.None;
        }

        public BaseShape(double x, double y)
        {
            _position.X = x;
            _position.Y = y;
            _type = ShapeType.None;
        }

        public BaseShape(Vector2 position)
        {
            _position = position;
            _type = ShapeType.None;
        }

    }
}
