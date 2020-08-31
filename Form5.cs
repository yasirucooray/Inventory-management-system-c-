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
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\hp\Documents\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
        public Form5()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Close();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
           
            Form6 f11 = new Form6();
            f11.Show();
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryDataSet2.product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.inventoryDataSet2.product);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            Form2 f22 = new Form2();
            f22.Show();
            this.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Fill Required Fields");

            }
            else
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from product where productid like " + textBox1.Text, con);
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        private void DisplayData()
        {
            
            SqlDataAdapter adt = new SqlDataAdapter();
            con.Open();
            DataTable dt = new DataTable();
            adt = new SqlDataAdapter("select * from product", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }  
      

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            string que = " delete from product where productid='" + textBox2.Text + "';";
            SqlCommand cmd = new SqlCommand(que, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("delete successfully");
            DisplayData();
            textBox2.Clear();
        }
   
    }
}
