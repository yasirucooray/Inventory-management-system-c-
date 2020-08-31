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
    public partial class Form11 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\hp\Documents\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string Qry = "insert into categories (uniqueno,categoriename,quntity,handonquntity,lessquntity,description) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox5.Text + "') ";

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
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string query = "update categories set uniqueno='" + textBox1.Text.Trim() + "', categoriename='" + textBox2.Text.Trim() + "',quntity='" + textBox3.Text.Trim() + "',handonquntity='" + textBox6.Text.Trim() + "',lessquntity='" + textBox7.Text.Trim() + "',description='" + textBox5.Text.Trim() + "' Where uniqueno='" + textBox1.Text.Trim() + "'; ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("success");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 ba = new Form8();
            ba.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            Form2 f22 = new Form2();
            f22.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 ba = new Form8();
            ba.Show();
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                textBox3.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                textBox6.Focus();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                textBox7.Focus();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                textBox5.Focus();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
