using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W7Homework1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics graphics;
        double th1;
        double th2;
        double per1;
        double per2;
        int n;
        int leng;
        Pen[] pens = { Pens.DodgerBlue, Pens.MediumPurple,Pens.LightPink,Pens.LimeGreen,Pens.OrangeRed };



        private void BtnDraw_Click(object sender, EventArgs e)
        {
            th1 = double.Parse(txtTh1.Text) * Math.PI / 180;
            th2 = double.Parse(txtTh2.Text) * Math.PI / 180;
            per1 = double.Parse(txtper1.Text);
            per2 = double.Parse(txtper2.Text);
            leng = int.Parse(txtleng.Text);
            n = int.Parse(txtRecursionDepth.Text);
            Pen pen = pens[cmbpen.SelectedIndex];

            if (graphics == null) graphics = panelForDraw.CreateGraphics();
            drawCayleyTree(n, 200, 310, leng, -Math.PI / 2,pen);
            
        }

        void drawCayleyTree(int n, double x0, double y0, double leng, double th,Pen pen)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1,pen);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1,pen);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2,pen);
        }

        void drawLine(double x0,double y0,double x1,double y1,Pen pen)
        {
            graphics.DrawLine(pen,(int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            graphics.Clear(panelForDraw.BackColor);
          
        }


    }
}
