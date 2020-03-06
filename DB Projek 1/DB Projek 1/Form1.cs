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
    
    public partial class Form1 : Form
    {

        //public Var

        public SqlConnection conn;
        public DataSet ds;
        public SqlDataAdapter adapt;
        public Form2 f2 = new Form2();
        public Form3 f3 = new Form3();
   

        public Form1()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            f2.MdiParent = this;
            f3.MdiParent = this;
            f3.Show();
            f2.BringToFront();
            f2.Show();
           
        }
    }
}
