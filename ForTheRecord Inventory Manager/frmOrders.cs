using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForTheRecord_Inventory_Manager
{
    public partial class frmOrders : Form
    {
        /// <summary>
        /// Holds all of the orders within the database
        /// </summary>
        private static List<clsOrder> _OrdersList = new List<clsOrder>();

        public frmOrders()
        {
            InitializeComponent();
            _OrdersList.Clear();
            UpdateDisplay();
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.MultiSelect = false;
            dgvOrders.ReadOnly = true;
            rbDate.Enabled = false;
            rbOrderID.Enabled = false;
            txtLocateOrder.Enabled = false;
            btnLocateOrder.Enabled = false;
            tmrUpdateDisplay.Start();
        }

        /// <summary>
        /// Updates the Orders DataGridView with all of the recorded Orders within the database
        /// </summary>
        private async void UpdateDisplay()
        {
            _OrdersList = await ServiceClient.GetAllOrders();

            if (_OrdersList != null)
            {
                dgvOrders.DataSource = null;

                dgvOrders.DataSource = _OrdersList;

                string lcTotalOrdersCost = await ServiceClient.GetTotalCostOfOrders();

                lblTotalOrderCost.Text = "$" + lcTotalOrdersCost + " NZD";
            }
        }

        /// <summary>
        /// Runs a new instance of the Orders Form
        /// </summary>
        public static void Run()
        {
            frmOrders lcOrdersForm = new frmOrders();
            lcOrdersForm.Show();
            lcOrdersForm.Activate();
        }

        /// <summary>
        /// Closes the orders form
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Prompts the user asking if they want to delete an order, to which the order will then be deleted and the list will be updated
        /// </summary>
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You have requested to delete the selected order from the system, Are you sure?", "Order Deletion Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsOrder lcOrder;
               
                string lcDeleteAlbum = await ServiceClient.DeleteOrder(lcOrder = dgvOrders.SelectedRows[0].DataBoundItem as clsOrder);

                if (lcDeleteAlbum != "\"Success\"")
                {
                    MessageBox.Show("The order that you have tried to modify no longer exists, the order form will be updated to reflect this", "Error: The specified order no longer exists");

                }

                _OrdersList.Clear();
                UpdateDisplay();
                
            }
        }

        /// <summary>
        /// Attempts to change the status of an order
        /// </summary>
        private async void btnStatusChange_Click(object sender, EventArgs e)
        {
            clsOrder lcOrder = dgvOrders.SelectedRows[0].DataBoundItem as clsOrder;
            string lcOrderStatus = new frmChangeStatus(lcOrder).Status;

            if (!string.IsNullOrEmpty(lcOrderStatus))///If the prompt wasn't cancelled
            {

               string lcChangeOrderStatus = await ServiceClient.ChangeOrderStatus(lcOrder, lcOrderStatus);

                if(lcChangeOrderStatus != "\"Success\"")
                {
                    MessageBox.Show("The order that you have tried to modify no longer exists, the order form will be updated to reflect this", "Error: The specified order no longer exists");
                }
                    _OrdersList.Clear();
                    UpdateDisplay();
            }
        }

        /// <summary>
        /// Every 5 seconds, updates the display
        /// </summary>
        private void tmrUpdateDisplay_Tick(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        /// <summary>
        /// Runs an Order Details form for the selected Order
        /// </summary>
        private void dgvOrders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tmrUpdateDisplay.Stop();
            clsOrder lcOrder = dgvOrders.SelectedRows[0].DataBoundItem as clsOrder;
            frmOrderDetails.Run(lcOrder);
            tmrUpdateDisplay.Start();
        }
    }
}

