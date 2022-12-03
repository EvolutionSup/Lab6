using System.Drawing;

namespace FiguresLib
{
    /// <summary>
    /// Класс, реализующий модель прямоугольника.
    /// </summary>
    public class Rectangle : Figure
    {
        /// <summary>
        /// Конструктор прямоугольника.
        /// </summary>
        /// <param name="id">ID конкретного экземпляра</param>
        /// <param name="x">X координата верхнего левого угла</param>
        /// <param name="y">Y координата верхнего левого угла</param>
        /// <param name="w">Ширина прямоугольника</param>
        /// <param name="h">Высота прямоугольника</param>
        /// <param name="name">Поле, содержащее название фигуры.</param>
        public Rectangle(int id, int x, int y, int w, int h, string name = "Прямоугольник") : base(id, x, y)
        {
            this.w = w;
            this.h = h;
            this.n_name = name;
        }
        /// <summary>
        /// Реальный метод прорисовки прямоугольника.
        /// </summary>
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(Init.pen, x, y, w, h);
            Init.pictureBox.Image = Init.bitmap;
        }
        /// <summary>
        /// Реальный метод, возвращающий полное имя конкретного прямоугольника.
        /// </summary>
        public override string Name
            { get { return "Прямоугольник " + this.id.ToString(); } }
    }
}
