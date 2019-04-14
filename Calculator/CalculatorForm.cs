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
    /*
     * TODO: 
     * separate implementation from model, 
     * keyboard =, keyboard clear, 
     * intermediate results on diplay and clipboard
     */ 
    public partial class CalculatorForm : Form
    {
         
        bool is_dot_entered, // Был ли уже введен разделитель дробной части,
             is_zero, // введены значащие знаки
             is_calculated; // результат прошлой операции просчитан
        enum OperationCode { ADD, SUBTRACT, MULTIPLY, DIVIDE, NOTHING }
        OperationCode operation;
        decimal last_result;

        CultureInfo american_number_style = new CultureInfo("en-US");

        public CalculatorForm()
        {
            InitializeComponent();
            // Все кнопки, кроме '=' сбрасывают предыдущее вычисление
            /*foreach(var control in this.tablayoutButtons.Controls)
            {
                if (control is Button)
                {
                    var btn = control as Button;
                    if (!btn.Equals(this.btnEquals))
                    {
                        (btn as Button).Click += NoCalculation;
                    }
                }
            } */
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            OnClearClick(this, e);
        }

        private void OnDigitClick(object sender, EventArgs e)
        {
            char digit_char = (sender as Button).Text[0];
            // Если вводится первая цифра числа, выводим ее вместо текущей надписи (если это не 0)
            if (is_zero && !is_dot_entered)
            {
                SetToDisplay(digit_char.ToString());
                is_zero = ( digit_char == '0' );
            }
            else
            {
                // Иначе дописываем цифру в конец дисплея
                AppendToDisplay(digit_char);
            }
            NoCalculation(sender, e);
        }

        private void OnDotClick(object sender, EventArgs e)
        {
            // Добавляем разделитель дробной части (но только 1 раз)
            if (!is_dot_entered)
            {
                is_dot_entered = true;
                if (is_zero)
                {
                    SetToDisplay("0");
                }
                AppendToDisplay('.');
            }
            NoCalculation(sender, e);
        }

        private void OnClearClick(object sender, EventArgs e)
        {
            SetToDisplay("0");
            is_dot_entered = false;
            is_zero = true;
            last_result = 0;
            operation = OperationCode.NOTHING;
            NoCalculation(sender, e);
        }

        private void OnOperationClick(object sender, EventArgs e)
        {
            OnCalculationClick(sender, e);
            // Считаем, что что прошлый результат - число на дисплее, оно же первый операнд
            last_result = ConvertToDecimal(lblDisplay.Text);
            // Вслед будет введено новое число
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

        private void OnCalculationClick(object sender, EventArgs e)
        {
            if (is_calculated)
            {
                return;
            }
            is_calculated = true;
            // Забираем 2-ой аргумент операции, исполняем операцию
            decimal second_operand = ConvertToDecimal(lblDisplay.Text);
            switch (operation)
            {
                case OperationCode.ADD:
                    last_result = last_result + second_operand;
                    break;
                case OperationCode.SUBTRACT:
                    last_result = last_result - second_operand;
                    break;
                case OperationCode.MULTIPLY:
                    last_result = last_result * second_operand;
                    break;
                case OperationCode.DIVIDE:
                    if (second_operand == 0)
                    {
                        OnClearClick(this, e);
                        SetToDisplay("ZERO_DIV_ERR");
                        last_result = 0;
                        return;
                    }
                    last_result = last_result / second_operand;
                    break;
                case OperationCode.NOTHING:
                    last_result = second_operand;
                    return;
            }
            // Выводим ответ (но если целое число, не выводим нулевую дробную часть)
            try
            {
                string output;
                if (last_result == Convert.ToInt64(last_result))
                {
                    is_dot_entered = false;
                    output = Convert.ToInt64(last_result).ToString();
                    
                }
                else
                {
                    is_dot_entered = true;
                    output = last_result.ToString();
                }
                SetToDisplay(output);
                CopyToClipboard(output);
                is_zero = last_result == 0;
            }
            catch
            {
                SetToDisplay("NUM_OVERFLOW");
            }
            finally
            {
                this.btnEquals.DialogResult = DialogResult.OK;
            }
        }
        private void NoCalculation(object sender, EventArgs e)
        {
            is_calculated = false;
        }

        private void CopyToClipboard(string s)
        {
            Clipboard.SetText(s);
        }

        private void SetToDisplay(string s = "0")
        {
            lblDisplay.Text = s;
        }

        private void OnKeyboardCharacterPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled) return;
            var button = (sender as Button);
            var ch = button.Text[0];
            if (ch == e.KeyChar)
            {
                e.Handled = true;
                if ('0' <= ch && ch <= '9')
                {
                    OnDigitClick(button, e);
                }
                else
                {
                    switch (ch)
                    {
                        case '=': OnCalculationClick(button, e); break;
                        case '.': OnDotClick(button, e); break;
                        case '+': case '-': case '*': case '/':OnOperationClick(button, e); break;
                    }
                }
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                OnCalculationClick(button, e);
            }
            if (e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = true;
                OnClearClick(button, e);
            }
        }

        private void OnKeyboardPress(object sender, KeyPressEventArgs e)
        {
            foreach(var btn in tablayoutButtons.Controls)
            {
                OnKeyboardCharacterPress(btn, e);
            }
        }

        private void AppendToDisplay(char s)
        {
            lblDisplay.Text += s;
        }

        private decimal ConvertToDecimal(string number)
        {
            return decimal.TryParse(lblDisplay.Text, NumberStyles.Any, american_number_style, out decimal parsed) 
                ? parsed : 0;
        }


        // черновик
        // В last_result записываем результат прошлой операции
        // Если прошлой операции еще не было, то last_result = 0, и видимого эффекта не будет
        // operation = OperationCode.NOTHING;
        // OnEqualsClick(this, e);
        // Затем считаем, 
        //  = 0;
    }
}
