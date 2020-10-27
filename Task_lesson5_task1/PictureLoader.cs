using System;
using System.Collections.Generic;
using System.Drawing;


namespace Task_lesson5_task1
{

    /// <summary>
    ///           ===   не  смотреть этот класс, это ЗАГЛУШКА,   =====
    ///                    замена нормального источника данных
    ///                    
    ///  ... накидал его как быстрее, чтобы быстрее написать ... 
    ///    для задачи не важно откуда берутся данные по фигурам
    /// </summary>
    class PictureLoader
    {

        private ShapeCollection _shapeCollection;
        private List<PictureElement> _pictureElements;
        private List<int> _shapeIdList;

        public PictureLoader()
        {
            _shapeCollection = new ShapeCollection();
            _pictureElements = new List<PictureElement>();
            _shapeIdList = new List<int>();
        }

        public void LoadPicture(Graphics graphics)
        {
            _shapeCollection.Clear();
            _pictureElements.Clear();
            _shapeIdList.Clear();

            IDrawShapeAPI shape;

            shape = new MyRect(graphics, Pens.DarkRed);
            _shapeIdList.Add(_shapeCollection.AddShape(shape));

            shape = new MyCircle(graphics, Pens.DarkBlue);
            _shapeIdList.Add(_shapeCollection.AddShape(shape));


            _pictureElements.Add(new PictureElement(1, 10,  10,  40, 40));
            _pictureElements.Add(new PictureElement(2, 110, 10,  60, 50));
            _pictureElements.Add(new PictureElement(1, 220, 10,  80, 60));
            _pictureElements.Add(new PictureElement(2, 310, 10,  40, 70));
            _pictureElements.Add(new PictureElement(1, 10,  110, 60, 80));
            _pictureElements.Add(new PictureElement(2, 110, 110, 80, 50));
            _pictureElements.Add(new PictureElement(1, 210, 110, 40, 60));
            _pictureElements.Add(new PictureElement(2, 310, 110, 60, 70));
            _pictureElements.Add(new PictureElement(1, 10,  210, 80, 80));
            _pictureElements.Add(new PictureElement(2, 110, 210, 40, 50));
            _pictureElements.Add(new PictureElement(1, 210, 210, 60, 60));
            _pictureElements.Add(new PictureElement(2, 310, 210, 80, 70));
            _pictureElements.Add(new PictureElement(1, 10,  310, 40, 80));
            _pictureElements.Add(new PictureElement(2, 110, 310, 60, 50));
            _pictureElements.Add(new PictureElement(1, 210, 310, 80, 60));
            _pictureElements.Add(new PictureElement(2, 310, 310, 40, 70));

        }

        public ShapeCollection GetShapeCollection()
        {
            return _shapeCollection;
        }

        public List<PictureElement> GetPictureElements()
        {
            return _pictureElements;
        }

    }
}
