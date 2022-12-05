using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex1;
using Ex22;
using Ex3;

namespace IS_2_20_RomodanovGs_U
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Kek = new Exx1();
            Kek.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Kek1 = new Exx22();
            Kek1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Kek2 = new Exx3();
            Kek2.ShowDialog();
        }
    }
}
