using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SERHATCELL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbConnection bag = new OleDbConnection
            ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=serhatgulcell.accdb");
            OleDbDataAdapter kur = new OleDbDataAdapter("select DISTINCT marka from cep", bag);
            DataSet hamal = new DataSet();
            kur.Fill(hamal);
            for (int i = 0; i < hamal.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(hamal.Tables[0].Rows[i].ItemArray[0].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection bag = new OleDbConnection
            ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=serhatgulcell.accdb");
            OleDbDataAdapter kur = new OleDbDataAdapter("select model from cep where marka='" +comboBox1.Text+ "'", bag);
            DataSet hamal = new DataSet();
            kur.Fill(hamal);

            comboBox2.Items.Clear();
            comboBox2.Text = "";
            textBox1.Clear();
            for (int i = 0; i < hamal.Tables[0].Rows.Count; i++)
            {
                comboBox2.Items.Add(hamal.Tables[0].Rows[i].ItemArray[0].ToString());
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection bag = new OleDbConnection
            ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=serhatgulcell.accdb");
            OleDbDataAdapter kur = new OleDbDataAdapter("select fiyat from cep where marka='" + comboBox1.Text + "' and model='" + comboBox2.Text +  "'",bag);
            DataSet hamal = new DataSet();
            kur.Fill(hamal);

            textBox1.Text = hamal.Tables[0].Rows[0].ItemArray[0].ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = (int.Parse(textBox1.Text) * int.Parse(textBox2.Text)).ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();

            frm2.textBox1.Text = comboBox1.Text +" "+ comboBox2.Text;
            frm2.textBox2.Text = textBox3.Text;

        }
    }
}
