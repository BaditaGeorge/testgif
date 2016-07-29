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
    public partial class Collage : Form
    {
        public Collage()
        {
            InitializeComponent();
        }
        int t = 0;
        Image[] vec = new Image[100];
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = true;
            op.ShowDialog();
            foreach (string file in op.FileNames)
            {
                t++;
                vec[t] = Image.FromFile(file);
            }
        }
        Image back;
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opi = new OpenFileDialog();
            opi.ShowDialog();
            back = Image.FromFile(opi.FileName);
            pictureBox1.Image = back;
        }

        private void Collage_Load(object sender, EventArgs e)
        {

        }
        int x = 1, y = 1,h,w;
        int k = 0, k1 = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            h=back.Height;
            w=back.Width;
            Graphics g = Graphics.FromImage(back);
            /*for (int i = 1; i <= t; i++)
            {
                k++;
                g.DrawImage(vec[i], new Rectangle(x, y, 200, 200));
                y = y + 220;
                if (k == 3)
                {
                    x = 1000;
                    y = 1;
                }
            }*/
            int ok = 0;
            for (int i = 1; i <= t; i++)
            {
                k++;
                g.DrawImage(vec[i], new Rectangle(x, y, 200, 200));
                if (ok == 0)
                {
                    x = x + 250;
                    y = y + 250;
                }
                else
                {
                    x = x - 250;
                    y = y + 250;
                }
                if (k == 3)
                {
                    x = 1000;
                    y = 1;
                    ok = 1;
                }
            }
            pictureBox1.Image = back;
        }
        Image simg;
        private void button4_Click(object sender, EventArgs e)
        {
            simg = pictureBox1.Image;
            SaveFileDialog sev = new SaveFileDialog();
            sev.Filter = "JPEG|*.JPG|PNG|*.PNG|GIF|*.GIF|BMP|*.BMP|All files (*.*)|*.*";
            if(sev.ShowDialog()==DialogResult.OK)
            simg.Save(sev.FileName);
        }
    }
}
