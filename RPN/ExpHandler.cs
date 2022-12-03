using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using FiguresLib;

namespace RPN
{
    /// <summary>
    /// Класс, реализовывающий методы по обработке исходной строки.
    /// </summary>
    public static class ExpHandler
    {
        public static Stack<Operator> operators = new Stack<Operator>();
        public static Stack<Operand> operands = new Stack<Operand>();
        public static ComboBox comboBoxConsole;
        public static int sq_count = 0;
        /// <summary>
        /// Метод, обрабатывающий полученную строку.
        /// Заполняет стеки операторов и операндов. Выполняет вызов метода обработки функциональных выражений. 
        /// </summary>
        /// <param name="line">Введенная пользователем строка.</param>
        public static void LineProcessing(string line)
        {
            operators.Clear();
            operands.Clear();
            try
            {
                string sourceExpression = line.Replace(" ", "");
                for (int i = 0; i < sourceExpression.Length; i++)
                {
                    if (IsNotOperation(sourceExpression[i]))
                    {
                        if (!Char.IsDigit(sourceExpression[i]))
                        {
                            operands.Push(new Operand(sourceExpression[i]));
                            while (i < sourceExpression.Length - 1 && IsNotOperation(sourceExpression[i + 1]))
                            {
                                string temp_str = operands.Pop().value.ToString() + sourceExpression[i + 1].ToString();
                                operands.Push(new Operand(temp_str));
                                i++;
                            }
                        }
                        else if (Char.IsDigit(sourceExpression[i]))
                        {
                            operands.Push(new Operand(sourceExpression[i].ToString()));
                            while (i < sourceExpression.Length - 1 && Char.IsDigit(sourceExpression[i + 1])
                                && IsNotOperation(sourceExpression[i + 1]))
                            {
                                int temp_num = Convert.ToInt32(operands.Pop().value.ToString()) * 10 +
                                    (int)Char.GetNumericValue(sourceExpression[i + 1]);
                                operands.Push(new Operand(temp_num.ToString()));
                                i++;
                            }
                        }
                    }

                    else if (sourceExpression[i] == 'S')
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push(OperatorContainer.FindOperator(sourceExpression[i]));
                        }
                    }
                    else if (sourceExpression[i] == 'M')
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push(OperatorContainer.FindOperator(sourceExpression[i]));
                        }
                    }
                    else if (sourceExpression[i] == 'D')
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push(OperatorContainer.FindOperator(sourceExpression[i]));
                        }
                    }
                    else if (sourceExpression[i] == 'R')
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push(OperatorContainer.FindOperator(sourceExpression[i]));
                        }
                    }
                    else if (sourceExpression[i] == '(')
                    {
                        operators.Push(OperatorContainer.FindOperator(sourceExpression[i]));
                    }
                    else if (sourceExpression[i] == ')')
                    {
                        do
                        {
                            if (operators.Peek().symbolOperator == '(')
                            {
                                operators.Pop();
                                break;
                            }
                            if (operators.Count == 0)
                            {
                                break;
                            }
                        }
                        while (operators.Peek().symbolOperator != '(');
                    }
                }
            }
            catch
            {
                MessageBox.Show("Параметры введены некорректно.");
                comboBoxConsole.Items.Add("Параметры введены некорректно.");
            }
            try
            {
                SelectingPerformingOperation(operators.Peek());
            }
            catch
            {
                MessageBox.Show("Введенной операции не существует.");
                comboBoxConsole.Items.Add("Введенной операции не существует.");
            }
        }
        /// <summary>
        /// Метод обработки функциональных выражений.
        /// </summary>
        /// <param name="op">Объект типа operator, задающий необходимые инструкции.</param>
        private static void SelectingPerformingOperation(Operator op)
        {
            if (op.symbolOperator == 'R')
            {
                if (operands.Count == 4)
                {
                    Square figure = null;
                    int y = Convert.ToInt32(operands.Pop().value.ToString());
                    int x = Convert.ToInt32(operands.Pop().value.ToString());
                    int angle = Convert.ToInt32(operands.Pop().value.ToString());
                    string name = operands.Pop().value.ToString();
                    foreach (Figure f in ShapeContainer.figureList)
                    {
                        if (f.n_name == name)
                        {
                            figure = (Square)f;
                        }
                    }
                    if (figure != null)
                    {
                        if (Init.AngledShiftCheck(figure.x, figure.y, x, y, angle))
                        {
                            double angleRadian = angle * Math.PI / 180;
                            figure.DeleteF(figure, false);
                            figure.matrix.RotateAt(angle, new PointF(x, y));
                            figure.Draw();
                            figure.x = (int)((figure.x - x) * Math.Cos(angleRadian) - (figure.y - y) * Math.Sin(angleRadian) + x);
                            figure.y = (int)((figure.x - x) * Math.Sin(angleRadian) + (figure.y - y) * Math.Cos(angleRadian) + y);
                            comboBoxConsole.Items.Add($"Квадрат {figure.n_name} повернут.");
                        }
                        else
                        {
                            MessageBox.Show("Фигура вышла за границы.");
                            comboBoxConsole.Items.Add("Фигура вышла за границы.");
                        }
                    }
                    else
                    {
                        comboBoxConsole.Items.Add($"Фигуры {name} не существует");
                    }
                }
                else
                {
                    MessageBox.Show("Опертор R принимает 4 параметра.");
                    comboBoxConsole.Items.Add("Неверное число параметров для оператора R.");
                }
            }
            else if (op.symbolOperator == 'S')
            {
                if (operands.Count == 4)
                {
                    sq_count += 1;
                    int a = Convert.ToInt32(operands.Pop().value.ToString());
                    int y = Convert.ToInt32(operands.Pop().value.ToString());
                    int x = Convert.ToInt32(operands.Pop().value.ToString());
                    string name = operands.Pop().value.ToString();
                    if (Init.Coords_check(x, y, a, a))
                    {
                        Square figure = new Square(sq_count, x, y, a, name);
                        op = new Operator(figure.Draw, 'S');
                        ShapeContainer.AddFigure(figure);
                        comboBoxConsole.Items.Add($"Квадрат {figure.n_name} отрисован");
                        op.operatorMethod();
                    }
                    else
                    {
                        MessageBox.Show("Фигура вышла за границы.");
                        comboBoxConsole.Items.Add("Фигура вышла за границы.");
                    }
                }
                else
                {
                    MessageBox.Show("Опертор S принимает 4 параметра.");
                    comboBoxConsole.Items.Add("Неверное число параметров для оператора S.");
                }
            }
            else if (op.symbolOperator == 'M')
            {
                if (operands.Count == 3)
                {
                    Square figure = null;
                    int y = Convert.ToInt32(operands.Pop().value.ToString());
                    int x = Convert.ToInt32(operands.Pop().value.ToString());
                    string name = operands.Pop().value.ToString();
                    foreach (Figure f in ShapeContainer.figureList)
                    {
                        if (f.n_name == name)
                        {
                            figure = (Square)f;
                        }
                    }
                    if (figure != null)
                    {
                        if (Init.Coords_check(figure.x + x, figure.y + y, figure.w, figure.h))
                        {
                            op = new Operator(figure.MoveTo, 'M');
                            op.binaryOperator(x, y);
                            comboBoxConsole.Items.Add($"Фигура {figure.n_name} успешно перемещена");
                        }
                        else
                        {
                            MessageBox.Show("Фигура вышла за границы.");
                            comboBoxConsole.Items.Add("Фигура вышла за границы.");
                        }
                    }
                    else
                    {
                        comboBoxConsole.Items.Add($"Фигуры {name} не существует");
                    }
                }
                else
                {
                    MessageBox.Show("Опертор M принимает 3 параметра.");
                    comboBoxConsole.Items.Add("Неверное число параметров для оператора M.");
                }
            }
            else if (op.symbolOperator == 'D')
            {
                if (operands.Count == 1)
                {
                    Square figure = null;
                    string name = operands.Pop().value.ToString();
                    foreach (Figure f in ShapeContainer.figureList)
                    {
                        if (f.n_name == name)
                        {
                            figure = (Square)f;
                        }
                    }
                    if (figure != null)
                    {
                        op = new Operator(figure.DeleteF, 'D');
                        op.deleteOperator(figure, true);
                        comboBoxConsole.Items.Add($"Фигура {figure.n_name} успешно удалена");
                    }
                    else
                    {
                        comboBoxConsole.Items.Add($"Фигуры {name} не существует");
                    }
                }
                else
                {
                    MessageBox.Show("Опертор D принимает 1 параматетр.");
                    comboBoxConsole.Items.Add("Неверное число параметров для оператора D.");
                }
            }
        }
        /// <summary>
        /// Метод, проверяющий символ на соответствие символу из списка операторов.
        /// </summary>
        /// <param name="item">Объект char, который будет проверен.</param>
        /// <returns>Возвращает true, усли символ не соотвествует ни одному оператору.</returns>
        private static bool IsNotOperation(char item)
        {
            if (!(item == 'R' || item == 'D' || item == 'M' || item == 'S' || item == ',' || item == '(' || item == ')'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
