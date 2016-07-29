using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace editor
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            trackBar1.BackColor = System.Drawing.ColorTranslator.FromHtml("#444953");
        }

        Graphics g;
        Graphics image;
        Bitmap btm,b;
        Color c;
        bool drawing = false;
        Image mainimg;

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
  
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                b = new Bitmap(op.FileName);
                btm = new Bitmap(b.Width, b.Height);
                image = Graphics.FromImage(btm);
                image.DrawImage(b, new Rectangle(0, 0, panel1.Width, panel1.Height));
                g.DrawImage(btm, Point.Empty);
                panel1.BackgroundImage = btm;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            c = cd.Color;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            int w = panel1.Width;
            int h = panel1.Height;
            /*
           Bitmap bm = new Bitmap(w, h);
           panel1.DrawToBitmap(bm, new Rectangle(0, 0, w, h));*/
            Bitmap imen = new Bitmap(w, h);
            SaveFileDialog sdf = new SaveFileDialog();
            sdf.Filter = "JPEG|*.JPG|PNG|*.PNG|GIF|*.GIF|BMP|*.BMP|All files (*.*)|*.*";
            using (Bitmap bmp = new Bitmap(w, h))
            {
                panel1.DrawToBitmap(bmp, new Rectangle(0, 0, w, h));
                if (DialogResult.OK == sdf.ShowDialog())
                    bmp.Save(sdf.FileName, ImageFormat.Jpeg);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                Rectangle mouseRect = new Rectangle(e.X - (trackBar1.Value / 2), e.Y - (trackBar1.Value / 2), (trackBar1.Value), (trackBar1.Value));
                image.FillRectangle(new SolidBrush(c), mouseRect);
                g.DrawImage(btm, Point.Empty);
            }
        }

        private void panel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            drawing = true;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
