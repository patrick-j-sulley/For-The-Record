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
    public partial class frmChangeStatus : Form
    {

        private string _Status;

        /// <summary>
        /// On instanstiation, checks for order status, and then shows dialog
        /// </summary>
        /// <param name="prOrder">The passed through clsOrder variable</param>
        public frmChangeStatus(clsOrder prOrder)
        {
            InitializeComponent();
            if (prOrder.Status == "Pending")
            {
                rbPending.Checked = true;
            }
            else
            {
                rbConfirm.Checked = true;
            }
            ShowDialog();
        }

        public string Status
        {
            get { return _Status; }
        }

        /// <summary>
        /// Sets the _Status variable based on the currently selected Radio Button
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbPending.Checked == true)
            {
                _Status = "Pending";
            }
            else
            {
                _Status = "Confirmed";
            }
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Closes the Dialog
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
