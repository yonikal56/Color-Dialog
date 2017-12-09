using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace colorDialog
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string clipboard_text = textBox1.Text;
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
                Color color = Color.FromArgb(r, g, b);
                textBox2.Text = color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
                this.Size = new Size(300, 160);
            }
            else
            {
                MessageBox.Show("You have invalid rgb in your clipboard.");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.MinimumSize = Size;
        }
    }
}
