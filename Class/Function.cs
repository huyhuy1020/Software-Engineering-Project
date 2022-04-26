using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms; 
using System.Configuration;

namespace FINAL.Class
{
 
    class Functions
    {
       
        public static SqlConnection conn;
        
        public static void Connect()
        {
            conn = new SqlConnection();   
            conn.ConnectionString = @"Data Source = (local); Initial Catalog = MVC; Integrated Security = True";
            conn.Open();

        }
        public static void Disconnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();   	
                conn.Dispose(); 	
                conn = null;
            }
        }
        //load datagridview
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Tạo đối tượng thuộc lớp SqlCommand
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Functions.conn; //Kết nối cơ sở dữ liệu
            da.SelectCommand.CommandText = sql; //Lệnh SQL
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static void RunSQL(string sql)
        {
            SqlCommand cmd; 
            cmd = new SqlCommand();
            cmd.Connection = conn; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); 
            }
            catch (Exception)
            {
            }
            cmd.Dispose();
            cmd = null;
        }

        public static void FillCombo(string sql, ComboBox cb , string ID, string Name)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cb.DataSource = dt;
            cb.ValueMember = ID; //Trường giá trị
            cb.DisplayMember = Name; //Trường hiển thị
        }
        public static string GetFieldValues(string sql)
        {
            string ID = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ID = reader.GetValue(0).ToString();
            reader.Close();
            return ID;
        }

    }
}
