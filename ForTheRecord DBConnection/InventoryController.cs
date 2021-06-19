using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ForTheRecord_SelfHost
{
    public class InventoryController : ApiController
    {
        /// <summary>
        /// Calls to the ShowAllArtists Stored Procedure from the Database and Returns a list of all the artist names
        /// </summary>
        /// <returns></returns>
        public List<string> GetArtistNames()
        {
            DataTable lcAllArtists = clsDBConnection.SProcTable("ShowAllArtists", new Dictionary<string, object>());
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcAllArtists.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        /// <summary>
        /// Calls to the GetTotalArtistStock Stored Procedure from the Database and Returns the total stock for the specified artist
        /// </summary>
        /// <returns></returns>
        public string GetTotalArtistStock(string prName)
        {
            DataTable lcTotalArtistStock = clsDBConnection.SProcTable("GetTotalArtistStock", new Dictionary<string, object>

            { ["prName"] = prName });

            string lcStock;
            lcStock = lcTotalArtistStock.Rows[0]["totalStock"].ToString();
            return lcStock;
        }

        /// <summary>
        /// Calls to the GetAllOrders Stored Procedure from the Database and Returns a list of all orders
        /// </summary>
        /// <returns></returns>
        public List<clsOrder> GetAllOrders()
        {
            DataTable lcAllOrders = clsDBConnection.SProcTable("GetAllOrders", new Dictionary<string, object>());
            List<clsOrder> lcOrdersList = new List<clsOrder>();
            foreach (DataRow dr in lcAllOrders.Rows)
            {
                clsOrder lcOrder = new clsOrder();

                lcOrder.ID = Convert.ToInt16(dr["ID"]);
                lcOrder.AlbumName = dr["AlbumName"].ToString();
                lcOrder.AlbumType = dr["AlbumType"].ToString();
                lcOrder.Status = dr["Status"].ToString();
                lcOrder.Quantity = Convert.ToInt16(dr["Quantity"]);
                lcOrder.TotalPrice = Convert.ToDecimal(dr["TotalPrice"]);
                lcOrder.DateTime = Convert.ToDateTime(dr["DateTime"]);
                lcOrder.CustomerName = dr["CustomerName"].ToString();
                lcOrder.CustomerAddress = dr["CustomerAddress"].ToString();
                lcOrder.CustomerEmail = dr["CustomerEmail"].ToString();

                lcOrdersList.Add(lcOrder);
            }
            
            return lcOrdersList;
        }

        /// <summary>
        /// Calls to the GetTotalCostOfOrders Stored Procedure from the Database and Returns the total cost of all orders
        /// </summary>
        /// <returns></returns>
        public string GetTotalCostOfOrders()
        {
            DataTable lcTotalCostOfOrders = clsDBConnection.SProcTable("GetTotalCostOfOrders", new Dictionary<string, object>());

            string lcCost;
            lcCost = lcTotalCostOfOrders.Rows[0]["TotalCostOfOrders"].ToString();
            return lcCost;
        }

        /// <summary>
        /// Calls to the InsertNewAlbum Stored Procedure from the Database and Returns the results of an insert new album attempt 
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public string InsertAlbum(clsAlbum prAlbum)
        { // insert
            try
            {
                DataTable lcNewAlbum = clsDBConnection.SProcTable("InsertNewAlbum", new Dictionary<string, object>

                {
                    ["prName"] = prAlbum.Name,
                    ["prType"] = prAlbum.Type,
                    ["prArtistName"] = prAlbum.ArtistName,
                    ["prGenre"] = prAlbum.Genre,
                    ["prPrice"] = prAlbum.Price,
                    ["prLastModified"] = prAlbum.LastModified,
                    ["prTracks"] = prAlbum.Tracks,
                    ["prStock"] = prAlbum.Stock,
                    ["prDiscs"] = prAlbum.Discs,
                    ["prSingle"] = prAlbum.Single,
                    ["prSides"] = prAlbum.Sides,
                    ["prLimited"] = prAlbum.Limited,
                    ["prBoxSet"] = prAlbum.BoxSet
                });
          
                    return "Success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// Calls to the GetArtistsAlbums Stored Procedure from the Database and Returns a list of all albums for an artist
        /// </summary>
        /// <returns></returns>
        public List<clsAlbum> GetArtistsAlbums(string prName)
        {
            DataTable lcArtistAlbums = clsDBConnection.SProcTable("GetArtistsAlbums", new Dictionary<string, object>

            { ["prName"] = prName });

            List<clsAlbum> lcArtistAlbumsList = new List<clsAlbum>();

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

                if (lcAlbum.Type == "CD")
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

                lcArtistAlbumsList.Add(lcAlbum);
            }
            return lcArtistAlbumsList;
        }

        /// <summary>
        /// Calls to the UpdateAlbum Stored Procedure from the Database and Returns the result from an update album attempt
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpPut]
        public string UpdateAlbum(clsAlbum prAlbum)
        { // update
            try
            {
                DataTable lcUpdateAlbum = clsDBConnection.SProcTable("UpdateAlbum", new Dictionary<string, object>

                {
                    ["prName"] = prAlbum.Name,
                    ["prType"] = prAlbum.Type,
                    ["prGenre"] = prAlbum.Genre,
                    ["prPrice"] = prAlbum.Price,
                    ["prLastModified"] = prAlbum.LastModified,
                    ["prTracks"] = prAlbum.Tracks,
                    ["prStock"] = prAlbum.Stock,
                    ["prDiscs"] = prAlbum.Discs,
                    ["prSingle"] = prAlbum.Single,
                    ["prSides"] = prAlbum.Sides,
                    ["prLimited"] = prAlbum.Limited,
                    ["prBoxSet"] = prAlbum.BoxSet
                });
                return "Success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// Calls to the DeleteOrder Stored Procedure from the Database and Returns the result from a delete album attempt
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpDelete]
        public string DeleteOrder(string prOrderID)
        { // delete

            try
            {
                DataTable lcRecCount = clsDBConnection.SProcTable("DeleteOrder", new Dictionary<string, object>

                { ["prID"] = prOrderID });

                return "Success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// Calls to the GetArtist Stored Procedure from the Database and Returns the collected Artist
        /// </summary>
        /// <returns></returns>
        public clsArtist GetArtist(string prName)
        { 

           DataTable lcArtist = clsDBConnection.SProcTable("GetArtist", new Dictionary<string, object>

           { ["prName"] = prName });

            return new clsArtist()
            {
                Name = lcArtist.Rows[0]["Name"].ToString(),
                Label = lcArtist.Rows[0]["Label"].ToString()
            };
        }

        /// <summary>
        /// Calls to the GetAlbumDetails Stored Procedure from the Database and Returns the specified Album
        /// </summary>
        /// <returns></returns>
        public clsAlbum GetAlbumDetails(string prName, string prType)
        {

            DataTable lcGetAlbum = clsDBConnection.SProcTable("GetAlbumDetails", new Dictionary<string, object>

            { ["prName"] = prName, ["prType"] = prType });

            clsAlbum lcAlbum = new clsAlbum();

            lcAlbum.Name = lcGetAlbum.Rows[0]["Name"].ToString();
            lcAlbum.Type = lcGetAlbum.Rows[0]["Type"].ToString();
            lcAlbum.ArtistName = lcGetAlbum.Rows[0]["ArtistName"].ToString();
            lcAlbum.Genre = lcGetAlbum.Rows[0]["Genre"].ToString();
            lcAlbum.Price = Convert.ToDecimal(lcGetAlbum.Rows[0]["Price"]);
            lcAlbum.LastModified = Convert.ToDateTime(lcGetAlbum.Rows[0]["LastModified"]);
            lcAlbum.Tracks = Convert.ToInt16(lcGetAlbum.Rows[0]["Tracks"]);
            lcAlbum.Stock = Convert.ToInt16(lcGetAlbum.Rows[0]["Stock"]);

            if (lcAlbum.Type == "CD")
            {
                lcAlbum.Discs = Convert.ToInt16(lcGetAlbum.Rows[0]["Discs"]);
                lcAlbum.Single = Convert.ToBoolean(lcGetAlbum.Rows[0]["Single"]);
            }
            else
            {
                lcAlbum.Sides = Convert.ToInt16(lcGetAlbum.Rows[0]["Sides"]);
                lcAlbum.Limited = Convert.ToBoolean(lcGetAlbum.Rows[0]["Limited"]);
                lcAlbum.BoxSet = Convert.ToBoolean(lcGetAlbum.Rows[0]["BoxSet"]);
            }

            return lcAlbum;

        }

        /// <summary>
        /// Calls to the InsertNewArtist Stored Procedure from the Database and Returns the result from an insert new artist attempt
        /// </summary>
        /// <returns></returns>
        public string InsertNewArtist(clsArtist prArtist)
        { // insert
            try
            {
                DataTable lcNewArtist = clsDBConnection.SProcTable("InsertNewArtist", new Dictionary<string, object>

                { ["prName"] = prArtist.Name, ["prLabel"] = prArtist.Label });

                return "Success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// Calls to the UpdateArtist Stored Procedure from the Database and Returns the result from an update artist attempt
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpPut]
        public string UpdateArtist(clsArtist prArtist)
        { // update
            try
            {
                DataTable lcUpdateAlbum = clsDBConnection.SProcTable("UpdateArtist", new Dictionary<string, object>

                { ["prName"] = prArtist.Name, ["prLabel"] = prArtist.Label });

                return "Success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// Calls to the DeleteAlbum Stored Procedure from the Database and Returns the result from a delete album attempt
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpDelete]
        public string DeleteAlbum(string prName, string prType)
        { // delete

            try
            {
                DataTable lcRecCount =  clsDBConnection.SProcTable("DeleteAlbum", new Dictionary<string, object>

                { ["prName"] = prName, ["prType"] = prType });

                return "Success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// Calls to the ChangeOrderStatus Stored Procedure from the Database and Returns the result from a change order status attempt
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpPut]
        public string ChangeOrderStatus(clsOrder prOrder)
        { // update
            try
            {
                DataTable lcUpdateAlbum = clsDBConnection.SProcTable("ChangeOrderStatus", new Dictionary<string, object>

                { ["prID"] = prOrder.ID, ["prStatus"] = prOrder.Status });

                return "Success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// Calls to the InsertNewOrder Stored Procedure from the Database and Returns the result from an insert new order attempt
        /// </summary>
        /// <returns></returns>
        public string InsertNewOrder(clsOrder prOrder)
        { // insert
            try
            {
                DataTable lcNewArtist = clsDBConnection.SProcTable("InsertNewOrder", new Dictionary<string, object>

                { ["prAlbumName"] = prOrder.AlbumName,
                    ["prAlbumType"] = prOrder.AlbumType,
                    ["prStatus"] = prOrder.Status,
                    ["prQuantity"] = prOrder.Quantity,
                    ["prTotalPrice"] = prOrder.TotalPrice,
                    ["prDateTime"] = prOrder.DateTime,
                    ["prCustomerName"] = prOrder.CustomerName,
                    ["prCustomerAddress"] = prOrder.CustomerAddress,
                    ["prCustomerEmail"] = prOrder.CustomerEmail,
                });

                return "Success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// Calls to the UpdateAlbumStock Stored Procedure from the Database and Returns the result from an update album stock attempt
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpPut]
        public string UpdateAlbumStock(clsAlbum prAlbum)
        { // update
            try
            {
                DataTable lcUpdateAlbum = clsDBConnection.SProcTable("UpdateAlbumStock", new Dictionary<string, object>

                { ["prAlbumName"] = prAlbum.Name, ["prAlbumType"] = prAlbum.Type, ["prStock"] = prAlbum.Stock });

                return "Success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }

    }
}
