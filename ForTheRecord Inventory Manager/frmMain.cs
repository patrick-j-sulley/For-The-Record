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
    public sealed partial class frmMain : Form
    {
        ///Singleton
        private static readonly frmMain _Instance = new frmMain();

        public frmMain()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
        }

        /// <summary>
        /// Instance of the Main Form
        /// </summary>
        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        /// <summary>
        /// Updates lstArtists with the name of all the current artists within the system, and checks for any errors in connectivity to the database
        /// </summary>
        public async void UpdateDisplay()
        {

            lstArtists.DataSource = null;

            try
            {
                lstArtists.DataSource = await ServiceClient.GetArtistNamesAsync();
            }
            catch (Exception)
            {

                MessageBox.Show("Check your connection or contact the server administrator.", "Error: Could not connect to the server");
                lstArtists.DataSource = null;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                txtLocateArtist.Enabled = false;
                btnLocateArtist.Enabled = false;
                btnViewOrder.Enabled = false;
            }

        }

        /// <summary>
        /// Attempts to add a new artist
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmArtist.Run(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding new artist");
            }
        }

        /// <summary>
        /// Attempts to locate an artist on the lstArtists based on the inputted name in the txtLocateArtist text box
        /// </summary>
        private void btnLocateArtist_Click(object sender, EventArgs e)
        {

            lstArtists.SelectedItem = txtLocateArtist.Text;

            if(lstArtists.SelectedItem.ToString() != txtLocateArtist.Text)
            {
                MessageBox.Show("The inputted artist was not found, check the format of the name that was inputted and try again.", "Error: Artist Not Found ");
            }

        }

        /// <summary>
        /// Opens the order form
        /// </summary>
        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            frmOrders.Run();
        }

        /// <summary>
        /// Closes the program
        /// </summary>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Everytime the selected index has changed, the program will attempt to take the artists name from the list and collect the total stock from the
        /// database for that artist
        /// </summary>
        private async void lstArtists_SelectedIndexChanged(object sender, EventArgs e)
        {

            string lcName;

            try
            {
                lcName = lstArtists.SelectedItem.ToString();

            }
            catch (Exception)
            {

                lstArtists.SelectedIndex = 0;
                lcName = lstArtists.SelectedItem.ToString();
            }

            try
            {
                string lcStock = await ServiceClient.GetTotalArtistStock(lcName);
                lblArtistStock.Text = "Stock for Artist: " + lcStock;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        /// <summary>
        /// When the list is double clicked
        /// </summary>
        private void lstArtists_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditArtist();
        }

        /// <summary>
        /// When the edit button is clicked on
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditArtist();
        }

        /// <summary>
        /// Attempts to edit the currently selected artist
        /// </summary>
        private void EditArtist()
        {
            string lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
                try
                {
                    frmArtist.Run(lstArtists.SelectedItem as string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }
    }
}
