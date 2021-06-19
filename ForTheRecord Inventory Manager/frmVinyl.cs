using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ForTheRecord_Inventory_Manager
{
    public partial class frmVinyl : ForTheRecord_Inventory_Manager.frmAlbum
    {
        ///Singleton
        private static readonly frmVinyl Instance = new frmVinyl();
        public frmVinyl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs the frmVinyl Instance
        /// </summary>
        /// <param name="prAlbum">The passed over clsAlbum variable</param>
        public static void Run(clsAlbum prAlbum)
        {
            Instance.SetDetails(prAlbum);
        }

        /// <summary>
        /// Updates the form with details based on the Vinyl album type
        /// </summary>
        protected override void updateForm()
        {
            base.updateForm();
            numNoOfSides.Value = Convert.ToDecimal(_Album.Sides);
            if (_Album.Limited == true)
            {
                cbLimited.Checked = true;
            }
            else
            {
                cbLimited.Checked = false;
            }
            if (_Album.BoxSet == true)
            {
                cbBoxSet.Checked = true;
            }
            else
            {
                cbBoxSet.Checked = false;
            }
        }

        /// <summary>
        /// Pushes data based on the Vinyl Album Type
        /// </summary>
        protected override void pushData()
        {
            base.pushData();
            _Album.Sides = Convert.ToInt16(numNoOfSides.Value);
            if (cbLimited.Checked == true)
            {
                _Album.Limited = true;
            }
            else
            {
                _Album.Limited = false;
            }
            if (cbBoxSet.Checked == true)
            {
                _Album.BoxSet = true;
            }
            else
            {
                _Album.BoxSet = false;
            }
        }
    }
}
