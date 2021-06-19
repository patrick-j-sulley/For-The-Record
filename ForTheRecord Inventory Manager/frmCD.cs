using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ForTheRecord_Inventory_Manager
{
    public sealed partial class frmCD : ForTheRecord_Inventory_Manager.frmAlbum
    {
        ///Singleton
        private static readonly frmCD Instance = new frmCD();
        public frmCD()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs the frmCD Instance
        /// </summary>
        /// <param name="prAlbum">The passed over clsAlbum variable</param>
        public static void Run(clsAlbum prAlbum)
        {
            Instance.SetDetails(prAlbum);
        }

        /// <summary>
        /// Updates the form with details based on the CD album type
        /// </summary>
        protected override void updateForm()
        {
            base.updateForm();
            numNoOfDiscs.Value = Convert.ToDecimal(_Album.Discs);
            if(_Album.Single == true)
            {
                cbSingle.Checked = true;  
            }
            else
            {
                cbSingle.Checked = false;
            }
        }

        /// <summary>
        /// Pushes data based on the CD Album Type
        /// </summary>
        protected override void pushData()
        {
            base.pushData();
            _Album.Discs = Convert.ToInt16(numNoOfDiscs.Value);
            if (cbSingle.Checked == true)
            {
                _Album.Single = true;
            }
            else
            {
                _Album.Single = false;
            }
        }
    }
}
