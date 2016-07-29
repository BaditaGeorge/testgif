using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace editor
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
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();
            f2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 c = new Form4();
            c.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form4 c = new Form4();
            c.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esti deja la pagina 'MENIU'");
        }
    }
}
