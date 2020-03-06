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
    public partial class Form2 : Form
    {
        //public var
        public SqlConnection conn;
        public DataSet ds;
        public SqlDataAdapter adapt;

        //Method used to connect with error detection
        public void Connect()
        {
            try
            {
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

        //var 
        public string username, password = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Connect();
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT * FROM Users WHERE Username= '"+ username+"'and Password='"+ password +"'",conn);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if(dt.Rows[0][0].ToString()=="1")
            {
                this.Hide();

            }
            else
            {
                MessageBox.Show("the username or password enetered was incorrect");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            username = tbxUsername.Text;
            password = tbxPassword.Text;
            
            
        }
    }
}
