namespace RPN
{
    /// <summary>
    /// Класс, представляющий объект - оператор.
    /// </summary>
    public class Operator : OperatorMethod
    {
        public char symbolOperator;
        public EmptyOperatorMethod operatorMethod = null;
        public BinaryOperatorMethod binaryOperator = null;
        public DeleteOperatorMethod deleteOperator = null;
        /// <summary>
        /// Конструктор для оператора прорисовки фигуры, метод которого принимает 0 параметров.
        /// </summary>
        /// <param name="operatorMethod">Делегат метода прорисовки</param>
        /// <param name="symbolOperator">Символ операции</param>
        public Operator(EmptyOperatorMethod operatorMethod, char symbolOperator)
        {
            this.operatorMethod = operatorMethod;
            this.symbolOperator = symbolOperator;
        }
        /// <summary>
        /// Конструктор для оператора перемещения, метод которого принимает 2 параметра:
        /// dx и dy - смещение фигуры по соответствующим осям координат.
        /// </summary>
        /// <param name="binaryOperator">Делегат метода перемещения</param>
        /// <param name="symbolOperator">Символ операции</param>
        public Operator(BinaryOperatorMethod binaryOperator, char symbolOperator)
        {
            this.binaryOperator = binaryOperator;
            this.symbolOperator = symbolOperator;
        }
        /// <summary>
        /// Конструктор для оператора удаления фигуры, метод которого принимает 2 параметра:
        /// фигуру, которую нужно удалить и флаг, определяющий удаление ее также из списка фигур.
        /// </summary>
        /// <param name="deleteOperator">Делегат метода удаления</param>
        /// <param name="symbolOperator">Символ операции</param>
        public Operator(DeleteOperatorMethod deleteOperator, char symbolOperator)
        {
            this.deleteOperator = deleteOperator;
            this.symbolOperator = symbolOperator;
        }
        /// <summary>
        /// Базовый конструктор для любого оператора, использующйися при обработке исходной строки.
        /// </summary>
        /// <param name="symbolOperator">Символ операции</param>
        public Operator(char symbolOperator)
        {
            this.symbolOperator = symbolOperator;
        }
    }
}
