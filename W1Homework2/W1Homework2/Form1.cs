using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W1Homework2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.result.Text = "";
            this.num1.Text = "";
            this.num2.Text = "";
            this.ope.Text = "";
        }

        private void caculate_Click(object sender, EventArgs e)
        {
            int num1 = 0, num2 = 0;
            double result = 0;
            checked
            {
                try
                {
                    num1 = Convert.ToInt32(this.num1.Text);
                    num2 = Convert.ToInt32(this.num2.Text);
                }
                catch (OverflowException)
                {
                    this.result.Text = "输入数值过大";
                    return;
                }
            }

            switch (ope.Text)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = (double)num1 / (double)num2;
                    }
                    else
                    {
                        this.result.Text = "除数不能为0";
                        return;
                    }
                    break;

            }
            this.result.Text = result.ToString();
        }

        private void num1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
