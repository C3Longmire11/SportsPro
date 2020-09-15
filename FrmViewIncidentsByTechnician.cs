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
    public partial class FrmViewIncidentsByTechnician : Form
    {
        IncidentsBL incidentsBusinessLogic = new IncidentsBL();
        public FrmViewIncidentsByTechnician()
        {
            InitializeComponent();
        }

        private void BtnHideIncidents_Click(object sender, EventArgs e)
        {
            registeredIncidentBindingSource.Clear();
            dgvIncidents.DataSource = string.Empty;
            this.Hide();
        }

        private void BtnIncidentsNoTech_Click(object sender, EventArgs e)
        {
            try
            {
                dgvIncidents.DataSource = incidentsBusinessLogic.GetNoTechIncidents();
                lblDisplayHeader.Text = "All Incidents that do not have a Technician assigned";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIncidentsClosed_Click(object sender, EventArgs e)
        {
            try
            {
                dgvIncidents.DataSource = incidentsBusinessLogic.GetClosedIncidents();
                lblDisplayHeader.Text = "All Incidents that have been CLOSED";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BtnIncidentsOpen_Click(object sender, EventArgs e)
        {
            try
            {
                dgvIncidents.DataSource = incidentsBusinessLogic.GetOpenIncidents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lblDisplayHeader.Text = "All Incidents that are still OPEN";
        }
    }
}
