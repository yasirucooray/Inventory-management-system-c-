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
    public partial class Form8 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\hp\Documents\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
        public Form8()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Fill Required Fields");

            }
            else
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from categories where uniqueno like " + textBox1.Text, con);
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            textBox1.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryDataSet3.categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.inventoryDataSet3.categories);
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 f8 = new Form11();
            f8.Show();
            this.Close();
        }

        private void DisplayData()
        {
            
            SqlDataAdapter adt = new SqlDataAdapter();
            con.Open();
            DataTable dt = new DataTable();
            adt = new SqlDataAdapter("select * from categories", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }  
      
        private void button5_Click(object sender, EventArgs e)
        {
            
            string que = " delete from categories where uniqueno='" + textBox2.Text + "';";
            SqlCommand cmd = new SqlCommand(que, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("delete successfully");
            DisplayData();
            textBox2.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        
            Form2 f22 = new Form2();
            f22.Show();
            this.Close();
        }
    }
}
