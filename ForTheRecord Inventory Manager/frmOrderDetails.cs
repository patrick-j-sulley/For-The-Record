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
    public partial class frmOrderDetails : Form
    {
        ///Singleton
        private static readonly frmOrderDetails Instance = new frmOrderDetails();

        protected clsOrder _Order;

        public frmOrderDetails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs an instance of the Order Details form
        /// </summary>
        /// <param name="prOrder">The passed through clsOrder variable</param>
        public static void Run(clsOrder prOrder)
        {
            Instance.SetDetails(prOrder);
        }

        /// <summary>
        /// Sets the details of the order on the form to those of the passed through order variable
        /// </summary>
        /// <param name="prOrder">The passed through clsOrder variable</param>
        private void SetDetails(clsOrder prOrder)
        {
            _Order = prOrder;
            updateForm();
            ShowDialog();
        }

        /// <summary>
        /// Updates the elements on the form to reflect the data of the order variable
        /// </summary>
        private void updateForm()
        {
            lblID.Text = "ID: " + _Order.ID;
            lblAlbumName.Text = "Album Name: " + _Order.AlbumName;
            lblAlbumType.Text = "Album Type: " + _Order.AlbumType;
            lblQuantity.Text = "Order Quantity: " + _Order.Quantity;
            lblTotalCost.Text = "Total Cost of Order: $" + _Order.TotalPrice;
            lblDateOfOrder.Text = "Date of Order: " + _Order.DateTime;
            lblCustomerName.Text = "Customer Name: " + _Order.CustomerName;
            lblCustomerAddress.Text = "Customer Address: " + _Order.CustomerAddress;
            lblCustomerEmail.Text = "Customer Email: " + _Order.CustomerEmail;
        }

        /// <summary>
        /// Closes the dialog
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
