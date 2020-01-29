using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DATABASEULTIMATE
{
    public partial class DBSHOW : Form
    {

        string connectionString = @"Data Source=.;Initial Catalog=ProgTestDB;Integrated Security=True";

        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        public DBSHOW()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM INFORMATION_SCHEMA.TABLES;", sqlcon);
                sda = sqlda;
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                dataGridView1.DataSource = dt;

                label2.Text = "SELECT * FROM INFORMATION_SCHEMA.TABLES;";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM " + comboBox1.Text + " ;", sqlcon);

            sqlcon.Open();
            sqlda.SelectCommand.ExecuteNonQuery();
            dt = new DataTable();
            sqlda.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlcon.Close();
            MessageBox.Show("Info gathered from " + comboBox1.Text);

            label2.Text = "SELECT * FROM '" + comboBox1.Text + "' ;";
        }

        void fillingcombobox1()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlCommand smd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES;", sqlcon);
            SqlDataReader myReader;

            sqlcon.Open();
            myReader = smd.ExecuteReader();
            while (myReader.Read())
            {
                string sName = myReader["TABLE_NAME"].ToString();
                comboBox1.Items.Add(sName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void DBSHOW_Load(object sender, EventArgs e)
        {
            fillingcombobox1();
        }
    }
}
