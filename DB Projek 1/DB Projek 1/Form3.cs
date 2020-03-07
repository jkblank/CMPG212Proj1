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
                string output = "";
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
        public Form3()
        {
            InitializeComponent();
        }

        private void tpCpu_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
