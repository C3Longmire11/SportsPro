using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsProUserInterface
{
    public partial class FrmMain : Form
    {
        FrmViewAllCustomers frmAllCustomers = new FrmViewAllCustomers();
        FrmViewCustomerByID frmCustomerByID = new FrmViewCustomerByID();
        FrmNewCustomer frmNewCustomer = new FrmNewCustomer();
        FrmViewIncidentsByTechnician frmIncidentsByTech = new FrmViewIncidentsByTechnician();


        public FrmMain()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form frm in this.MdiChildren)
            {
                if(frm.Visible == true || frm.Visible == false)
                {
                    frm.Close();
                }
            }

            this.Close();
            Application.Exit();
        }

        private void ViewAllCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllCustomers.MdiParent = this;
            frmAllCustomers.Dock = DockStyle.Fill;
            frmAllCustomers.Show();
        }

        private void ViewCustomerByIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmCustomerByID.MdiParent = this;
            frmCustomerByID.StartPosition = FormStartPosition.CenterScreen;
            frmCustomerByID.Text = "Sports Pro - View Customer by ID";
            frmCustomerByID.deleteRecord = false;
            frmCustomerByID.Show();

        }

        private void DeleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerByID.MdiParent = this;
            frmCustomerByID.StartPosition = FormStartPosition.CenterScreen;
            frmCustomerByID.Text = "Sports Pro - Delete Selected Customer";
            frmCustomerByID.deleteRecord = true;
            frmCustomerByID.Show();
        }

        private void AddCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewCustomer.MdiParent = this;
            frmNewCustomer.StartPosition = FormStartPosition.CenterScreen;
            frmNewCustomer.Text = "Sports Pro - Add Customer";
            //btnAddCustomer.Visiable = true;
            frmNewCustomer.Show();
        }

        private void viewAllIncidentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewIncidentsByTechnicianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIncidentsByTech.MdiParent = this;
            frmIncidentsByTech.StartPosition = FormStartPosition.CenterScreen;
            frmIncidentsByTech.Show();
        }
    }
}
