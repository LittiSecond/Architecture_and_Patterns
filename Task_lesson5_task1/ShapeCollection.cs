using System;
using System.Collections.Generic;


namespace Task_lesson5_task1
{
    class ShapeCollection
    {
        private Dictionary<int, IDrawShapeAPI> _shapes;
        private int _lastIndex;

        public ShapeCollection()
        {
            _shapes = new Dictionary<int, IDrawShapeAPI>();
            _lastIndex = -1;
            AddShape(new NullShape());
        }

        /// <summary>
        /// Добавить фигуру в коллекцию.
        /// </summary>
        /// <param name="shape"></param>
        /// <returns> id фигуры, если добавлена; 
        /// -1, если фигура не добавлена</returns>
        public int AddShape(IDrawShapeAPI shape)
        {
            if (shape == null)
            {
                return -1;
            }            
            _lastIndex++;
            _shapes.Add(_lastIndex, shape);
            return _lastIndex;
        }

        public IDrawShapeAPI GetShape(int shapeId)
        {
            if (_shapes.ContainsKey(shapeId))
            {
                return _shapes[shapeId];
            }
            else
            {
                return _shapes[0];
            }
        }

        public void Clear()
        {
            IDrawShapeAPI nullElement = _shapes[0];
            _shapes.Clear();
            _shapes.Add(0, nullElement);
        }

    }
}
