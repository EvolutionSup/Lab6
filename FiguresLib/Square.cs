using System.Drawing;
using System.Drawing.Drawing2D;

namespace FiguresLib
{
    /// <summary>
    /// Класс, реализующий модель квадрата.
    /// </summary>
    public class Square : Rectangle
    {
        public Matrix matrix = new Matrix();
        /// <summary>
        /// Конструктор квадрата.
        /// </summary>
        /// /// <param name="id">ID конкретного экземпляра</param>
        /// <param name="x">X координата верхнего левого угла</param>
        /// <param name="y">Y координата верхнего левого угла</param>
        /// <param name="w">Длина стороны</param>
        /// <param name="name">Поле, содержащее название фигуры.</param>
        public Square(int id, int x, int y, int w, string name = "Квадрат") : base(id, x, y, w, w, name)
        { }
        /// <summary>
        /// Реальный метод, возвращающий полное имя конкретного квадрата.
        /// </summary>
        public override string Name
        { get { return "Квадрат " + this.id.ToString(); } }
        /// <summary>
        /// Реальный метод прорисовки квадрата.
        /// </summary>
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Transform = matrix;
            g.DrawRectangle(Init.pen, x, y, w, h);
            Init.pictureBox.Image = Init.bitmap;
        }
    }
}
