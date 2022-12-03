namespace RPN
{
    /// <summary>
    /// Объект-операнд, который хранит свое значение из начальной строки.
    /// </summary>
    public class Operand
    {
        public object value;
        /// <summary>
        /// Конструктор операнда, принимающий 1 параметр - свое значение из начальной строки.
        /// </summary>
        /// <param name="NewValue">Любой объект - значение данного операнда.</param>
        public Operand(object NewValue)
        {
            value = NewValue;
        }
    }
}
