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

        private Button[] numButtons = new Button[10];
        private Button[] opButtons = new Button[6];


        public Form1()
        {
            dynamicNumButtonMaker();
            dynamicOpButtonMaker();
            dynamicScienceButtonMaker();

            InitializeComponent();
            calculationShow.Text = "";
        }

        private void dynamicScienceButtonMaker()
        {
            //empty for now
        }

        private void dynamicOpButtonMaker()
        {
            String[] operators = { "/", "*", "-", "+", "=" };
            int y = 0;
            int x = 0;
            for (int i = 0; i < opButtons.Length; i++)
            {
                if (i == 0)
                {
                    opButtons[i] = new Button
                    {
                        Name = "btnClear",
                        Location = new Point(178, 85),
                        Size = new Size(50, 50),
                        BackColor = Color.DarkOrange,
                        ForeColor = Color.White,
                        Text = "C"
                    };
                    opButtons[i].Click += new EventHandler(this.btnClear_Click);
                }
                else
                {
                    opButtons[i] = new Button
                    {
                        Name = "opButton" + operators[i - 1],
                        Location = new Point(178 - 55 * y, 85 + 55 * (x + 1)),
                        Size = new Size(50, 50),
                        BackColor = Color.Black,
                        ForeColor = Color.White,
                        Text = operators[i - 1]
                    };

                    if (i >= 3)
                    {
                        y++;
                        x = 2;
                    }
                    else
                    {
                        x++;
                    }
                    opButtons[i].Click += new EventHandler(this.operatorsClicked);
                }
                this.Controls.Add(opButtons[i]);
            }
        }

        private void dynamicNumButtonMaker()
        {
            int line = 0;
            int column = 0;

            for (int i = 0; i < numButtons.Length; i++)
            {
                numButtons[i] = new Button
                {
                    Location = new Point(13 + column * 55, 250 - line * 55),
                    Name = "button" + i,
                    Size = new Size(50, 50),
                    TabIndex = i + 1,
                    Text = (i).ToString(),
                    //UseVisualStyleBackColor = true,
                    BackColor = Color.DarkSlateGray,
                    ForeColor = Color.White
                };
                numButtons[i].Click += new EventHandler(this.numsClicked);
                column = ++column % 3;

                if (i == 0)
                {
                    column = 0;
                }
                this.Controls.Add(numButtons[i]);

                if (column == 0)
                {
                    line++;
                }

            }
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
            //some kinde error here to solve!!
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
                    txtResult.Clear();
                    break;
            }
            op = (sender as Button).Text;
            //txtResult.Clear();
            
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

