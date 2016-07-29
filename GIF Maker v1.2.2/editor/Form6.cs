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
using System.Net.Mail;

namespace editor
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            textBox7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            textBox7.BackColor = System.Drawing.ColorTranslator.FromHtml("#23252b");
            textBox8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            textBox8.BackColor = System.Drawing.ColorTranslator.FromHtml("#23252b");
            textBox9.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            textBox9.BackColor = System.Drawing.ColorTranslator.FromHtml("#23252b");
            textBox10.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            textBox10.BackColor = System.Drawing.ColorTranslator.FromHtml("#23252b");
            textBox11.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            textBox11.BackColor = System.Drawing.ColorTranslator.FromHtml("#23252b");
            textBox12.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            textBox12.BackColor = System.Drawing.ColorTranslator.FromHtml("#23252b");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        string sirCon = System.Configuration.ConfigurationManager.ConnectionStrings["editor.Properties.Settings.Database1ConnectionString"].ConnectionString;
        public bool IsValid(string emailadress)
        {
            try
            {
                MailAddress m = new MailAddress(emailadress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(sirCon))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Tabel(NumeUtilizator,Parola,Email,Nume,Prenume) VALUES(@var1,@var2,@var3,@var4,@var5)", con);
                cmd.Parameters.AddWithValue("@var1", textBox10.Text);
                cmd.Parameters.AddWithValue("@var2", textBox11.Text);
                cmd.Parameters.AddWithValue("@var3", textBox9.Text);
                cmd.Parameters.AddWithValue("@var4", textBox7.Text);
                cmd.Parameters.AddWithValue("@var5", textBox8.Text);
                if (textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "")
                {
                    if (IsValid(textBox9.Text) == true)
                    {
                        if (textBox11.Text == textBox12.Text)
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Contul a fost creeat cu succes!");
                            Form5 g = new Form5();
                            g.ShowDialog();
                            this.Close();
                        }
                        else
                            MessageBox.Show("Parolele nu coincid!");
                    }
                    else
                        MessageBox.Show("Forma adresei de email este incorecta!");
                }
                else
                {
                    MessageBox.Show("Pentru creerea contului e nevoie sa completati toate campurile!");
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pentru a ajunge la 'MENIU' e nevoie mai intai sa te loghezi!");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
