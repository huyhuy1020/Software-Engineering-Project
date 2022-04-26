using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
namespace FINAL
{
    public partial class main : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

        public main()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
          
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
        }

        private void main_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mnExit_Click(object sender, EventArgs e)
        {
            
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Products pr = new Products();
            pr.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Clients cl = new Clients();
            cl.Show();
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            Export bi = new Export();
            bi.Show();
        }

        private void btnImport_Click_1(object sender, EventArgs e)
        {
            Import im = new Import();
            im.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
