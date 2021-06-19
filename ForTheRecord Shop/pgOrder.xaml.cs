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
using System.Text.RegularExpressions;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ForTheRecord_Shop
{
    public sealed partial class pgOrder : Page
    {
        /// <summary>
        /// Holds the details for the currently selected Album
        /// </summary>
        private clsAlbum _Album;

        /// <summary>
        /// Holds the details for the currently selected Order
        /// </summary>
        private clsOrder _Order;

        public pgOrder()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Upon being navigated to, the program will attempt to retrieve the album from the database, whilst checking the status
        /// of the connection to the database, as well as checking for the stock of the album.
        /// </summary>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                base.OnNavigatedTo(e);
                if (e.Parameter != null)
                {
                    _Album = e.Parameter as clsAlbum;

                    try
                    {
                        _Album = await (ServiceClient.GetAlbumDetails(_Album));
                    }
                    catch (Exception)
                    {

                        ClearWindow();
                        tbMessageType.Text = "Error: Could not connect to the server";
                        tbMessage.Text = "Check your connection or contact the server administrator.";
                    }

                    if (_Album.Stock > 0)
                    {
                        updateDisplay();
                    }
                    else
                    {
                        ClearWindow();
                        tbMessageType.Text = "Album is currently out of stock";
                        tbMessage.Text = "Check again later. Please contact us if you would like to be updated when this item is back in stock.";
                    }
                }

            }
            catch (Exception)
            {


            }
        }

        /// <summary>
        /// Updates the elements on the order form to represent the details of the selected Album
        /// </summary>
        private void updateDisplay()
        {
            tbAlbumName.Text = _Album.Name + " " + _Album.Type;
            tbPricePerUnit.Text = _Album.Price.ToString();
            tbQuantity.Text = "1";
            txtOverall.Text = _Album.Price.ToString();
            tbAmountInStock.Text = _Album.Stock.ToString();
        }

        /// <summary>
        /// Checks to see if the input in the Quantity text box is both numerical and equal to or under the stock amount for the selected Album
        /// </summary>
        private void TbQuantity_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            tbQuantity.Text.All(char.IsDigit);

            try
            {
                txtOverall.Text = Convert.ToString(Convert.ToDecimal(tbQuantity.Text) * _Album.Price);
            }
            catch (Exception)
            {

                tbQuantity.Text = "1";
            }

            if (Convert.ToInt16(tbQuantity.Text) > _Album.Stock)
            {
                tbQuantity.Text = "1";
            }


        }

        /// <summary>
        /// Goes back to the previous frame
        /// </summary>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        /// <summary>
        /// Checks for email formatting in the Email text box, before calling to the CreateNewOrder method
        /// </summary>
        private async void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            tbEmailError.Text = "";
            if(IsValidEmailAddress(txtEmail.Text) == true)
            {
                await CreateNewOrder();
            }
            else
            {
                tbEmailError.Text = "Error: Email Address incorrectly formatted";
            }
            
        }

        /// <summary>
        /// Checks for the validity of email formatting for the passed through string and returns the bool result
        /// </summary>
        /// <param name="lcEmailInput">The passed through string variable</param>
        private static bool IsValidEmailAddress(string lcEmailInput)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(lcEmailInput);
        }

        /// <summary>
        /// Prepares the Order request to be sent to the database by collecting the up to date details for the album from the database
        /// </summary>
        /// <returns></returns>
        private async System.Threading.Tasks.Task CreateNewOrder()
        {
            _Order = new clsOrder();

            _Album = await (ServiceClient.GetAlbumDetails(_Album));

            _Order.AlbumName = _Album.Name;
            _Order.AlbumType = _Album.Type;
            _Order.Status = "Pending";
            _Order.Quantity = Convert.ToInt16(tbQuantity.Text);
            _Order.TotalPrice = Convert.ToDecimal(txtOverall.Text);
            _Order.DateTime = DateTime.Now;
            _Order.CustomerName = txtName.Text;
            _Order.CustomerEmail = txtEmail.Text;
            _Order.CustomerAddress = txtAddress.Text;

            if (_Album.Stock - Convert.ToInt16(tbQuantity.Text) >= 0) ///If the remaining album stock after the order quantity is over 0
            {

                _Album.Stock = _Album.Stock - Convert.ToInt16(tbQuantity.Text);

                string lcAlbumStock = await (ServiceClient.UpdateAlbumStock(_Album));

                string lcNewOrder = await (ServiceClient.InsertNewOrder(_Order));


                if (lcNewOrder == "\"Success\"" && lcAlbumStock == "\"Success\"") ///If both the album stock update and new order insertion are successful
                {
                    ClearWindow();
                    tbMessageType.Text = "Success: Order Successfully Submitted";
                    tbMessage.Text = "Your order will be reviewed by a sales manager as soon as possible. Thank you for your order!";
                }
                else ///If the selected album no longer exists within the database
                {
                    ClearWindow();
                    tbMessageType.Text = "Error: Album in Order No Longer Available";
                    tbMessage.Text = "The Album that you have tried to order is no longer available, this may be due to another user purchasing it before you. Please contact us if you would like to be updated when this item is back in stock.";
                }
            }
            else /// If the remaining album stock after the order is under 0
            {
                ClearWindow();
                tbMessageType.Text = "Error: Album Stock not High Enough";
                tbMessage.Text = "You have tried to order a higher quality of this album than the amount of availible stock, please try again.";
            }
        }

        /// <summary>
        /// Clears all the elements on the page
        /// </summary>
        private void ClearWindow()
        {
            tbProductLabel.Visibility = Visibility.Collapsed;
            tbAlbumName.Visibility = Visibility.Collapsed;
            tbPricePerUnitLabel.Visibility = Visibility.Collapsed;
            tbPricePerUnit.Visibility = Visibility.Collapsed;
            tbAmountInStockLabel.Visibility = Visibility.Collapsed;
            tbAmountInStock.Visibility = Visibility.Collapsed;
            tbOrderQuantityLabel.Visibility = Visibility.Collapsed;
            tbQuantity.Visibility = Visibility.Collapsed;
            txtName.Visibility = Visibility.Collapsed;
            tbNameLabel.Visibility = Visibility.Collapsed;
            tbAddressLabel.Visibility = Visibility.Collapsed;
            txtAddress.Visibility = Visibility.Collapsed;
            tbEmailLabel.Visibility = Visibility.Collapsed;
            txtEmail.Visibility = Visibility.Collapsed;
            tbOverallCostLabel.Visibility = Visibility.Collapsed;
            tbDollarSignLabel.Visibility = Visibility.Collapsed;
            txtOverall.Visibility = Visibility.Collapsed;
            btnConfirm.Visibility = Visibility.Collapsed;
            btnCancel.Content = "Go Back";
        }
    }
}
