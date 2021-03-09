using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ExportDataToExel
{
    public class DBHelper
    {
       private const string _connectionString = "Data Source=47.97.155.45,58838;Initial Catalog=RBCNEW_DEV;Persist Security Info=True;User Id=uat_rbc_user;Password=@Ribencun_user2017";

        public DataTable ConnectDB()
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string sql = "select top 10 ID,LoginName,UserName,Email,Mobile,UserType,CreaterName from [User]";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, dbConnection);
                sqlDataAdapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
        }
    }
}
