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
    public partial class FrmViewAllCustomers : Form
    {
        CustomerBL customerBusinessLogic = new CustomerBL();
        public FrmViewAllCustomers()
        {
            InitializeComponent();
        }

        private void BtnHideAllCustomers_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmViewAllCustomers_Load(object sender, EventArgs e)
        {
            try
            {
                dgvAllCustomers.DataSource = customerBusinessLogic.GetAllCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
