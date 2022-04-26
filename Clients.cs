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
using FINAL.Class;
namespace FINAL
{
    public partial class Clients : Form
    {
        
        private DataTable dt;
        public Clients()
        {
            InitializeComponent();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM Clients";
            Class.Functions.Connect();
            dt = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dgClients.DataSource = dt; 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Reset();
            btnAdd.Enabled = true;
        }
        private void Reset()
        {
            txtClientID.Text = "";
            txtClientName.Text = "";
            txtAddress.Text = "";
            mskPhone.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;

            sql = "INSERT INTO Clients VALUES ('" + txtClientID.Text +
                "','" + txtClientName.Text + "','" + txtAddress.Text + "','" + mskPhone.Text + "')";
            Functions.RunSQL(sql);

            MessageBox.Show("Saved");
            LoadDataGridView();
            Reset();

        }

        private void dgClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No Data");
                return;
            }
            txtClientID.Text = dgClients.CurrentRow.Cells["ClientID"].Value.ToString();
            txtClientName.Text = dgClients.CurrentRow.Cells["ClientName"].Value.ToString();
            txtAddress.Text = dgClients.CurrentRow.Cells["Address"].Value.ToString();
            mskPhone.Text = dgClients.CurrentRow.Cells["Phone"].Value.ToString();
            
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string sql;

            sql = "UPDATE Clients SET ClientName='" + txtClientName.Text.ToString() + "',Address='" +
                txtAddress.Text.ToString() + "',Phone='" + mskPhone.Text.ToString() +
                "' WHERE ClientID='" + txtClientID.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            Reset();
            txtClientID.Enabled = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql;
            
         
            sql = "DELETE Clients WHERE ClientID='" + txtClientID.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            Reset();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
