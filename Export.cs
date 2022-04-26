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
using System.Configuration;

namespace FINAL
{
    
    public partial class Export : Form
    {
        DataTable dt;
        public Export()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Bill_Load(object sender, EventArgs e)
            //load data to combobox
        {
            Functions.Connect();
            Functions.FillCombo("SELECT ClientID, ClientName FROM Clients", cbClientID, "ClientName", "ClientID");
            cbClientID.SelectedIndex = -1;
            Functions.FillCombo("SELECT ProductID, ProductName FROM Products", cbProductID, "ProductName", "ProductID");
            cbProductID.SelectedIndex = -1;
            LoadDataGridView();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }
        
        private void Reset()
        {
            txtBillID.Text = "";
            txtClientAddress.Text = "";
            cbClientID.Text = "";
            txtClientName.Text = "";
            txtExPrice.Text = "";
            txtProductName.Text = "";
            txtQuantity.Text = "";
            
            cbProductID.Text = "";
            txtPhone.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql;

            sql = "INSERT INTO Export VALUES ('" + txtBillID.Text.ToString() +
                "','" + txtDate.Text.ToString() + "','" + cbClientID.Text.ToString() + "','" + cbProductID.Text.ToString() + "','" + txtExPrice.Text.ToString() + "','" + txtQuantity.Text.ToString() + "')";
           

            // sql = "UPDATE Products SET Quantity='" +txtQuantity.Text + "

            MessageBox.Show("Saved");
            LoadDataGridView();
            //Reset();

            /////////////

            



        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM Export";
            Functions.Connect();
            dt = Functions.GetDataToTable(sql); 
            dgExport.DataSource = dt;
        }

        private void dgBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            str = "SELECT ProductName FROM Products WHERE ProductID ='" + cbProductID.Text + "'";
            txtProductName.Text = Functions.GetFieldValues(str);

            str = "SELECT ExportPrice FROM Products WHERE ProductID = '" + cbProductID.Text + "'";
            txtExPrice.Text = Functions.GetFieldValues(str);
        }

        private void cbClientID_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string str;
            str = "SELECT ClientName FROM Clients WHERE ClientID ='" + cbClientID.Text + "'";
            txtClientName.Text = Functions.GetFieldValues(str);
            str = "SELECT Address FROM Clients WHERE ClientID = '" + cbClientID.Text + "'";
            txtClientAddress.Text = Functions.GetFieldValues(str);
            str = "SELECT Phone FROM Clients WHERE ClientID = '" + cbClientID.Text + "'";
            txtPhone.Text = Functions.GetFieldValues(str);

        }

        private void dgExport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
