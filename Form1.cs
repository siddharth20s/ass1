using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SampleProductWindows
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("data source=DESKTOP-PUH88GC;database=kanini2;integrated security=sspi;");

            con.Open();
            int id = Convert.ToInt32(TxtPID.Text);
            string name = TxtPName.Text;
            double price = Convert.ToDouble(TxtPrice.Text);
            int stock = Convert.ToInt32(TxtStock.Text);
            string desc = TxtDesc.Text;
            string category = TxtCategory.Text;
            cmd = new SqlCommand("insert into Product values('" + id + "','" + name + "','" + price + "','" + stock + "','" + desc + "','" + category + "') ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Product inserted successfully");
            con.Close();
        }

        private void BtnFetch_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("data source=DESKTOP-PUH88GC;database=kanini2;integrated security=sspi;");

            con.Open();
            cmd = new SqlCommand("Select * from Product", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("data source=DESKTOP-PUH88GC;database=kanini2;integrated security=sspi;");

            con.Open();
            cmd = new SqlCommand("Select * from Product", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        //Update
        private void BtnUpdate_Click(object sender, EventArgs e)
        {

            con = new SqlConnection("data source=DESKTOP-PUH88GC;database=kanini2;integrated security=sspi;");

            con.Open();
            int id = Convert.ToInt32(TxtPID.Text);
            string name = TxtPName.Text;
            double price = Convert.ToDouble(TxtPrice.Text);
            int stock = Convert.ToInt32(TxtStock.Text);
            string desc = TxtDesc.Text;
            cmd = new SqlCommand("update Product set product_name='" + name + "',product_price='" + price + "',product_stock='" + stock + "',product_desc='" + desc + "' where product_id='" + id + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show($"Product ID: {id} is updated");
        }

        //Search
        private void BtnSearch_Click(object sender, EventArgs e)
        {

            con = new SqlConnection("data source=DESKTOP-PUH88GC;database=kanini2;integrated security=sspi;");

            con.Open();
            int id = Convert.ToInt32(TxtPID.Text);
            cmd = new SqlCommand("Select * from Product where product_id='" + id + "' ", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        //Delete
        private void BtnDelete_Click(object sender, EventArgs e)
        {

            con = new SqlConnection("data source=DESKTOP-PUH88GC;database=kanini2;integrated security=sspi;");

            con.Open();
            int id = Convert.ToInt32(TxtEID.Text);

            cmd = new SqlCommand("select * from Product where product_id='" + id + "'", con);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                sdr.Close();
                cmd = new SqlCommand("select * from Product where product_id='" + id + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show($"Employee ID: {id} deleted successfully");
            }
            else
            {
                MessageBox.Show($"Employee with ID: {id} does not exist");
            }
            con.Close();
        }
    }
}
