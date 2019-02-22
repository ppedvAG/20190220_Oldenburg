using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            myButton1.TripleClick += MyButton1_TripleClick;
            myButton1.TripleClick -= MyButton1_TripleClick;
            myButton1.TripleClick += MyButton1_TripleClick;

            myButton1.MouseEnter += MyButton1_MouseEnter;

            myButton1.MouseLeave += (s, e) => MessageBox.Show("Leave");
        }

        private void MyButton1_MouseEnter(object sender, EventArgs e)
        {
            MessageBox.Show("ENTER");
            myButton1.MouseEnter -= MyButton1_MouseEnter;

        }

        private void MyButton1_TripleClick(int clicks)
        {
            MessageBox.Show($"Clicks: {clicks}");
        }
    }
}
