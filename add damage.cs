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
    public partial class add_damage : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\hp\Documents\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
   
        public add_damage()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            string Qry = "insert into returnitems (itemno,productid,employeename,description) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "') ";

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
            textBox5.Clear();
            textBox2.Clear();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string query = "update returnitems set itemno='" + textBox1.Text.Trim() + "',productid='" + textBox2.Text.Trim() + "',employeename='" + textBox3.Text.Trim() + "',description='" + textBox5.Text.Trim() +  "'Where itemno='" + textBox1.Text.Trim() + "'; ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("success");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           
            textBox5.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 ba = new Form10();
            ba.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 ba = new Form1();
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
                textBox5.Focus();
                    }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                textBox5.Focus();
        }
    }
}
