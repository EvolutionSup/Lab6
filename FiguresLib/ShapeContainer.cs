using System.Collections.Generic;

namespace FiguresLib
{   
    /// <summary>
    /// Класс, реализующий список фигур.
    /// </summary>
    public class ShapeContainer
    {
        public static List<Figure> figureList;
        /// <summary>
        /// Статический конструктор, инициилизирующий список фигур
        /// </summary>
        static ShapeContainer()
        {
            figureList = new List<Figure>();
        }
        /// <summary>
        /// Метод добавления фигуры в список.
        /// </summary>
        /// <param name="figure">Экзмепляр фигуры, которая будет добавлена в список фигур.</param>
        public static void AddFigure(Figure figure)
        {
            figureList.Add(figure);
        }
    }
}
