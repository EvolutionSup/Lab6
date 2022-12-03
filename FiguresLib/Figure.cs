using System.Drawing;

namespace FiguresLib
{
    /// <summary>
    /// Абстрактный класс фиугуры.
    /// </summary>
    abstract public class Figure
    {
        public int x;
        public int y;
        public int w;
        public int h;

        public string n_name = "Фигура";
        public int id;
        public Point[] points;
        /// <summary>
        /// Конструктор фигуры.
        /// </summary>
        /// <param name="id">ID конкретного экземпляра</param>
        /// <param name="x">X координата верхнего левого угла</param>
        /// <param name="y">Y координата верхнего левого угла</param>
        public Figure(int id, int x, int y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Абстракный метод прорисовки.
        /// </summary>
        abstract public void Draw();
        /// <summary>
        /// Метод перемещения фигуры.
        /// </summary>
        /// <param name="x">dx - смещение по оси x.</param>
        /// <param name="y">dy - смещение по оси y.</param>
        public void MoveTo(int x, int y)
        {
            this.x += x;
            this.y += y;
            this.DeleteF(this, false);
            this.Draw();
        }
        /// <summary>
        /// Метод удаления фигуры.
        /// </summary>
        /// <param name="figure">Фигура, которую нужно удалить.</param>
        /// <param name="flag">Флаг, определяющий удаление ее также из списка фигур.</param>
        public void DeleteF(Figure figure, bool flag = true)
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            ShapeContainer.figureList.Remove(figure);
            Init.Clear();
            Init.pictureBox.Image = Init.bitmap;
            foreach (Figure f in ShapeContainer.figureList)
            {
                f.Draw();
            }
            if (flag == false)
            {
                ShapeContainer.figureList.Add(figure);
            }
        }
        /// <summary>
        /// Виртуальный метод, возвращающий полное название фигуры. Переопределяется в реальных классах-наследниках.
        /// </summary>
        public virtual string Name
        {
            get;
        }
    }
}
