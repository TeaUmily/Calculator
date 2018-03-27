using Calculator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class l : Form
    {

        double result = 0;
        String operation = string.Empty;
        bool isOperationOn = false;
        bool flag = false;

        public l()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        
        private void btn_number_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender; //preko sender-a prepozna o kojem broju se radi ili decimalnoj tocki
            

            if (textBox_result.Text == "0" || isOperationOn || !flag) // flag je tu kako bi se textBox ocistio ako je prethodno nesto bilo napisano (pr. "invalid input")
            {
                textBox_result.Clear();
            }

            isOperationOn = false;


            if (button.Text == ".")  
            {
                if (!textBox_result.Text.Contains("."))
                    textBox_result.Text = textBox_result.Text + ",";
            }
            else
            {
                textBox_result.Text = textBox_result.Text + button.Text; 
            }
              
        }

        private void btn_operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // preko sender-a prepozna o kojem se buttonu radi odnosno operaciji

            if(result != 0 && flag == false)
            {
                btn_calculate.PerformClick();
                operation = button.Text;
                isOperationOn = true;
            }
            else
            {
                operation = button.Text;
                result = Double.Parse(textBox_result.Text);
                isOperationOn = true;
            }
            flag = true;

        }

        private void Btn_clearEntry_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
            result = 0;
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            double secondOperand = double.Parse(textBox_result.Text);
            MathOperations operations = new MathOperations(result, secondOperand);

            switch (operation)
            {
                case "+":
                    textBox_result.Text = operations.plus().ToString("0.########");
                    break;
                case "-":
                    textBox_result.Text = operations.minus().ToString("0.########");
                    break;
                case "*":
                    textBox_result.Text = operations.multiply().ToString("0.########");
                    break;
                case "/":
                    if (secondOperand == 0)
                    {
                        textBox_result.Text = "Can't divide by zero";
                        isOperationOn = true;
                        return;
                    }
                    else { textBox_result.Text = operations.divided().ToString("0.########"); }
                    break;
                case "sin":
                    textBox_result.Text = operations.operationSinus().ToString("0.########");
                    break;
                case "cos":
                    textBox_result.Text = operations.operationCosinus().ToString("0.########");
                    break;
                case "log":
                    if (result == 0)
                    {
                        textBox_result.Text = "Invalid input";
                        return;
                    }
                    else
                    {
                        textBox_result.Text = operations.operationLog().ToString("0.########");
                    }
                    break;
                case "√":
                    if (result < 0)
                    {
                        textBox_result.Text = "Invalid input";
                        return;
                    }
                    else
                    {
                        textBox_result.Text = operations.operationSqrt().ToString("0.########");
                    }
                    break;
                case "2":
                    textBox_result.Text = operations.operationSquare().ToString("0.########");
                    break;
                default:
                    break;
                 
            }
            result = Double.Parse(textBox_result.Text);
            flag = true;
            
        }
    }
}
