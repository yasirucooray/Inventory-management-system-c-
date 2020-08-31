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
using System.IO;

namespace WindowsFormsApplication10
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\hp\Documents\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
        string imglocation = "";
        SqlCommand cmd;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dio = new OpenFileDialog();
            dio.Filter = "png fils(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if(dio.ShowDialog()==DialogResult.OK)
            {
                imglocation = dio.FileName.ToString();
                pictureBox2.ImageLocation = imglocation;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Byte[] images = null;
            FileStream Streem = new FileStream(imglocation,FileMode.Open,FileAccess.Read);
            BinaryReader brs = new BinaryReader(Streem);
            images = brs.ReadBytes((int)Streem.Length);

            con.Open();
            string SqlQuery = "Insert into report(pictureno,picturedet,image)Values('" + textBox2.Text + "','" + textBox1.Text + "',@images)";
            cmd=new SqlCommand(SqlQuery,con);
            cmd.Parameters.Add(new SqlParameter("@images", images));
            int N = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("sucessed");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 bb = new Form2();
            bb.Show();
            this.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 lo = new Form1();
            lo.Show();
            this.Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form14_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryDataSet5.report' table. You can move, or remove it, as needed.
            this.reportTableAdapter.Fill(this.inventoryDataSet5.report);

        }
    }
}
