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
    public partial class frmArtist : Form
    {
        /// <summary>
        /// Holds the details of the currently selected Artist
        /// </summary>
        private clsArtist _Artist;

        /// <summary>
        /// Holds all the currently opened Artist forms
        /// </summary>
        private static Dictionary<string, frmArtist> _ArtistFormList =
            new Dictionary<string, frmArtist>();

        /// <summary>
        /// Holds all of the albums for the currently selected artist
        /// </summary>
        private static List<clsAlbum> _ArtistAlbumsList = new List<clsAlbum>();

        public frmArtist()
        {
            InitializeComponent();
            _ArtistAlbumsList.Clear();
            dgvAlbums.AutoGenerateColumns = false;
            dgvAlbums.MultiSelect = false;
            dgvAlbums.ReadOnly = true;
            rbDate.Enabled = false;
            rbName.Enabled = false;
            rbType.Enabled = false;

        }

        /// <summary>
        /// Runs a new instance of frmArtist for either a new Artist or a pre existing Artist
        /// </summary>
        /// <param name="prArtistName"></param>
        public static void Run(string prArtistName)
        {
            frmArtist lcArtistForm;
            clsArtist lcArtist;

            ///Checks to see if the artist name is empty or if the artist name can be retrieved from the artist forms list.
            if (string.IsNullOrEmpty(prArtistName) ||
            !_ArtistFormList.TryGetValue(prArtistName, out lcArtistForm))
            {
                lcArtistForm = new frmArtist();
                lcArtist = new clsArtist();

                /// Checks for a new or pre-existing artist
                if (string.IsNullOrEmpty(prArtistName))
                    lcArtistForm.SetDetails(lcArtist);
                else
                {
                    RunExistingArtist(prArtistName, lcArtistForm, lcArtist);
                }
            }
            ///If the artist name exists or if the artist name is on the artist forms list, the form will be re-activated
            else
            {
                lcArtistForm.Show();
                lcArtistForm.Activate();
            }
        }

        /// <summary>
        /// Runs a new instance of a pre-existing artist form
        /// </summary>
        /// <param name="prArtistName">The passed through artist name variable</param>
        /// <param name="prArtistForm">The passed through artist form variable</param>
        /// <param name="prArtist">The passed through artist variable</param>
        private async static void RunExistingArtist(string prArtistName, frmArtist prArtistForm, clsArtist prArtist)
        {
            ///Calls to database for details of the currently selected pre-existing artist
            try
            {
                _ArtistFormList.Add(prArtistName, prArtistForm);
                clsArtist lcArtistDetails = await ServiceClient.GetArtist(prArtistName);
                prArtist.Name = lcArtistDetails.Name;
                prArtist.Label = lcArtistDetails.Label;
                prArtistForm.SetDetails(prArtist);
            }
            catch (Exception)
            {

                MessageBox.Show("The artist that you tried to modify no longer exists within the system, the artist form will be updated to reflect this.", "Error: Specified Artist No Longer Exists");
                frmMain.Instance.UpdateDisplay();
            }
        }

        /// <summary>
        /// Sets the details on the form to match those of a pre-existing Artist
        /// </summary>
        /// <param name="prArtist">The passed through clsArtist object</param>
        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            txtArtistName.Enabled = string.IsNullOrEmpty(_Artist.Name);
            UpdateForm();
            UpdateDisplay(_Artist.Name);
            Show();
        }

        /// <summary>
        /// Updates the Album DataGridView to hold data from the _ArtistAlbums List dictionary
        /// </summary>
        /// <param name="prArtistName"></param>
        private async void UpdateDisplay(string prArtistName)
        {
            _ArtistAlbumsList.Clear();
            dgvAlbums.DataSource = null;

            _ArtistAlbumsList = await (ServiceClient.GetArtistsAlbums(_Artist.Name));

            if (_ArtistAlbumsList != null)
            {
                _Artist.AlbumsList = _ArtistAlbumsList;
                dgvAlbums.DataSource = _Artist.AlbumsList;
            }
        }

        /// <summary>
        /// Extracts each album from the Artist Albums datatable and adds them to the _ArtistAlbumsList dictionary. The _AlbumArtistList dictionary 
        /// is then used as the datasource to the _Artist class objects album list
        /// </summary>
        /// <param name="lcArtistAlbums"></param>
        private void SelectAlbums(DataTable lcArtistAlbums)
        {
            foreach (DataRow lcRow in lcArtistAlbums.Rows)
            {
                clsAlbum lcAlbum = new clsAlbum();
                lcAlbum.Name = lcRow["Name"].ToString();
                lcAlbum.Type = lcRow["Type"].ToString();
                lcAlbum.ArtistName = lcRow["ArtistName"].ToString();
                lcAlbum.Genre = lcRow["Genre"].ToString();
                lcAlbum.Price = Convert.ToDecimal(lcRow["Price"]);
                lcAlbum.LastModified = Convert.ToDateTime(lcRow["LastModified"]);
                lcAlbum.Tracks = Convert.ToInt16(lcRow["Tracks"]);
                lcAlbum.Stock = Convert.ToInt16(lcRow["Stock"]);

                if(lcAlbum.Type == "CD")
                {
                    lcAlbum.Discs = Convert.ToInt16(lcRow["Discs"]);
                    lcAlbum.Single = Convert.ToBoolean(lcRow["Single"]);
                }
                else
                {
                    lcAlbum.Sides = Convert.ToInt16(lcRow["Sides"]);
                    lcAlbum.Limited = Convert.ToBoolean(lcRow["Limited"]);
                    lcAlbum.BoxSet = Convert.ToBoolean(lcRow["BoxSet"]);
                }

                _ArtistAlbumsList.Add(lcAlbum);
            }
            _Artist.AlbumsList = _ArtistAlbumsList;
        }

        /// <summary>
        /// Updates the Artist Name and Artist Label text fields with the Name and Label variables within the _Artist class object
        /// </summary>
        public void UpdateForm()
        {
            txtArtistName.Text = _Artist.Name;
            txtArtistLabel.Text = _Artist.Label;
        }

        /// <summary>
        /// Closes the artist form and either tries to add a new artist to the database, or update the details to a pre-existing one
        /// </summary>
        private async void btnClose_Click(object sender, EventArgs e)
        {
            pushData();

            ///New Artist
            if (txtArtistName.Enabled)
            {
                    ///Checks for empty Artist Name field
                    if (txtArtistName.Text.Length > 0)
                    {
                    await AddNewArtist();
                    }

                    else
                    {
                        MessageBox.Show("The artist name field has been left empty, please input a valid artist name and try again.", "Error: Artist name cannot be null");
                    }

            }
            ///Pre-Existing Artist
            else
            {
                pushData();
                string lcUpdateArtist = await ServiceClient.UpdateArtist(_Artist);
                if (lcUpdateArtist == "\"Success\"")
                {
                    MessageBox.Show("Artist is up to date");
                    Hide();
                }
            }
            
        }

        /// <summary>
        /// Attempts to insert a new artist into the Database
        /// </summary>
        /// <returns></returns>
        private async Task AddNewArtist()
        {
            pushData();

            string lcNewArtist = await ServiceClient.InsertNewArtist(_Artist);

            if (lcNewArtist == "\"Success\"")
            {
                MessageBox.Show("New artist has been added to the system");
                frmMain.Instance.UpdateDisplay();
                txtArtistName.Enabled = false;
                Hide();
            }
            else
            {
                MessageBox.Show("The inputted artist has the same name as a pre-existing one, check the format of the name that was inputted and try again", "Error: Duplicate Artist Detected");

            }
        }

        /// <summary>
        /// Pushes the Artist Name and Label from the form to the Name and Label within the Artist Class Object
        /// </summary>
        private void pushData()
        {
            _Artist.Name = txtArtistName.Text;
            _Artist.Label = txtArtistLabel.Text;
        }

        /// <summary>
        /// Attempts to add a new album for the artist
        /// </summary>
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string lcType = new frmAlbumType().Type;
                if (!string.IsNullOrEmpty(lcType)) /// If the frmAlbumType prompt isn't cancelled
                {
                    clsAlbum lcAlbum = clsAlbum.NewAlbum(lcType);
                    if (lcAlbum != null) /// If a valid Album is instanstiated
                    {
                        if (txtArtistName.Enabled) /// Checks to see if a new artist has currently not been saved
                        {
                            await AddNewArtist();
                            txtArtistName.Enabled = false;
                        }
                        lcAlbum.ArtistName = _Artist.Name;
                        frmAlbum.DispatchAlbumForm(lcAlbum);
                        if (!string.IsNullOrEmpty(lcAlbum.Name)) /// Checks to see if the new album form has not been cancelled
                        {
                            clsArtist lcArtistDetails = await ServiceClient.GetArtist(_Artist.Name);
                            _Artist.Name = lcArtistDetails.Name;
                            _Artist.Label = lcArtistDetails.Label;
                            SetDetails(_Artist);
                            frmMain.Instance.UpdateDisplay();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// When the Album DataGridView is double clicked on
        /// </summary>
        private void dgvAlbums_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditSelectedAlbum();
        }

        /// <summary>
        /// When the edit button is clicked on
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelectedAlbum();
        }

        /// <summary>
        /// Attempts to edit the currently selected album on the Album DataGridView
        /// </summary>
        private void EditSelectedAlbum()
        {
            try
            {
                frmAlbum.DispatchAlbumForm(dgvAlbums.SelectedRows[0].DataBoundItem as clsAlbum);
                UpdateDisplay(_Artist.Name);
            }
            catch (Exception)
            {

                MessageBox.Show("The album that you tried to modify no longer exists within the system, the artist form will be updated to reflect this.", "Error: Specified Album No Longer Exists");
                Close();
            }
        }

        /// <summary>
        /// Attempts to delete the currently selected album from the database
        /// </summary>
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You have requested to delete the selected album from the system, Are you sure?", "Album Deletion Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsAlbum lcAlbum;
                string lcDeleteAlbum = await ServiceClient.DeleteAlbum(lcAlbum = dgvAlbums.SelectedRows[0].DataBoundItem as clsAlbum);
                if (lcDeleteAlbum == "\"Success\"")
                {
                    UpdateDisplay(_Artist.Name);
                }

            }
        }
    }
}
