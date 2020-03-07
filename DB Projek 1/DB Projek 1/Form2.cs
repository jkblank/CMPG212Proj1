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
                string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CMPG212\DatabaseProject1\DB Projek 1\DB Projek 1\SpecDb1.mdf;Integrated Security=True";
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
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            username = tbxUserName.Text;
            password = tbxPassword.Text;
            if (tbxUserName.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbxUserName.Focus();
                return;
            }
            if (tbxPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbxPassword.Focus();
                return;
            }
            try
            {
                

                SqlCommand myCommand = default(SqlCommand);

                myCommand = new SqlCommand("SELECT UserName,Password FROM Users WHERE UserName = @Username AND Password = @Password", conn);

                SqlParameter uName = new SqlParameter("@Username", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@Password", SqlDbType.VarChar);

                uName.Value = tbxUserName.Text;
                uPassword.Value = tbxPassword.Text;

                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);

                myCommand.Connection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {
                    MessageBox.Show("You have logged in successfully " + tbxUserName.Text);
                    //Hide the login form
                    this.Hide();
                    //show from 3
                }


                else
                {
                    MessageBox.Show("Login Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    tbxUserName.Clear();
                    tbxPassword.Clear();
                    tbxUserName.Focus();

                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
    }

