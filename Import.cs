using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FINAL.Class;
using System.Data.SqlClient;

namespace FINAL
{
    public partial class Import : Form
    {
        DataTable dt;
        public Import()
        {
            InitializeComponent();
        }
        
        private void cbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            str = "SELECT ProductName FROM Products WHERE ProductID ='" + cbProductID.Text + "'";
            txtProductName.Text = Functions.GetFieldValues(str);

            str = "SELECT ExportPrice FROM Products WHERE ProductID = '" + cbProductID.Text + "'";
            txtImPrice.Text = Functions.GetFieldValues(str);
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM Import";
            Functions.Connect();
            dt = Functions.GetDataToTable(sql);
            dgImport.DataSource = dt;
        }

        private void Import_Load(object sender, EventArgs e)
        {
            Functions.Connect();

            Functions.FillCombo("SELECT ProductID, ProductName FROM Products", cbProductID, "ProductName", "ProductID");
            cbProductID.SelectedIndex = -1;

            LoadDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;

            sql = "INSERT INTO Import VALUES ('" + txtBillID.Text.ToString() +
                "','" + txtDate.Text.ToString() + "','"  + cbProductID.Text.ToString() + "','" + txtImPrice.Text.ToString() + "','" + txtQuantity.Text.ToString() + "')";

            Functions.RunSQL(sql);

            MessageBox.Show("Saved");
            LoadDataGridView();
            Reset();
        }
        private void Reset()
        {
            txtBillID.Text = "";
            txtDate.Text = "";
            cbProductID.Text = "";
            txtProductName.Text = "";
            txtImPrice.Text = "";
            txtQuantity.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
