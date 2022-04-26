using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace FINAL
{
    public partial class Form1 : Form
    {
       String strConn = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            String sSQL = "SELECT UserID, Password FROM tblUsers WHERE " + "UserID='" + txtUserID.Text + "' and Password='" + txtPassword.Text + "'";

            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("login successfully");
                main add = new main();
                add.Show();

            }
            else
            {
                MessageBox.Show("invalid login");
            }
            conn.Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
