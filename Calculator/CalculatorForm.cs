using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        // Были ли уже введены разделитель дробной части и значащие знаки
        bool is_dot_entered, is_zero;
        enum OperationCode { ADD, SUBTRACT, MULTIPLY, DIVIDE }
        OperationCode operation;
        decimal result;

        CultureInfo american_number_style = new CultureInfo("en-US");

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            OnClearClick(this, e);
        }

        private void OnDigitClick(object sender, EventArgs e)
        {
            char digit_char = (sender as Button).Text[0];
            // Не добавляем ведущие нули на дисплей
            if (digit_char == '0')
            {
                if (!is_zero || is_dot_entered)
                {
                    AppendToDisplay(digit_char);
                    is_zero = false;
                }
            }
            else
            {
                if (is_zero)
                {
                    SetToDisplay(digit_char.ToString());
                    is_zero = false;
                }
                else
                {
                    AppendToDisplay(digit_char);
                }
            }
        }

        private void OnDotClick(object sender, EventArgs e)
        {
            // Не добавляем второй разделитель дробной части
            if (!is_dot_entered)
            {
                is_dot_entered = true;
                if (is_zero)
                {
                    is_zero = false;
                    SetToDisplay("0.");
                }
                else
                {
                    AppendToDisplay('.');
                }
            }
        }

        private void OnClearClick(object sender, EventArgs e)
        {
            SetToDisplay("0");
            is_dot_entered = false;
            is_zero = true;
            result = 0;
        }

        private void OnOperationClick(object sender, EventArgs e)
        {
            // Сохраняем первый операнд
            result = ConvertToDecimal(lblDisplay.Text);
            is_zero = true;
            is_dot_entered = false;
            switch ((sender as Button).Text[0])
            {
                case '+': operation = OperationCode.ADD; break;
                case '-': operation = OperationCode.SUBTRACT; break;
                case '*': operation = OperationCode.MULTIPLY; break;
                case '/': operation = OperationCode.DIVIDE; break;
            }
        }

        private void OnEqualsClick(object sender, EventArgs e)
        {
            decimal second_operand = ConvertToDecimal(lblDisplay.Text);
            switch (operation)
            {
                case OperationCode.ADD:
                    result = result + second_operand;
                    break;
                case OperationCode.SUBTRACT:
                    result = result - second_operand;
                    break;
                case OperationCode.MULTIPLY:
                    result = result * second_operand;
                    break;
                case OperationCode.DIVIDE:
                    if (second_operand == 0)
                    {
                        OnClearClick(this, e);
                        SetToDisplay("ZERO_DIV_ERR");
                        break;
                    }
                    result = result / second_operand;
                    break;
            }
            // Если целое число, не выводим нулевую дробную часть
            SetToDisplay(
                (result == (int)result ? (int)result : result)
                .ToString(american_number_style)
            );
        }

        private void SetToDisplay(string s = "0")
        {
            lblDisplay.Text = s;
        }

        private void AppendToDisplay(char s)
        {
            lblDisplay.Text += s;
        }

        private decimal ConvertToDecimal(string number)
        {
            return Convert.ToDecimal(number, american_number_style);
        }
    }
}
