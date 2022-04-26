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
using FINAL.Class;

namespace FINAL
{
    public partial class Products : Form
    {
        DataTable dt;
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No Data");
                return;
            }
            txtProductID.Text = dgProduct.CurrentRow.Cells["ProductID"].Value.ToString();
            txtProductName.Text = dgProduct.CurrentRow.Cells["ProductName"].Value.ToString();
            txtQuantity.Text = dgProduct.CurrentRow.Cells["Quantity"].Value.ToString();
            txtImprice.Text = dgProduct.CurrentRow.Cells["ImportPrice"].Value.ToString();
            txtExPrice.Text = dgProduct.CurrentRow.Cells["ExportPrice"].Value.ToString();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM Products";
            Class.Functions.Connect();
            dt = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dgProduct.DataSource = dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;

            sql = "INSERT INTO Products VALUES ('" + txtProductID.Text +
                "','" + txtProductName.Text + "','" + txtQuantity.Text + "','" + txtImprice.Text + "','"+txtExPrice.Text+"')";
            Class.Functions.RunSQL(sql);

            MessageBox.Show("Saved");
            LoadDataGridView();
            Reset();
        }
        private void Reset()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtQuantity.Text = "";
            txtExPrice.Text = "";
            txtImprice.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string sql;

            sql = "UPDATE Products SET ProductName='" + txtProductName.Text.ToString() + "',Quantity='" +
                txtQuantity.Text.ToString() + "',ImportPrice='" + txtImprice.Text.ToString() + "',ExportPrice='" +
                txtExPrice.Text.ToString() +
                "' WHERE ProductID='" + txtProductID.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "DELETE Products WHERE ProductID='" + txtProductID.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            Reset();
        }

        private void dgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
