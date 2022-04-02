using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorAppForm3
{
    public partial class Form1 : Form
    {
        private float result;
        private string op = "";
        private bool isEvaluate = true;
        public Form1()
        {
            InitializeComponent();
            calculationShow.Text = "";
        }
        
        private void numsClicked(object sender, EventArgs e)
        {
            if (isEvaluate)
            {
                txtResult.Text = "";
                isEvaluate = false;
                //calculationShow.Text = (sender as Button).Text;
            }
            txtResult.Text += (sender as Button).Text;
        }
        private void operatorsClicked(object sender, EventArgs e)
        {
            isEvaluate = true;
            float number = Convert.ToUInt32(txtResult.Text);
            switch (op)
            {
                case "+":
                    result += number;
                    break;
                case "-":
                    result -= number;
                    break;
                case "*":
                    result *= number;
                    break;
                case "/":
                    result /= number;
                    break;
                case "=":
                    txtResult.Text = result.ToString();
                    break;
                default:
                    result = number;
                    break;
            }
            op = (sender as Button).Text;
            txtResult.Clear();
            
            //checking section for correct position of =
            if ((sender as Button).Text == "=")
            {
                calculationShow.Text = (sender as Button).Text + " " + result;
            }
            else
            {
                calculationShow.Text = result + " " + (sender as Button).Text;
            }
            
            
        }

        //not working correctly
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            calculationShow.Text = "";
            result = 0;
            isEvaluate = true;
            op = "";
        }
    }
}

