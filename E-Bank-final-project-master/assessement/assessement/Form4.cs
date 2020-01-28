using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assessement
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu openform = new Menu();
            openform.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 openform = new Form5();
            openform.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 openform = new Form6();
            openform.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 openform = new Form7();
            openform.Show();
            Visible = false;
        }
    }
}
