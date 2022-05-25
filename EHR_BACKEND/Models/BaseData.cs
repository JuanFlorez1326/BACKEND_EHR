using MySql.Data.MySqlClient;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Model
{
    public class BaseData
    {
        MySqlConnection connection;
    

        public BaseData()
        {
            connection = new MySqlConnection("datasource = dbehr.ci9ckwkufffp.us-east-1.rds.amazonaws.com; port = 3306; username = easyhouserent; password = easyhouserent; database = ehr ; SSLMode = none");
        }
        public string executeSql(string sql)
        {
            string result = "";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                int rows = cmd.ExecuteNonQuery();

                if (rows > -1)
                {
                    result = "Correct";
                }
                else
                {
                    result = "Incorrect";
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message;

            }
            return result;
        }

        public DataTable getTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(dt);
                connection.Close();
                adapter.Dispose();
            }
            catch
            {
                dt = null;
            }
            return dt;
        }


        public List<object> ConvertDataTabletoString(string sql)
        {
            DataTable dt = new DataTable();
            using (connection)
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    List<object> rows = new List<object>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return rows;
                }
            }
        }
    }
}
