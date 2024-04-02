using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
//using Button = System.Windows.Forms.Button;

namespace Calculator
{
    public partial class frmMain : Form
    {
        double num1;
        double num2;
        string operation;
        bool pressed = false;

        public frmMain()
        {
            InitializeComponent();

            // Register event handlers for number buttons
            btn0.Click += new EventHandler(numButton_Click);
            btn1.Click += new EventHandler(numButton_Click);
            btn2.Click += new EventHandler(numButton_Click);
            btn3.Click += new EventHandler(numButton_Click);
            btn4.Click += new EventHandler(numButton_Click);
            btn5.Click += new EventHandler(numButton_Click);
            btn6.Click += new EventHandler(numButton_Click);
            btn7.Click += new EventHandler(numButton_Click);
            btn8.Click += new EventHandler(numButton_Click);
            btn9.Click += new EventHandler(numButton_Click);

            

            // Register event handlers for operator buttons
            btnPlus.Click += new EventHandler(btnOperation_Click);
            btnMinus.Click += new EventHandler(btnOperation_Click);
            btnMultiply.Click += new EventHandler(btnOperation_Click);
            btnDivide.Click += new EventHandler(btnOperation_Click);

            txtCalculation.Text = "0";
        }

        private void numButton_Click(object sender, EventArgs e)
        {
           
            if  ((txtCalculation.Text == "0") || (pressed))
                txtCalculation.Clear();

            pressed = false;
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;

            txtCalculation.Text += button.Text;

        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            num1 = Convert.ToDouble(txtCalculation.Text);
            operation = button.Text;
            pressed = true;

        }

        private void btnEquel_Click(object sender, EventArgs e)
        {
            num2 = Convert.ToDouble(txtCalculation.Text);
            double result = 0;


            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    pressed = false;
                    break;
                case "-":
                    result = num1 - num2;
                    pressed = false;
                    break;
                case "*":
                    result = num1 * num2;
                    pressed = false;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        MessageBox.Show("Cannot divide by zero");
                        return;
                    }
                    result = num1 / num2;
                    break;
             default:
                    break;
            }
            pressed = true;
            txtCalculation.Text = result.ToString();
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCalculation.Text = "0";
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {

            if (pressed)
            {
                txtCalculation.Text = "0.";
                pressed = false;
            }
            else if (!txtCalculation.Text.Contains("."))
            {
                txtCalculation.Text += ".";
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtCalculation.Text.Length > 0)
            {
                txtCalculation.Text = txtCalculation.Text.Remove(txtCalculation.Text.Length - 1);
                if (txtCalculation.Text.Length == 0)
                    txtCalculation.Text = "0";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // this is test of pr
        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
