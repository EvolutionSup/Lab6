using System;
using System.Drawing;
using System.Windows.Forms;

namespace FiguresLib
{
    /// <summary>
    /// Вспомогательный класс, содержащий свойства и метода, доступ к которым возможен из любого участка кода.
    /// </summary>
    public static class Init
    {
        public static Bitmap bitmap;
        public static PictureBox pictureBox;
        public static Pen pen;
        public static ListBox figuresListBox;
        public static BindingSource bs;
        /// <summary>
        /// Метод, проверяющий выход за пределы окна фигуры, совершающей поворот.
        /// </summary>
        /// <param name="x">X координата верхнего левого угла</param>
        /// <param name="y">Y координата верхнего левого угла</param>
        /// <param name="x0">X координата точки поворота</param>
        /// <param name="y0">Y координата точки поворота</param>
        /// <param name="angle">Угол поворота в градусах</param>
        /// <returns></returns>
        public static bool AngledShiftCheck(int x, int y, int x0, int y0, int angle)
        {
            double angleRadian = angle * Math.PI / 180;
            float res_x = (float)((x - x0) * Math.Cos(angleRadian) - (y - y0) * Math.Sin(angleRadian) + x0);
            float res_y = (float)((x - x0) * Math.Sin(angleRadian) + (y - y0) * Math.Cos(angleRadian) + y0);
            if ((res_x > 0) && (res_y > 0) && (res_x < Init.pictureBox.Width) && (res_y < Init.pictureBox.Height))
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Метод, проверяющий выход за пределы окна фигуры, которую можно вписать в прямоугольник.
        /// </summary>
        /// <param name="x">X координата верхнего левого угла</param>
        /// <param name="y">Y координата верхнего левого угла</param>
        /// <param name="w">Ширина прямоугольника</param>
        /// <param name="h">Высота прямоугольника</param>
        /// <returns>Возвращает true, если фигура не вышла за пределы окна</returns>
        public static  bool Coords_check(int x, int y, int w, int h)
        {
            if (!((x < 0) || (y < 0) || (x + w > Init.pictureBox.Width) || (y + h > Init.pictureBox.Height)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Метод, проверяющей выход за пределы окна фигуры, которая задается массивом точек.
        /// </summary>
        /// <param name="points">Массив точек фигуры</param>
        /// <param name="x">dx - смещение по оси x</param>
        /// <param name="y">dy - смещение по оси y</param>
        /// <returns>Возвращает true, если фигура не вышла за пределы окна</returns>
        public static bool Coords_check(Point[] points, int x, int y)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if ((points[i].X + x < 0) || (points[i].Y + y < 0) || (points[i].X + x > Init.pictureBox.Width) ||
                    (points[i].Y + y > Init.pictureBox.Height))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Метод, очищающий окно.
        /// </summary>
        public static void Clear()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
        }
    }
}
