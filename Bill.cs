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
    
    public partial class Bill : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
        DataTable dt;
        public Bill()
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
            Functions.FillCombo("SELECT ClientID, ClientName FROM Client", cbClientID, "ClientName", "ClientID");
            cbClientID.SelectedIndex = -1;
            Functions.FillCombo("SELECT ID, Name FROM Products", cbProductID, "Name", "ID");
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
            txtTotal.Text = "";
            cbProductID.Text = "";
            txtPhone.Text = "";
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql;

            sql = "INSERT INTO Export VALUES ('" + txtBillID.Text.ToString() +
                "','" + txtDate.Text.ToString() + "','" + cbClientID.Text.ToString() + "','" + cbProductID.Text.ToString() + "','" + txtExPrice.Text.ToString() + "','"+txtQuantity.Text.ToString() + "')";
            
            Class.Functions.RunSQL(sql);

            MessageBox.Show("Saved");
            LoadDataGridView();
            Reset();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM Export";
            Class.Functions.Connect();
            dt = Functions.GetDataToTable(sql); 
            dgExport.DataSource = dt;
        }

        private void dgBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            str = "SELECT Name FROM Products WHERE ID ='" + cbProductID.Text + "'";
            txtProductName.Text = Functions.GetFieldValues(str);

            str = "SELECT ExportPrice FROM Products WHERE ID = '" + cbProductID.Text + "'";
            txtExPrice.Text = Functions.GetFieldValues(str);
        }

        private void cbClientID_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string str;
            str = "SELECT ClientName FROM Client WHERE ClientID ='" + cbClientID.Text + "'";
            txtClientName.Text = Functions.GetFieldValues(str);
            str = "SELECT Address FROM Client WHERE ClientID = '" + cbClientID.Text + "'";
            txtClientAddress.Text = Functions.GetFieldValues(str);
            str = "SELECT Phone FROM Client WHERE ClientID = '" + cbClientID.Text + "'";
            txtPhone.Text = Functions.GetFieldValues(str);

        }

        private void dgExport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
