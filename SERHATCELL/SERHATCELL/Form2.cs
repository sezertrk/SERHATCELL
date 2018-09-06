using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SERHATCELL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox2.Text = (int.Parse(textBox2.Text) + 50).ToString();
            }
            else if (radioButton1.Checked == false)
            {
                textBox2.Text = (int.Parse(textBox2.Text) - 50).ToString();
            }
        }
    }
}
