using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace editor
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            textBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#23252b");
            textBox2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            textBox2.BackColor = System.Drawing.ColorTranslator.FromHtml("#23252b");
        }
        DataTable dat = new DataTable();
        string sirCon = System.Configuration.ConfigurationManager.ConnectionStrings["editor.Properties.Settings.Database1ConnectionString"].ConnectionString;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form6 feg = new Form6();
            feg.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(sirCon))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Tabel WHERE NumeUtilizator=@num AND Parola=@par", con);
                cmd.Parameters.AddWithValue("@num", textBox1.Text);
                cmd.Parameters.AddWithValue("@par", textBox2.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dat);
                if (dat.Rows.Count!=0)
                {
                    Form1 f = new Form1();
                    dat.Clear();
                    f.ShowDialog();
                }
                else
                    MessageBox.Show(" Date de autentificare incorecte!");
            }
        }
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Form6 feg = new Form6();
            feg.ShowDialog();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form6 feg = new Form6();
            feg.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pentru a ajunge la 'MENIU' e nevoie mai intai sa te loghezi!");
        }
    }
}
