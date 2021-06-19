using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ForTheRecord_Shop
{

    public sealed partial class pgAlbum : Page
    {
        /// <summary>
        /// The specified album for the current Album Page
        /// </summary>
        private clsAlbum _Album;

        public pgAlbum()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Goes back to the previous frame
        /// </summary>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Attempts to set the _Album variable to the value of the passed over clsAlbum variable
        /// </summary>
        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                base.OnNavigatedTo(e);
                if (e.Parameter != null)
                {
                    _Album = e.Parameter as clsAlbum;
                    updateDisplay();
                }
                
            }
            catch (Exception)
            {


            }
        }

        /// <summary>
        /// Sets the elements on the form to display the data of either a CD or Vinyl album
        /// </summary>
        private void updateDisplay()
        {

            tbAlbumName.Text = _Album.Name;
            tbArtistName.Text = _Album.ArtistName;
            tbGenre.Text = _Album.Genre;
            tbTracks.Text = _Album.Tracks.ToString();
            tbType.Text = _Album.Type;
            tbPrice.Text = _Album.Price.ToString();
            tbStock.Text = _Album.Price.ToString();

            if (_Album.Type == "CD")
            {
                
                tbSingleOrLimitedBool.Text = _Album.Single.ToString();               
                tbDiscsOrSidesAmount.Text = _Album.Discs.ToString();
                tbBoxSet.Text = "";
                tbBoxSetBool.Text = "";

            }
            else
            {
                tbSingleOrLimited.Text = "Limited:";
                tbSingleOrLimitedBool.Text = _Album.Limited.ToString();
                tbDiscsOrSides.Text = "Sides:";
                tbDiscsOrSidesAmount.Text = _Album.Sides.ToString();
                tbBoxSetBool.Text = _Album.BoxSet.ToString();
            }
        }
    }
}
