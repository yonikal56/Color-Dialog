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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string clipboard_text = textBox1.Text;
            Match match = Regex.Match(clipboard_text, @"(([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                Color color = ColorTranslator.FromHtml("#" + match.Groups[1].Value);
                textBox2.Text = color.R + ", " + color.G + ", " + color.B;
                this.Size = new Size(300, 160);
            }
            else
            {
                MessageBox.Show("You have invalid hex in your clipboard.");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.MinimumSize = Size;
        }
    }
}
