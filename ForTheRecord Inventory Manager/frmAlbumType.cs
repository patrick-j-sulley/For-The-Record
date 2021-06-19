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
    public partial class frmAlbumType : Form
    {
        private string _Type;

        public frmAlbumType()
        {
            InitializeComponent();
            //Text = question;
            rbCD.Checked = true;
            ShowDialog();
        }

        public string Type
        {
            get { return _Type; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(rbCD.Checked == true)
            {
                _Type = "CD";
            }
            else
            {
                _Type = "Vinyl";
            }
            DialogResult = DialogResult.OK;
        }
    }
}
