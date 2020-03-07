using System;

namespace DB_Projek_1
{
    public class PopulateGPU
    {
        private string sqlpiece1, sqlpiece2, sqlpiece3, sqlpiece4, sqlpiece5, sqlpiece6="";
        

        public void PopulateGPU()
        {
            if(!cmbManu.SelectedIndex==-1)
            {
                sqlpiece1="WHERE Manufacturer LIKE "+cmbManu.Items[cmbManu.SelectedIndex].ToString();
            }

            if(!cmbModel.SelectedIndex==-1)
            {
                sqlpiece2="WHERE Model LIKE "+cmbModel.Items[cmbModel.SelectedIndex].ToString();
            }
            

            if(!cmbYear.SelectedIndex==-1)
            {
                sqlpiece3="WHERE Year LIKE "+cmbYear.Items[cmbYear.SelectedIndex].ToString();
                //sqlpiece3= "WHERE year BETWEEN "
            }

            if(!cmbPrice.SelectedIndex==-1)
            {
                if (cmbPrice.SelectedIndex==0)      //0-1k
                {
                    sqlpiece4="WHERE Price BETWEEN ";
                }

                if (cmbPrice.SelectedIndex==1)      //1k-2k5
                {
                    
                }

                if (cmbPrice.SelectedIndex==2)      //2k5-5k
                {
                    
                }

                if (cmbPrice.SelectedIndex==3)      //5k-10k
                {
                    
                }

                if (cmbPrice.SelectedIndex==4)      //10k+
                {
                    
                }
            }

            if (!cmbVRAM.SelectedIndex==-1)
            {
                sqlpiece5="WHERE VRAMGB Like " +cmbCores.Items[cmbCores.SelectedIndex].ToString();
            }
            if(!cmbBrand.SelectedIndex==-1)
            {
                sqlpiece6="WHERE Brand LIKE "+cmbBrand.Items[cmbBrand.SelectedIndex].ToString();
            }


            string sqlStatement="SELECT * FROM CPU ";

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
                sqlStatement+=sqlpiece3; //MODEL
                
            }

            sqlStatement+= "InStock BETWEEN 1 AND 10000";
        }
    }
}