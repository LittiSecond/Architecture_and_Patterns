using System.Drawing;


namespace Task_lesson5_task1
{
    struct PictureElement
    {
        public int ShapeId;
        public Point Position;
        public Point Size;

        public PictureElement(int id, int posX, int pozY, int sizeX, int sizeY)
        {
            ShapeId = id;
            Position = new Point(posX, pozY);
            Size = new Point(sizeX, sizeY);
        }

    }
}
