using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication10
{
   
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\hp\Documents\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
        
        public Form6()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string query = "update product set Productid='" + textBox1.Text.Trim() + "', Uniqueno='" + comboBox1.Text.Trim() + "',productname='" + textBox3.Text.Trim() + "',quntity='" + textBox4.Text.Trim() + "',price='" + textBox5.Text.Trim() + "',warentyperiode='" + textBox6.Text.Trim() + "',condition='"+ textBox2.Text.Trim()+"'Where Productid='" + textBox1.Text.Trim() + "'; ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("success");
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 ba = new Form5();
            ba.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string Qry = "insert into product (productid,Uniqueno,productname,quntity,price,warentyperiode,condition) values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox2.Text + "') ";

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Fill Required Fields");

            }

            else
            {

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Qry, con);
                    int affectedRows = cmd.ExecuteNonQuery();
                    MessageBox.Show(affectedRows + " rows inserted!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    
                }
                con.Close();
            }
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox2.Clear();

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 ba = new Form5();
            ba.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Form2 f22 = new Form2();
            f22.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                textBox3.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                textBox4.Focus();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                textBox5.Focus();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                textBox6.Focus();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                textBox2.Focus();
        }

        
    }
}
