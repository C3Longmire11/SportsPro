using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SportsProBusinessClassLibrary;

namespace SportsProUserInterface
{
    
    public partial class FrmNewCustomer : Form
    {
        CustomerBL customerBL = new CustomerBL();

        public FrmNewCustomer()
        {
            InitializeComponent();
        }

        private void BtnReturnToMain_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            if (IsDataPresent()) 
            {

                try
                {
                    Customer newCustomer = new Customer();
                    newCustomer.Name = txtName.Text;
                    newCustomer.Address = txtAddress.Text;
                    newCustomer.City = txtCity.Text;
                    newCustomer.State = txtState.Text;
                    newCustomer.ZipCode = txtZipCode.Text;
                    newCustomer.Phone = txtPhone.Text;
                    newCustomer.EMail = txtEmail.Text;

                    Int32 newAddedCustomer = customerBL.AddCustomer(newCustomer);
                    if (newAddedCustomer > 0)
                    {
                        MessageBox.Show("A record for Customer " + newCustomer.Name + " was successfully added to the database with Customer ID = " + newAddedCustomer, "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("A record for Customer" + newCustomer.Name + " was NOT successfully added to the database ", "Information", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    customerBindingSource.Clear();
                }
            }
            else
            {

                MessageBox.Show("Please input correct texts in all fields.", "Data Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsDataPresent()
        {
            if (ValidatorClass.IsPresent(txtName.Text) && ValidatorClass.IsPresent(txtAddress.Text) && ValidatorClass.IsPresent(txtCity.Text) && ValidatorClass.IsPresent(txtState.Text) && ValidatorClass.IsNumeric(txtZipCode.Text) && ValidatorClass.IsNumeric(txtPhone.Text) && ValidatorClass.IsPresent(txtEmail.Text))
            { return true; }
            else { return false; }

        }



    }
}
