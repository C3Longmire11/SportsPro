using SportsProBusinessClassLibrary;
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
    public partial class FrmViewCustomerByID : Form
    {
        CustomerBL customerBusinessLogic = new CustomerBL();
        Customer selectedCustomer = new Customer();
        public bool deleteRecord;

        private bool IsDataValid()
        {
            if (ValidatorClass.IsPresent(txtCustomerID.Text) && ValidatorClass.IsNumeric(txtCustomerID.Text))

            { return true; }
            else { return false; }
        }
        public FrmViewCustomerByID()
        {
            InitializeComponent();
        }

        private void BtnHideCustomerByID_Click(object sender, EventArgs e)
        {


            if (txtCustomerID.Text != null)
            {
                ClearCustomerInfo();
                //customerBindingSource.Clear();
            }                
            //customerBindingSource.Clear();
            this.Hide();

        }

        private void ClearCustomerInfo()
        {      
                txtCustomerID.Text = string.Empty;
                txtCustomerID.Focus();
                foreach (Control ctl in panelCustomer.Controls)
                {
                    if (ctl.Name.Contains("lbl") || ctl is TextBox)
                    {
                        ctl.Text = string.Empty;
                    }
                }              
        }

        private void BtnGetCustomer_Click(object sender, EventArgs e)
        {
            if(IsDataValid())
            {
                try
                {

                    Int32 intCustomerID = Convert.ToInt32(txtCustomerID.Text);
                    selectedCustomer = customerBusinessLogic.GetCustomerByID(intCustomerID);

                    if (selectedCustomer != null)
                    {
                        customerBindingSource.DataSource = selectedCustomer;
                        if (deleteRecord)
                        {
                            btnDeleteCustomerByID.Visible = true;
                        }
                        else
                        {
                            btnDeleteCustomerByID.Visible = false;
                        }
                    }
                    else
                    {
                        ClearCustomerInfo();
                        string strMessage = "Customer Record for CustomerID = " + intCustomerID + ", Does not Exist in the Database";
                        MessageBox.Show(strMessage, "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {

                }

            }
            else
            {
                txtCustomerID.Clear();
                txtCustomerID.Focus();
                MessageBox.Show("Input Data must be numeric", "Data Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            

        }


        private void BtnDeleteCustomerByID_Click(object sender, EventArgs e)
        {
            try
            {

                Int32 intCustomerID = Convert.ToInt32(txtCustomerID.Text);
                bool recordDeleted = customerBusinessLogic.RemoveCustomer(intCustomerID);

                if (recordDeleted)
                {
                    ClearCustomerInfo();
                    MessageBox.Show("Customer Record for CustomerID = " + intCustomerID + " was successfully deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Customer Record for CustomerID = " + intCustomerID + " was NOT deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btnDeleteCustomerByID.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmViewCustomerByID_VisibleChanged(object sender, EventArgs e)
        {
            btnDeleteCustomerByID.Visible = false;
        }
    }
}
