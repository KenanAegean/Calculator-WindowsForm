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
        private string sc = "";
        private bool isEvaluate = true;

        private Button[] numButtons = new Button[10];
        private Button[] opButtons = new Button[6];
        private Button[] scnButtons = new Button[8];


        public Form1()
        {
            //Create Dynamic Interface
            dynamicNumButtonMaker();
            dynamicOpButtonMaker();
            dynamicScienceButtonMaker();

            InitializeComponent();
            calculationShow.Text = "";
        }

        private void dynamicScienceButtonMaker()
        {
            //empty for now
            String[] scnOperators = { "Sqrt", "Log", "Ln", "Sin", "Cos", "Tan", "Pi", "Fac" };
            int y = 0;
            int x = 0;
            for (int i = 0; i < scnButtons.Length; i++)
            {

                scnButtons[i] = new Button
                {
                    Name = "opButton " + scnOperators[i],
                    Location = new Point(235 + (19*x) , 55 * (y + 2) - 25),
                    Size = new Size(50, 50),
                    BackColor = Color.BlueViolet,
                    ForeColor = Color.White,
                    Text = scnOperators[i]
                };

                if (i == 3)
                {
                    x = 2;
                    ++x;
                }
                else if(i <= 3)
                {
                    y++;
                }
                else
                {
                    y--;
                }
                scnButtons[i].Click += new EventHandler(this.scienceFucntion);
                this.Controls.Add(scnButtons[i]);
            }      
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
            
            isEvaluate = true;
            //float number = Convert.ToUInt32(txtResult.Text);
            if(txtResult.Text != "")
            {
                switch (op)
                {
                    case "+":
                        result += float.Parse(txtResult.Text);
                        break;
                    case "-":
                        result -= float.Parse(txtResult.Text);
                        break;
                    case "*":
                        result *= float.Parse(txtResult.Text);
                        break;
                    case "/":
                        result /= float.Parse(txtResult.Text);
                        break;
                    case "=":
                        txtResult.Text = result.ToString();
                        break;
                    default:
                        //result = Convert.ToUInt32(txtResult.Text);
                        result = float.Parse(txtResult.Text);
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
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            calculationShow.Text = "";
            //result = 0;
            isEvaluate = true;
            op = "";
            sc = "";
            txtResult.Text = "";
        }


        private void scienceFucntion(object sender, EventArgs e)
        {
            //"Sqrt", "Log", "Ln", "Sin", "Cos", "Tan", "Pi", "Fac"
            //isEvaluate = true;
            //float number = Convert.ToUInt32(txtResult.Text);
            //some kinde error here to solve!!
            if (txtResult.Text  != "")
            {
                sc = (sender as Button).Text;
                switch (sc)
                {
                    case "Sqrt":
                        double sqrt = Double.Parse(txtResult.Text);
                        calculationShow.Text = System.Convert.ToString("√" + (txtResult.Text));
                        sqrt = Math.Sqrt(sqrt);
                        txtResult.Text = System.Convert.ToString(sqrt);
                        this.result = float.Parse(txtResult.Text);
                        break;
                    case "Log":
                        double Log = Double.Parse(txtResult.Text);
                        calculationShow.Text = System.Convert.ToString("log" + "(" + (txtResult.Text) + ")");
                        Log = Math.Log10(Log);
                        txtResult.Text = System.Convert.ToString(Log);
                        this.result = float.Parse(txtResult.Text);
                        break;
                    case "Ln":
                        double Ln = Double.Parse(txtResult.Text);
                        calculationShow.Text = System.Convert.ToString("ln" + "(" + (txtResult.Text) + ")");
                        Log = Math.Log(Ln);
                        txtResult.Text = System.Convert.ToString(Log);
                        this.result = float.Parse(txtResult.Text);
                        break;
                    case "Sin":
                        double sin = Double.Parse(txtResult.Text);
                        calculationShow.Text = System.Convert.ToString("Sin" + (txtResult.Text));
                        sin = Math.Sin(sin);
                        txtResult.Text = System.Convert.ToString(sin);
                        this.result = float.Parse(txtResult.Text);
                        break;
                    case "Cos":
                        double cos = Double.Parse(txtResult.Text);
                        calculationShow.Text = System.Convert.ToString("Cos" + (txtResult.Text));
                        cos = Math.Cos(cos);
                        txtResult.Text = System.Convert.ToString(cos);
                        this.result = float.Parse(txtResult.Text);
                        break;
                    case "Tan":
                        double tan = Double.Parse(txtResult.Text);
                        calculationShow.Text = System.Convert.ToString("Tan" + (txtResult.Text));
                        tan = Math.Tan(tan);
                        txtResult.Text = System.Convert.ToString(tan);
                        this.result = float.Parse(txtResult.Text);
                        break;
                    case "Pi":
                        txtResult.Text = "3,141592653589";
                        this.result = float.Parse(txtResult.Text);
                        break;
                    case "Fac":
                        double fac = Double.Parse(txtResult.Text);
                        double result = 1;
                        fac = Math.Round(fac); //ensure it is not float
                        if (fac == 0)
                        {
                            result = 1;
                        } 
                        else
                        {
                            while (fac != 1)
                            {
                                result = result * fac;
                                fac = fac - 1;
                            }
                        }                       
                        txtResult.Text = result.ToString();
                        this.result = float.Parse(txtResult.Text);
                        break;
                    default:
                        this.result = float.Parse(txtResult.Text);
                        //txtResult.Clear();
                        break;
                }
                
            }
            else if((sender as Button).Text == "Pi")
            {
                txtResult.Text = "3,141592653589";
                this.result = float.Parse(txtResult.Text);
            }
            
            


        }
    }
}

