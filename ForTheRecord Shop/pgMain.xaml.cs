using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
//using System.Windows.Threading;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ForTheRecord_Shop
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            lstArtists.SelectedIndex = 0;
        }

        /// <summary>
        /// Attempts to retrieve all artist from the database, while checking the connection to the database
        /// </summary>
        /// <returns></returns>
        private async System.Threading.Tasks.Task GetArtists()
        {
            try
            {
                lstArtists.ItemsSource = await ServiceClient.GetArtistNamesAsync();
            }
            catch (Exception)
            {
                ClearWindow();
                tbMessageTitle.Text = "Error: Could not connect to the server";
                tbMessage.Text = "Check your connection or contact the server administrator.";
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {          
            await GetArtists();
        }

        /// <summary>
        /// Clears all the elements on the window
        /// </summary>
        private void ClearWindow()
        {
            lstArtists.Visibility = Visibility.Collapsed;
            tbArtistStock.Visibility = Visibility.Collapsed;
            txtArtistName.Visibility = Visibility.Collapsed;
            btnBrowse.Visibility = Visibility.Collapsed;
            btnFind.Visibility = Visibility.Collapsed;
            lstArtists.Visibility = Visibility.Collapsed;
            tbBrowseByArtistLabel.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Navigates to the Artist Page for the currently selected Artist
        /// </summary>
        private void ViewArtist()
        {

            if (lstArtists.SelectedItem != null)
                Frame.Navigate(typeof(pgArtist), lstArtists.SelectedItem);

        }

        /// <summary>
        /// Attempts to find the artist on lstArtists whose name matches the text in txtArtistName;
        /// </summary>
        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {

            lstArtists.SelectedItem = txtArtistName.Text;

            if (lstArtists.SelectedItem.ToString() != txtArtistName.Text)
            {
                tbArtistStock.Text = "Error: Artist Not Found";
            }
        }

        /// <summary>
        /// Calls to the ViewArtist method
        /// </summary>
        private void LstArtists_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            ViewArtist();
        }

        /// <summary>
        /// Calls to the ViewArtist method
        /// </summary>
        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            ViewArtist();
        }

        /// <summary>
        /// Quits the application
        /// </summary>
        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        /// <summary>
        /// Attempts to display the current stock for the selected artist, whilst checking for the state of the connection to the database
        /// </summary>
        private async void LstArtists_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                tbArtistStock.Text = "Stock for Artist: " + lcStock;
            }
            catch (Exception)
            {
                ClearWindow();
                tbMessageTitle.Text = "Error: Could not connect to the server";
                tbMessage.Text = "Check your connection or contact the server administrator.";
            }
        }
    }
}
