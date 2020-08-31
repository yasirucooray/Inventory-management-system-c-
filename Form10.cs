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
    public partial class Form10 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\hp\Documents\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
        public Form10()
        {
            InitializeComponent();
           
        }
        private void DisplayData()
        {
            
            SqlDataAdapter adt = new SqlDataAdapter();
            con.Open();
            DataTable dt = new DataTable();
            adt = new SqlDataAdapter("select * from supplier", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }  
        private void button2_Click(object sender, EventArgs e)
        {
            
            string que = " delete from returnitems where itemno='" + textBox1.Text + "';";
            SqlCommand cmd = new SqlCommand(que, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("delete successfully");
            DisplayData();
            textBox1.Clear();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 ba = new Form1();
            ba.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                 Form2 ss = new Form2();
                 ss.Show();
                 this.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryDataSet4.returnitems' table. You can move, or remove it, as needed.
            this.returnitemsTableAdapter.Fill(this.inventoryDataSet4.returnitems);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_damage aa = new add_damage();
            aa.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Fill Required Fields");

            }
            else
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from returnitems where itemno like " + textBox2.Text, con);
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                
            }textBox1.Clear();
        }
     
    }
}
