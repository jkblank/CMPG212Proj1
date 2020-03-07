/*
*   John Klerck
*/

using System;
using System.Data.SqlClient;

namespace DB_Projek_1
{
    public class PopulateCPU
    {
        private string sqlpiece1, sqlpiece2, sqlpiece3, sqlpiece4, sqlpiece5="";
        private string sqlStatement="SELECT * FROM CPU ";
        

        public void Populate()
        {
            if(!cbMan.SelectedIndex==-1)
            {
                sqlpiece1="WHERE Manufacturer LIKE "+cbMan.Items[cbMan.SelectedIndex].ToString() + " AND ";
            }

            if(!cbModel.SelectedIndex==-1)
            {
                sqlpiece2="WHERE Model LIKE "+cbModel.Items[cbModel.SelectedIndex].ToString()+ " AND ";
            }

            if(!cbYear.SelectedIndex==-1)
            {
                sqlpiece3="WHERE YearReleased LIKE "+cbYear.Items[cbYear.SelectedIndex].ToString()+ " AND ";
                //sqlpiece3= "WHERE year BETWEEN "
            }

            if(!cbPrice.SelectedIndex==-1)             //Price SQLPiece 4
            {
                if (cbPrice.SelectedIndex==0)      //0-1k
                {
                    sqlpiece4="WHERE Price BETWEEN 1 AND 999 AND ";
                }

                if (cbPrice.SelectedIndex==1)      //1k-2k5
                {
                    sqlpiece4="WHERE Price BETWEEN 1000 AND 2499 AND ";
                }

                if (cbPrice.SelectedIndex==2)      //2k5-5k
                {
                    sqlpiece4="WHERE Price BETWEEN 2500 AND 4999 AND ";
                }

                if (cbPrice.SelectedIndex==3)      //5k-10k
                {
                    sqlpiece4="WHERE Price BETWEEN 5000 AND 9999 AND ";
                }

                if (cbPrice.SelectedIndex==4)      //10k+
                {
                    sqlpiece4="WHERE Price BETWEEN 10000 AND 150000 AND ";
                }
            }

            if (!cbCores.SelectedIndex==-1)
            {
                sqlpiece5="WHERE Cores Like " +cbCores.Items[cbCores.SelectedIndex].ToString()+ " AND ";//+" AND ";
            }

            

            if(sqlpiece1!="")
            {
                sqlStatement+=sqlpiece1; //MANUFACTURER

            }

            if(sqlpiece2!="")
            {
                sqlStatement+=sqlpiece2; //MODEL
                
            }
            if(sqlpiece3!="")
            {
                sqlStatement+=sqlpiece3; //year
                
            }
            if(sqlpiece4!="")
            {
                sqlStatement+=sqlpiece3; //Price
                
            }

            sqlStatement+= "InStock BETWEEN 1 AND 10000";

            //Finally use the tiny string that 
            //shitshow of code was used to make

            try
            {
                conn.Open();
                SqlCommand com;
                adapt= new SqlDataAdapter();
                ds = new DataSet();

                com=new SqlCommand(sqlStatement, conn);

                adapt.SelectCommand=com;
                adapt.Fill(ds, "CPUs");

                //populate datagridview

                dataGirdView1.DataSource=ds;
                dataGirdView1.DataMember="CPUs";

                //Populate combo box
                SqlDataReader datReader = com.ExecuteReader();
                string output = "";
                while (datReader.Read())
                {
                    if (!cbMan.Items.Contains(datReader.GetValue(4)))
                    {

                        //check these index values
                        cbMan.Items.Add(datReader.GetValue(4));
                        cbModel.Items.Add(datReader.GetValue(4));
                        cbStock.Items.Add(datReader.GetValue(4));
                        cbYear.Items.Add(datReader.GetValue(4));
                        cbCores.Items.Add(datReader.GetValue(4));
                        cbPrice.Items.Add(datReader.GetValue(4));
                    }
                }//While end
                

                conn.Close();

            }
            catch(SqlExeption error)
            {
                MessageBox.Show(error.Message);

            }

        }

        public void main (string [] args)
        {
            Populate();
        }
    }
}