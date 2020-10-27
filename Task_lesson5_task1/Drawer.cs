using System;
using System.Drawing;
using System.Collections.Generic;


namespace Task_lesson5_task1
{

    /// <summary>
    /// -------------------------------     весь Flyweight здесь:  _shapeCollection и метод ReDrawPicture()
    /// -------------------------------        остально смотреть не надо
    /// </summary>
    class Drawer
    {

        private ShapeCollection _shapeCollection;    // коллекция вместо фабрики, описанной в примере методички

        private Graphics _graphics;
        private PictureLoader _pictureLoader;
        private List<PictureElement> _pictureElements;  // вспомогательный набор данных, может меняться динамически
                                                       // но для этой задачи это не нужно

        private int _nextElementIndex;

        public Drawer()
        {
            _graphics = GraphicHandler.Graphics;
            _pictureLoader = new PictureLoader();
            TimeHandler.Update += Draw;
            GetShapeCollection();
            _nextElementIndex = 0;
        }

        public void Draw(int time)
        {
            GraphicHandler.Clear();

            ReDrawPicture();

            GraphicHandler.Render();
        }

        private void GetShapeCollection()
        {
                _pictureLoader.LoadPicture(_graphics);
                _shapeCollection = _pictureLoader.GetShapeCollection();
                _pictureElements = _pictureLoader.GetPictureElements();
        }

        private void ReDrawPicture()
        {
            int shapeId;
            Point point1;
            Point point2;

            while (CalculateNextElement(out shapeId, out point1, out point2) )
            {
                IDrawShapeAPI shape = _shapeCollection.GetShape(shapeId);
                shape.DrawShape(point1, point2);
            }
        }

        private bool CalculateNextElement(out int shapeId, out Point point1, out Point point2)
        {
            if (_nextElementIndex >= _pictureElements.Count)
            {
                shapeId = 0;
                point1 = Point.Empty;
                point2 = Point.Empty;
                _nextElementIndex = 0;
                return false;
            }
            else
            {
                PictureElement element = _pictureElements[_nextElementIndex];
                shapeId = element.ShapeId;
                point1 = element.Position;
                point2 = element.Size;
                _nextElementIndex++;
                return true;
            }

        }


    }

}
