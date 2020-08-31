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
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\hp\Documents\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            string Query = "SELECT * FROM product";
            SqlDataAdapter adpter = new SqlDataAdapter(Query, con);
            DataSet set = new DataSet();
            adpter.Fill(set, "product");
            dataGridView1.DataSource = set.Tables["product"];
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ba = new Form1();
            ba.Show();
            this.Close();
        }
    }
}
