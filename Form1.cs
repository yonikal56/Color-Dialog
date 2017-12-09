using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace colorDialog
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Bitmap bmp2;
        Bitmap bmp3;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pictureBox2.BackColor = bmp.GetPixel(e.X, e.Y);
                }
            }
            catch
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Image);
            bmp2 = new Bitmap(pictureBox3.Image);
            bmp3 = new Bitmap(pictureBox5.Image);
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(pictureBox2.BackColor.R + ", " + pictureBox2.BackColor.G + ", " + pictureBox2.BackColor.B);
            MessageBox.Show("The RGB of the selected color copied to your clipboard.");
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pictureBox2.BackColor = bmp.GetPixel(e.X, e.Y);
                }
            }
            catch
            {

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(Convert.ToInt16(numericUpDown1.Value), Convert.ToInt16(numericUpDown2.Value), Convert.ToInt16(numericUpDown3.Value));
        }

        private void pictureBox2_BackColorChanged(object sender, EventArgs e)
        {
            trackBar1.Value = pictureBox2.BackColor.R;
            trackBar2.Value = pictureBox2.BackColor.G;
            trackBar3.Value = pictureBox2.BackColor.B;
            numericUpDown1.Value = pictureBox2.BackColor.R;
            numericUpDown2.Value = pictureBox2.BackColor.G;
            numericUpDown3.Value = pictureBox2.BackColor.B;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string clipboard_text = Clipboard.GetText();
            clipboard_text = clipboard_text.Replace(" ", "");
            Match match = Regex.Match(clipboard_text, @"([0-9]{1,3}),\s?([0-9]{1,3}),\s?([0-9]{1,3})", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                int r = Convert.ToInt32(match.Groups[1].Value.ToString());
                int g = Convert.ToInt32(match.Groups[2].Value.ToString());
                int b = Convert.ToInt32(match.Groups[3].Value.ToString());
                if (r >= 255)
                {
                    r = 255;
                }
                if (g >= 255)
                {
                    g = 255;
                }
                if (b >= 255)
                {
                    b = 255;
                }
                trackBar1.Value = Convert.ToInt32(r);
                trackBar2.Value = Convert.ToInt32(g);
                trackBar3.Value = Convert.ToInt32(b);
                numericUpDown1.Value = Convert.ToDecimal(r);
                numericUpDown2.Value = Convert.ToDecimal(g);
                numericUpDown3.Value = Convert.ToDecimal(b);
            }
            else
            {
                MessageBox.Show("You have invalid rgb in your clipboard.");
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pictureBox4.BackColor = bmp.GetPixel(e.X, e.Y);
                }
            }
            catch
            {

            }
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pictureBox4.BackColor = bmp2.GetPixel(e.X, e.Y);
                }
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(pictureBox4.BackColor.R.ToString("X2") + pictureBox4.BackColor.G.ToString("X2") + pictureBox4.BackColor.B.ToString("X2"));
            MessageBox.Show("The HEX of the selected color copied to your clipboard.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string clipboard_text = Clipboard.GetText();
            Match match = Regex.Match(clipboard_text, @"^0x(?:[0-9A-Fa-f]{2})+$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                MessageBox.Show("Valid hex.");
            }
            else
            {
                MessageBox.Show("You have invalid hex in your clipboard.");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string clipboard_text = Clipboard.GetText();
            clipboard_text = clipboard_text.Replace(" ", "");
            Match match = Regex.Match(clipboard_text, @"([0-9]{1,3}),\s?([0-9]{1,3}),\s?([0-9]{1,3})", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                int r = Convert.ToInt32(match.Groups[1].Value.ToString());
                int g = Convert.ToInt32(match.Groups[2].Value.ToString());
                int b = Convert.ToInt32(match.Groups[3].Value.ToString());
                if (r >= 255)
                {
                    r = 255;
                }
                if (g >= 255)
                {
                    g = 255;
                }
                if (b >= 255)
                {
                    b = 255;
                }
                pictureBox4.BackColor = Color.FromArgb(r, g, b);
            }
            else
            {
                MessageBox.Show("You have invalid rgb in your clipboard.");
            }
        }

        private void rgbToHexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 from = new Form2();
            from.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                tabControl1.SelectedIndex = 0;
                Form2 form = new Form2();
                form.Show();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                tabControl1.SelectedIndex = 0;
                Form3 form = new Form3();
                form.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string clipboard_text = Clipboard.GetText();
            Match match = Regex.Match(clipboard_text, @"(([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                Color color = ColorTranslator.FromHtml("#" + match.Groups[1].Value);
                pictureBox4.BackColor = Color.FromArgb(color.R, color.G, color.B);
            }
            else
            {
                MessageBox.Show("You have invalid hex in your clipboard.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ope = new OpenFileDialog();
            ope.Filter = "png|*.png|jpg|*.jpg|bmp|*.bmp|gif|*.gif";
            if (ope.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox5.Load(ope.FileName);
                pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                bmp3 = new Bitmap(pictureBox5.Width, pictureBox5.Height);
                using (var g = Graphics.FromImage(bmp3))
                {
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.DrawImage(pictureBox5.Image, new Rectangle(Point.Empty, bmp3.Size));
                    pictureBox5.Image = bmp3;
                }
            }
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pictureBox6.BackColor = bmp.GetPixel(e.X, e.Y);
                }
            }
            catch
            {

            }
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pictureBox6.BackColor = bmp3.GetPixel(e.X, e.Y);
                }
            }
            catch
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(pictureBox6.BackColor.R + ", " + pictureBox6.BackColor.G + ", " + pictureBox6.BackColor.B);
            MessageBox.Show("The RGB of the selected color copied to your clipboard.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(pictureBox6.BackColor.R.ToString("X2") + pictureBox6.BackColor.G.ToString("X2") + pictureBox6.BackColor.B.ToString("X2"));
            MessageBox.Show("The HEX of the selected color copied to your clipboard.");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string clipboard_text = textBox1.Text;
            clipboard_text = clipboard_text.Replace(" ", "");
            Match match = Regex.Match(clipboard_text, @"([0-9]{1,3}),\s?([0-9]{1,3}),\s?([0-9]{1,3})", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                string clipboard_text2 = textBox2.Text;
                clipboard_text2 = clipboard_text2.Replace(" ", "");
                Match match2 = Regex.Match(clipboard_text2, @"([0-9]{1,3}),\s?([0-9]{1,3}),\s?([0-9]{1,3})", RegexOptions.IgnoreCase);
                if (match2.Success)
                {
                    richTextBox1.Text = "background: -webkit-linear-gradient(rgba(" + clipboard_text + ",1) ,rgba(" + clipboard_text2 + ",1));\nbackground: -o-linear-gradient(rgba(" + clipboard_text + ",1) ,rgba(" + clipboard_text2 + ",1));\nbackground: -moz-linear-gradient(rgba(" + clipboard_text + ",1) ,rgba(" + clipboard_text2 + ",1));\nbackground: linear-gradient(rgba(" + clipboard_text + ",1) ,rgba(" + clipboard_text2 + ",1));";
                }
                else
                {
                    MessageBox.Show("You have invalid rgb in your seoond rgb.");
                }
            }
            else
            {
                MessageBox.Show("You have invalid rgb in your first rgb.");
            }
        }
    }
}