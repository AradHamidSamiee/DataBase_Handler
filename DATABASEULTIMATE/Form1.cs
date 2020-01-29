using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

namespace DATABASEULTIMATE
{
    public partial class Form1 : Form
    {

        string connectionString = @"Data Source=.;Initial Catalog=ProgTestDB;Integrated Security=True";

        int activenew = 0;
        int activeinsert = 0;
        int activeupdate = 0;

        int activedrop = 0; //drop
        int activepanel6 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            if (activenew == 0)
            {
                panelnew.Visible = true;
                activenew++;
            }
            else
            {
                panelnew.Visible = false;
                activenew--;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btncreatetable_Click(object sender, EventArgs e)
        {
            
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlDataAdapter sqlda = new SqlDataAdapter("CREATE TABLE " + textBox1.Text + "(nid int);", sqlcon);/*
            SqlCommand cmd = new SqlCommand("CREATE TABLE '" + textBox1.Text + "'(nid int);", sqlcon);*/

            sqlcon.Open();
            sqlda.SelectCommand.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("New Table Created!");

            
            /*
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            */

            label3.Text = textBox1.Text;
            labelquery.Text = "CREATE TABLE " + textBox1.Text + " (id int);";
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            DBSHOW form2 = new DBSHOW();
            form2.ShowDialog();
        }

        /*
        private void btnedit_Click(object sender, EventArgs e)
        {
            if (activedit == 0)
            {
                paneledit.Visible = true;
                activedit++;
            }
            else
            {
                paneledit.Visible = false;
                activedit--;
            }
        }
        */

        private void btninsert_Click(object sender, EventArgs e)
        {
            if (activeinsert == 0)
            {
                panelinsert.Visible = true;
                activeinsert++;
            }
            else
            {
                panelinsert.Visible = false;
                activeinsert--;
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (activeupdate == 0)
            {
                panelupdate.Visible = true;
                activeupdate++;
            }
            else
            {
                panelupdate.Visible = false;
                activeupdate--;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }

        private void btnkey_Click(object sender, EventArgs e)
        {

        }

        private void btndomain_Click(object sender, EventArgs e)
        {

        }

        private void btntest_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillingcombobox4();
            fillingcombobox2();
            fillingcombobox3();
            fillingcombobox7();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnaddfield_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlDataAdapter sqlda = new SqlDataAdapter("ALTER TABLE " + textBox1.Text + " ADD " + textBox2.Text + " " + comboBox1.Text + ";", sqlcon);

            sqlcon.Open();
            sqlda.SelectCommand.ExecuteNonQuery();
            sqlcon.Close();

            MessageBox.Show("New Field Added To Current Table");
            labelquery.Text = "ALTER TABLE " + label3.Text + " ADD" + textBox2.Text + " " + comboBox1.Text + ";";
        }

        void fillingcombobox4()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlCommand smd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES;", sqlcon);
            SqlDataReader myReader;

            sqlcon.Open();
            myReader = smd.ExecuteReader();
            while (myReader.Read())
            {
                string sName = myReader["TABLE_NAME"].ToString();
                comboBox4.Items.Add(sName);
            }
        }

        void fillingcombobox2()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlCommand smd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES;", sqlcon);
            SqlDataReader myReader;

            sqlcon.Open();
            myReader = smd.ExecuteReader();
            while (myReader.Read())
            {
                string sName = myReader["TABLE_NAME"].ToString();
                comboBox2.Items.Add(sName);
            }
        }

        void fillingcombobox3()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlCommand smd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES;", sqlcon);
            SqlDataReader myReader;

            sqlcon.Open();
            myReader = smd.ExecuteReader();
            while (myReader.Read())
            {
                string sName = myReader["TABLE_NAME"].ToString();
                comboBox3.Items.Add(sName);
            }
        }

        void fillingcombobox7()
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlCommand smd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES;", sqlcon);
            SqlDataReader myReader;

            sqlcon.Open();
            myReader = smd.ExecuteReader();
            while (myReader.Read())
            {
                string sName = myReader["TABLE_NAME"].ToString();
                comboBox7.Items.Add(sName);
            }
        }

        private void panelinsert_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
//          MessageBox.Show(comboBox4.Text);
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlDataAdapter sqlda = new SqlDataAdapter("INSERT INTO " + comboBox4.Text + " VALUES('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox6.Text + "');", sqlcon);

            sqlcon.Open();
            sqlda.SelectCommand.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("New Info Inserted!");

            labelquery.Text = "INSERT INTO " + comboBox4.Text + " VALUES('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox6.Text + "');";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlDataAdapter sqlda = new SqlDataAdapter("UPDATE " + comboBox2.Text + " SET " + textBox7.Text + " = '" + textBox14.Text + "' WHERE " + textBox10.Text + " = '" + textBox9.Text + "';", sqlcon);

            sqlcon.Open();
            sqlda.SelectCommand.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("New Info Inserted!");

            labelquery.Text = "UPDATE " + comboBox2.Text + " SET '" + textBox7.Text + "' = '" + textBox14.Text + "' WHERE '" + textBox10 + "' = '" + textBox9.Text + "';";

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndrop_Click(object sender, EventArgs e)
        {
            if (activedrop == 0)
            {
                panel4.Visible = true;
                panel5.Visible = true;
                activedrop++;
            } else
            {
                panel4.Visible = false;
                panel5.Visible = false;
                activedrop--;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlDataAdapter sqlda = new SqlDataAdapter("DROP TABLE " + comboBox3.Text + ";", sqlcon);
            
            sqlcon.Open();
            sqlda.SelectCommand.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("Table :" + comboBox3 + " Droped!");

            labelquery.Text = "DROP TABLE " + comboBox3 + "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            SqlDataAdapter sqlda = new SqlDataAdapter("ALTER TABLE " + comboBox7.Text + " DROP COLUMN " + textBox15.Text + ";", sqlcon);

            sqlcon.Open();
            sqlda.SelectCommand.ExecuteNonQuery();
            sqlcon.Close();

            labelquery.Text = "ALTER TABLE " + comboBox7.Text + " DROP COLUMN " + textBox15.Text + ";";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
