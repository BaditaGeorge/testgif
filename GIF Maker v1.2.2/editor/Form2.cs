using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace editor
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        Image bm1, bm2;
        Bitmap bim, bim2;
        Image ImgGl, ImGl2;
        Image imeg;
        Image imi1, imi2, imi3, imi4, imi5;
        static Image ImUndo;
        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox3.Text = "Selecteaza marimea de scalare";
            comboBox2.Text = "Selecteaza un filtru";
            //comboBox2.Text = comboBox2.Items[0].ToString();
            bm1 = pictureBox2.Image;
            numericUpDown1.Maximum = 5;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.ShowDialog();
        }

        double zoomFactor = 1.0;
        Image imeg2;

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                ImgGl = Image.FromFile(op.FileName);
                ImGl2 = Image.FromFile(op.FileName);
                pictureBox2.Image = Image.FromFile(op.FileName);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            bm2 = pictureBox2.Image;
            bm2.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox2.Image = bm2;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            bm2 = pictureBox2.Image;
            bm2.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox2.Image = bm2;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            imi1 = pictureBox2.Image;
            ImUndo = imi1;
            Bitmap originalImage = (Bitmap)pictureBox2.Image;
            Bitmap adjustedImage = (Bitmap)pictureBox2.Image;
            float brightness = 1.0f; // no change in brightness
            float contrast = Convert.ToSingle(numericUpDown1.Value); // twice the contrast
            float gamma = 1.0f; // no change in gamma

            float adjustedBrightness = brightness - 1.0f;
            // create matrix that will brighten and contrast the image
            float[][] ptsArray ={
            new float[] {contrast, 0, 0, 0, 0}, // scale red
            new float[] {0, contrast, 0, 0, 0}, // scale green
            new float[] {0, 0, contrast, 0, 0}, // scale blue
            new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
            new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};
            System.Drawing.Imaging.ImageAttributes imageAttributes = new System.Drawing.Imaging.ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            Graphics g = Graphics.FromImage(adjustedImage);
            g.DrawImage(originalImage, new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height)
                , 0, 0, originalImage.Width, originalImage.Height,
                GraphicsUnit.Pixel, imageAttributes);
            pictureBox2.Image = adjustedImage;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            ImUndo = pictureBox2.Image;
            if (comboBox2.SelectedIndex == 0)
            {
                bim = (Bitmap)pictureBox2.Image;
                pictureBox2.Image = (Image)MakeGrayscale3(bim);
            }
            else
                if (comboBox2.SelectedIndex == 1)
            {
                float[][] sepiaValues ={
                                      new float[]{.393f, .349f, .272f, 0, 0},
            new float[]{.769f, .686f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                    if (comboBox2.SelectedIndex == 2)
            {
                float[][] sepiaValues ={
                                      new float[]{.193f, .249f, .162f, 0, 0},
            new float[]{.259f, .210f, .334f, 0, 0},
            new float[]{.149f, .451f, .731f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                        if (comboBox2.SelectedIndex == 3)
            {
                float[][] sepiaValues ={
                                      new float[]{.193f, .249f, .162f, 0, 0},
            new float[]{.259f, .210f, .334f, 0, 0},
            new float[]{.149f, .451f, .731f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                            if (comboBox2.SelectedIndex == 4)
            {
                float[][] sepiaValues ={
                                      new float[]{.193f, .249f, .162f, 0, 0},
            new float[]{.859f, .510f, .334f, 0, 0},
            new float[]{.349f, .851f, .431f, 0, 0},
            new float[]{1, 0, 0, 0, 0},
            new float[]{0, 1, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                if (comboBox2.SelectedIndex == 5)
            {
                float[][] sepiaValues ={
                                      new float[]{.293f, .549f, .172f, 0, 0},
            new float[]{.319f, .246f, .134f, 0, 0},
            new float[]{.489f, .568f, .431f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                    if (comboBox2.SelectedIndex == 6)
            {
                float[][] sepiaValues ={
                                      new float[]{.1093f, .949f, .872f, 0, 0},
            new float[]{.109f, .186f, .134f, 0, 0},
            new float[]{.249f, .668f, .731f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                        if (comboBox2.SelectedIndex == 7)
            {
                float[][] sepiaValues ={
                                      new float[]{.13f, .19f, .22f, 0, 0},
            new float[]{.939f, .146f, .594f, 0, 0},
            new float[]{.249f, .598f, .51f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                            if (comboBox2.SelectedIndex == 8)
            {
                float[][] sepiaValues ={
                                      new float[]{.213f, .419f, .22f, 0, 0},
            new float[]{.439f, .946f, .594f, 0, 0},
            new float[]{.49f, .998f, .51f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                                if (comboBox2.SelectedIndex == 9)
            {
                float[][] sepiaValues ={
                                      new float[]{.893f, .759f, .773f, 0, 0},
            new float[]{.169f, .186f, .134f, 0, 0},
            new float[]{.189f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                                    if (comboBox2.SelectedIndex == 10)
            {
                float[][] sepiaValues ={
                                      new float[]{.193f, .859f, .273f, 0, 0},
            new float[]{.469f, .186f, .434f, 0, 0},
            new float[]{.589f, .568f, .431f, 0, 0},
            new float[]{1, 0, 0, 2, 0},
            new float[]{0, 0, 0, 0, 4}};
                System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
                System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
                IA.SetColorMatrix(sepiaMatrix);
                Bitmap sepiaEffect = (Bitmap)pictureBox2.Image.Clone();
                using (Graphics g = Graphics.FromImage(sepiaEffect))
                {
                    g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
                }
                pictureBox2.Image = sepiaEffect;
            }
            else
                                                        if (comboBox2.SelectedIndex == 11)
            {
                Image imeji = pictureBox2.Image;
                pictureBox2.Image = InvertImageColorMatrix(imeji);
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            ImUndo = pictureBox2.Image;
            imeg = pictureBox2.Image;
            if (comboBox3.SelectedIndex == 0)
            {
                zoomFactor = 0.5;
                Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.Image = (Image)bimi1;
            }
            else
                if (comboBox3.SelectedIndex == 1)
            {
                zoomFactor = 1.0;
                Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.Image = (Image)bimi1;
            }
            else
                    if (comboBox3.SelectedIndex == 2)
            {
                zoomFactor = 1.5;
                Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.Image = (Image)bimi1;
            }
            else
                        if (comboBox3.SelectedIndex == 3)
            {
                zoomFactor = 2.0;
                Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.Image = (Image)bimi1;
            }
            else
                            if (comboBox3.SelectedIndex == 4)
            {
                zoomFactor = 2.5;
                Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.Image = (Image)bimi1;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "")
            {
                ImUndo = pictureBox2.Image;
                Bitmap btm1 = (Bitmap)pictureBox2.Image;
                Rectangle section = new Rectangle(new Point(Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text)), new Size(Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox10.Text)));
                pictureBox2.Image = CropImage(btm1, section);
            }
            else
                MessageBox.Show("Campurile ce seteaza dimensiunile si pozitia sunt obligatorii!");
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            imeg = pictureBox2.Image;
            SaveFileDialog sdf = new SaveFileDialog();
            sdf.Filter = "JPEG|*.JPG|PNG|*.PNG|GIF|*.GIF|BMP|*.BMP|All files (*.*)|*.*";
            if (DialogResult.OK == sdf.ShowDialog())
            {
                imeg.Save(sdf.FileName, ImageFormat.Bmp);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ImUndo = pictureBox2.Image;
            imeg = pictureBox2.Image;
            if (comboBox3.SelectedIndex == 0)
            {
                zoomFactor = 0.5;
                Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.Image = (Image)bimi1;
            }
            else
                if (comboBox3.SelectedIndex == 1)
                {
                    zoomFactor = 1.0;
                    Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                    Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                    pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                    pictureBox2.Image = (Image)bimi1;
                }
                else
                    if (comboBox3.SelectedIndex == 2)
                    {
                        zoomFactor = 1.5;
                        Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                        Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                        pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                        pictureBox2.Image = (Image)bimi1;
                    }
                    else
                        if (comboBox3.SelectedIndex == 3)
                        {
                            zoomFactor = 2.0;
                            Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                            Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                            pictureBox2.Image = (Image)bimi1;
                        }
                        else
                            if (comboBox3.SelectedIndex == 4)
                            {
                                zoomFactor = 2.5;
                                Size newSize = new Size((int)(imeg.Width * zoomFactor), (int)(imeg.Height * zoomFactor));
                                Bitmap bimi1 = new Bitmap((Bitmap)imeg, newSize);
                                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                                pictureBox2.Image = (Image)bimi1;
                            }
        }

        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
      {
         new float[] {.3f, .3f, .3f, 0, 0},
         new float[] {.59f, .59f, .59f, 0, 0},
         new float[] {.11f, .11f, .11f, 0, 0},
         new float[] {0, 0, 0, 1, 0},
         new float[] {0, 0, 0, 0, 1}
      });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }
        private static Image InvertImageColorMatrix(Image originalImg)
        {
            Bitmap invertedBmp = new Bitmap(originalImg.Width, originalImg.Height);

            //Setup color matrix
            ColorMatrix clrMatrix = new ColorMatrix(new float[][]
                                                    {
                                                    new float[] {-1, 0, 0, 0, 0},
                                                    new float[] {0, -1, 0, 0, 0},
                                                    new float[] {0, 0, -1, 0, 0},
                                                    new float[] {0, 0, 0, 1, 0},
                                                    new float[] {1, 1, 1, 0, 1}
                                                    });

            using (ImageAttributes attr = new ImageAttributes())
            {
                //Attach matrix to image attributes
                attr.SetColorMatrix(clrMatrix);

                using (Graphics g = Graphics.FromImage(invertedBmp))
                {
                    g.DrawImage(originalImg, new Rectangle(0, 0, originalImg.Width, originalImg.Height),
                                0, 0, originalImg.Width, originalImg.Height, GraphicsUnit.Pixel, attr);
                }
            }

            return invertedBmp;
        }

        public Bitmap CropImage(Bitmap source, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }
    }
}