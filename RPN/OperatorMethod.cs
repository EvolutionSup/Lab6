using FiguresLib;

namespace RPN
{
    /// <summary>
    /// Сущность, хранящая в качестве свойств делегаты на методы с различным количетсвом параметров. 
    /// </summary>
    public class OperatorMethod
    {
        /// <summary>
        /// Делагат на метод, принимающий 0 параметров.
        /// </summary>
        public delegate void EmptyOperatorMethod();
        /// <summary>
        /// Делегат на метод, принимающий 2 параметра типа int.
        /// </summary>
        /// <param name="operand1">первый операнд</param>
        /// <param name="operand2">второй операнд</param>
        public delegate void BinaryOperatorMethod(int operand1, int operand2);
        /// <summary>
        /// Делагет на метод удаления фигуры, принмающий 2 параметра. 
        /// </summary>
        /// <param name="operand1">Фигура, которую нужно удалить.</param>
        /// <param name="operand2">Флаг, определяющий удаление ее также из списка фигур.</param>
        public delegate void DeleteOperatorMethod(Figure operand1, bool operand2);
    }
}