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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, kq;
            a = int.Parse(txtSo1.Text);
            b = int.Parse(txtSo2.Text);
            Calculation c = new Calculation(a,b);
            kq = c.Exectute("+");
            txtKQ.Text = kq.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int n;
            double x,kq;
            x = double.Parse(txtSo1.Text);
            n = int.Parse(txtSo2.Text);
            kq = Calculation.Power(x, n);
            txtKQ.Text = kq.ToString();
        }
    }
}
