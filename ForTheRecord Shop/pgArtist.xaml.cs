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
    public sealed partial class pgArtist : Page
    {
        /// <summary>
        /// Records down all of the Albums for the currently specified Artist
        /// </summary>
        private static List<clsAlbum> _ArtistAlbumsList = new List<clsAlbum>();

        /// <summary>
        /// Holds all the data for the currently specified Artist
        /// </summary>
        private clsArtist _Artist;

        public pgArtist()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lstAlbums.IsEnabled = true;
            btnOrder.IsEnabled = true;
        }

        /// <summary>
        /// Attempts to update the display of lstAlbums to display the albums for the currently specified artist
        /// if a connection to the server can be made, if no albums are availible for the specified artist,
        /// lstArtists will have its display updated to reflect this. The artists Name and Label are also displayed on this form.
        /// </summary>
        private async void updateDisplay()
        {
            _ArtistAlbumsList.Clear();
            lstAlbums.ItemsSource = null;

            try
            {
                _Artist.AlbumsList = await (ServiceClient.GetArtistsAlbums(_Artist.Name));
            }
            catch (Exception)
            {

                ClearWindow();
                tbArtist.Text = "Error: Could not connect to the server";
                tbMessage.Text = "Check your connection or contact the server administrator.";
            }

            if (_Artist.AlbumsList.Count != 0)
            {
                foreach(clsAlbum lcAlbum in _Artist.AlbumsList)
                {
                    _ArtistAlbumsList.Add(lcAlbum);
                }
                lstAlbums.ItemsSource = _Artist.AlbumsList;
            }
            else
            {
                lstAlbums.Items.Add("Artist Currently Has No Albums In Stock");
                lstAlbums.IsEnabled = false;
                btnOrder.IsEnabled = false;
            }

            tbArtist.Text = _Artist.Name;
            tbLabel.Text = _Artist.Label;

        }

        /// <summary>
        /// Pushes the data from the Name and Label elements on the form to match the Name and Label variables of the Artist class object
        /// </summary>
        private void pushData()
        {
            _Artist.Name = tbArtist.Text;
            _Artist.Label = tbLabel.Text;
        }

        /// <summary>
        /// When this page is navigated to, the program will attempt to retrieve the artist from the database, while also checking
        /// for a working connection.
        /// </summary>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {

            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                string lcArtistName = e.Parameter.ToString();

                try
                {
                    _Artist = await ServiceClient.GetArtist(lcArtistName);
                    updateDisplay();
                }
                catch (Exception)
                {

                    ClearWindow();
                    tbArtist.Text = "Error: Could not connect to the server";
                    tbMessage.Text = "Check your connection or contact the server administrator.";
                }
                
            }
                     
        }

        /// <summary>
        /// Clears all the functional elements from the page
        /// </summary>
        private void ClearWindow()
        {
            tbLabel.Visibility = Visibility.Collapsed;
            tbAlbumLabel.Visibility = Visibility.Collapsed;
            tbTypeLabel.Visibility = Visibility.Collapsed;
            tbStockLabel.Visibility = Visibility.Collapsed;
            tbPriceLabel.Visibility = Visibility.Collapsed;
            lstAlbums.Visibility = Visibility.Collapsed;
            btnOrder.Visibility = Visibility.Collapsed;
            btnView.Visibility = Visibility.Collapsed;
            btnOrder.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Goes back to the previous frame
        /// </summary>
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        /// <summary>
        /// Calls to the OrderAlbum method
        /// </summary>
        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderAlbum();
        }

        /// <summary>
        /// Opens the order page for the selected album
        /// </summary>
        private void OrderAlbum()
        {
            clsAlbum lcAlbum = lstAlbums.SelectedItem as clsAlbum;
            if (lstAlbums.SelectedItem != null)
                Frame.Navigate(typeof(pgOrder), lstAlbums.SelectedItem as clsAlbum);
        }

        /// <summary>
        /// Calls to the ViewAlbum method
        /// </summary>
        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            ViewAlbum();
        }

        /// <summary>
        /// Navigates to the Album Page for the selected Album
        /// </summary>
        private void ViewAlbum()
        {
            clsAlbum lcAlbum = lstAlbums.SelectedItem as clsAlbum;
            if (lstAlbums.SelectedItem != null)
                Frame.Navigate(typeof(pgAlbum), lstAlbums.SelectedItem as clsAlbum);
        }

        /// <summary>
        /// Calls to the ViewAlbum Method
        /// </summary>
        private void LstAlbums_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            ViewAlbum();
        }
    }
}
