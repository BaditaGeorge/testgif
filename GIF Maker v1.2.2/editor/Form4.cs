using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Gif.Components;
using AForge.Video.FFMPEG;
using System.Windows.Forms;

namespace editor
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            textBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444953");
            textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#ededed");
            textBox2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444953");
            textBox2.BackColor = System.Drawing.ColorTranslator.FromHtml("#ededed");
        }

        Image originalImg, originalImg2;
        VideoFileReader reader;
        Bitmap[] vbm = new Bitmap[150000];
        Bitmap vbm2;
        int k = 0,val, j=0,i=1;
        string path;
        string den;
        int lim;
        int numberOfFrames;
        Image frames2;
        Image[] frames = new Image[150000];

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
        int limita;

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (i < frames.Length)
            {
                
                pictureBox4.Image = frames[i];
                pictureBox4.Refresh();
                i++;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if(k==0)
            {
                reader.Open(path);
            }
            k++;
            if (i < reader.FrameCount)
            {
                pictureBox4.Image = reader.ReadVideoFrame();
                pictureBox4.Refresh();
                i++;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                originalImg = Image.FromFile(op.FileName);

                numberOfFrames = originalImg.GetFrameCount(FrameDimension.Time);
                limita = numberOfFrames;
                //Image[] frames = new Image[numberOfFrames];
                for (int i = 0; i < numberOfFrames; i++)
                {
                    originalImg.SelectActiveFrame(FrameDimension.Time, i);

                    frames[i] = ((Image)originalImg.Clone());
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            reader = new VideoFileReader();
            // open video file
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                path = open.FileName;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //pictureBox4.Image = originalImg;
            if (textBox2.Text != "")
            {
                val = Convert.ToInt32(textBox2.Text);
                timer2.Interval = val;
                timer2.Enabled = true;
            }
            else
                MessageBox.Show("Nu ati introdus timpul de tranzitie!");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                val = Convert.ToInt32(textBox1.Text);
                timer1.Interval = val;
                timer1.Enabled = true;
                reader.Close();
            }
            else
                MessageBox.Show("Nu ati introdus timpul de tranzitie!");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            //Image[] frames = new Image[numberOfFrames];
            SaveFileDialog sd = new SaveFileDialog();

            if (sd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < limita; i++)
                {
                    //frames[i].Save(den + " " + i + "." + vec[lim], ImageFormat.Png);
                    //frames[i].Save(sd.FileName + i, ImageFormat.Png);
                    frames[i].Save(sd.FileName + i + ".bmp");
                }
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            SaveFileDialog sed = new SaveFileDialog();
            // read 100 video frames out of it
            if (sed.ShowDialog() == DialogResult.OK)
            {
                reader.Open(path);
                for (int i = 0; i < reader.FrameCount; i++)
                {
                    Bitmap videoFrame = reader.ReadVideoFrame();

                    videoFrame.Save(sed.FileName + i + ".bmp");

                    // dispose the frame when it is no longer required
                    videoFrame.Dispose();
                }
                reader.Close();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
