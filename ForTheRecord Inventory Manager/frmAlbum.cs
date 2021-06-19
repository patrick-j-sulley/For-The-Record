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
    public partial class frmAlbum : Form
    {
        /// <summary>
        /// Holds the details of the currently selected album
        /// </summary>
        protected clsAlbum _Album;

        public frmAlbum()
        {
            InitializeComponent();
            dtpDateLastModified.Enabled = false;
        }

        /// <summary>
        /// Populates lstAlbumGenre with all the availible Genre options for an album
        /// </summary>
        private void PopulateAlbumList()
        {
            lstAlbumGenre.Items.Add("Hip-Hop");
            lstAlbumGenre.Items.Add("Rock");
            lstAlbumGenre.Items.Add("Pop");
            lstAlbumGenre.Items.Add("R&B");
            lstAlbumGenre.Items.Add("Metal");
            lstAlbumGenre.Items.Add("Jazz");
            lstAlbumGenre.Items.Add("Rock");
            lstAlbumGenre.Items.Add("EDM");
            lstAlbumGenre.Items.Add("Soul");
            lstAlbumGenre.Items.Add("Country");
            lstAlbumGenre.Items.Add("Funk");
            lstAlbumGenre.Items.Add("Disco");
            lstAlbumGenre.Items.Add("Reggae");
            lstAlbumGenre.Items.Add("Punk");
            lstAlbumGenre.Items.Add("Ambient");
            lstAlbumGenre.Items.Add("Classical");
        }

        /// <summary>
        /// Sets the details on the form to match those of a pre-existing album
        /// </summary>
        /// <param name="prAlbum">The passed through clsAlbum object</param>
        public void SetDetails(clsAlbum prAlbum)
        {
            _Album = prAlbum;
            updateForm();
            ShowDialog();
        }

        protected virtual bool isValid()
        {
            return true;
        }

        /// <summary>
        /// Updates the elements on the form to hold data from the _Album variable
        /// </summary>
        protected virtual void updateForm()
        {

            PopulateAlbumList();
            lstAlbumGenre.Sorted = true;
            txtAlbumName.Text = _Album.Name;
            
            if (_Album.Genre != null)
            {
                lstAlbumGenre.SelectedItem = _Album.Genre;
            }
            else
            {
                lstAlbumGenre.SelectedIndex = 0;
            }

            numPricePerUnit.Value = _Album.Price;
            dtpDateLastModified.Value = DateTime.Now;
            numNoOfTracks.Value = Convert.ToDecimal(_Album.Tracks);
            numAmountInStock.Value = Convert.ToDecimal(_Album.Stock);
            txtAlbumName.Enabled = string.IsNullOrEmpty(_Album.Name);
        }

        /// <summary>
        /// Pushes data from the form elements to the _Album Variable
        /// </summary>
        protected virtual void pushData()
        {
            _Album.Name = txtAlbumName.Text;
            _Album.Genre = lstAlbumGenre.SelectedItem.ToString();
            _Album.Price = numPricePerUnit.Value;
            _Album.LastModified = DateTime.Now;
            _Album.Tracks = Convert.ToInt16(numNoOfTracks.Value);
            _Album.Stock = Convert.ToInt16(numAmountInStock.Value);
        }

        /// <summary>
        /// Loads a new form based on the type of selected album
        /// </summary>
        /// <param name="prAlbum">The passed through clsAlbum variable</param>
        public delegate void LoadWorkFormDelegate(clsAlbum prAlbum);

        /// <summary>
        /// Contains the options for Forms to load for the LoadWorkFormDelegate method
        /// </summary>
        public static Dictionary<string, Delegate> _AlbumForm = new Dictionary<string, Delegate>
        {
        {"CD", new LoadWorkFormDelegate(frmCD.Run)},
        {"Vinyl", new LoadWorkFormDelegate(frmVinyl.Run)}
        };

        /// <summary>
        /// Dispatches the specified type of album form to be displayed to the user
        /// </summary>
        /// <param name="prAlbum">The passed through clsAlbum variable</param>
        public static void DispatchAlbumForm(clsAlbum prAlbum)
        {
            _AlbumForm[prAlbum.Type].DynamicInvoke(prAlbum);
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Pushes the data form the form to the _Album Variable, and will then either insert a new album to the database, or edit a pre-existing one
        /// </summary>
        private async void btnOK_Click(object sender, EventArgs e)
        {
            pushData();

            /// If a new album is being created
            if (txtAlbumName.Enabled)
            {

                string lcNewAlbum = await ServiceClient.InsertNewAlbum(_Album);

                if (lcNewAlbum == "\"Success\"")
                {
                    MessageBox.Show("New album has been added for the artist");
                }
                else
                {
                    MessageBox.Show("The inputted album has the same name and type as a pre-existing one, check the format of the name, as well as the type and try again.", "Error: Duplicate Album + Type Detected");
                }

            }

            ///If a pre-existing album is being edited.
            else
            {
                string lcUpdateAlbum = await ServiceClient.UpdateAlbum(_Album);

                if (lcUpdateAlbum == "\"Success\"")
                {
                    MessageBox.Show("Album is up to date");
                }
                else
                {
                    MessageBox.Show("Check the formatting of all fields and try again", "Error: One or More Fields are incorrectly formatted");

                }
            }
        }
    }
}
