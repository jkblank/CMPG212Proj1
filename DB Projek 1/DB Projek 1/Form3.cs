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

namespace DB_Projek_1
{
    public partial class Form3 : Form
    {
        //public var
        public SqlConnection conn;
        public DataSet ds;
        public SqlDataAdapter adapt;
        public string INPUT = "";
        public string cbxSelect = "";

        //Method used to connect with error detection
        public void Connect()
        {
            try
            {
                //we had an issue with the connection string hwile trying to use access database
                string connString = @"E:\CMPG212\DATABASEPROJECT1\DB PROJEK 1\DB PROJEK 1\SPECDB1.MDF";

               
                conn = new SqlConnection(connString);
                conn.Open();
                MessageBox.Show("database connected");
                conn.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        //metod used to display from database
        public void Display()
        {

           
            try
            {
                conn.Open();
                SqlCommand com;
                string sqlStatment;

                adapt = new SqlDataAdapter();
                ds = new DataSet();

                sqlStatment = @"SELECT * FROM Students ORDER BY ID";
                com = new SqlCommand(sqlStatment, conn);

                adapt.SelectCommand = com;
                adapt.Fill(ds, "Stock");

                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Stock";


                //Populate combo box
                SqlDataReader datReader = com.ExecuteReader();
                string output = "";


                conn.Close();

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        // method used to populate the combo box 
        public void PopulateFilter()
        {


            try
            {
                conn.Open();
                SqlCommand com;
                string sqlStatment;

                adapt = new SqlDataAdapter();
                ds = new DataSet();

                sqlStatment = @"SELECT * FROM Students ORDER BY ID";
                com = new SqlCommand(sqlStatment, conn);

                adapt.SelectCommand = com;
                adapt.Fill(ds, "Bman");



                //Populate combo box
                SqlDataReader datReader = com.ExecuteReader();
             
                while (datReader.Read())
                {
                    if (!cbMan.Items.Contains(datReader.GetValue(4)))
                    {
                        cbMan.Items.Add(datReader.GetValue(4));
                        cbModel.Items.Add(datReader.GetValue(4));
                        cbStock.Items.Add(datReader.GetValue(4));
                        cbYear.Items.Add(datReader.GetValue(4));
                        cbCores.Items.Add(datReader.GetValue(4));
                        cbPrice.Items.Add(datReader.GetValue(4));
                    }



                }

                conn.Close();

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }
            // method used inside combobox
            public void combobox()
            {
                
 
                cbxSelect = comboBox1.SelectedIndex.ToString();

                string sql_Course = "SELECT FirstName,LastName,StudentNo FROM Students WHERE Course LIKE'" + comboBox1.Text + "'";


                conn.Open();
                SqlCommand com;
                string sqlStatment;




                com = new SqlCommand(sql_Course, conn);
            }
        
        public Form3()
        {
            InitializeComponent();
        }

        private void tpCpu_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Connect();
        }

        private void cbMan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tpCpu_Enter(object sender, EventArgs e)
        {

        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {

        }
    }
}
