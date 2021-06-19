using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ForTheRecord_Lookup_and_Order
{
    public static class ServiceClient
    {
        internal async static Task<List<string>> GetArtistNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/inventory/GetArtistNames/"));
        }

        //internal static DataTable RetrieveArtistNames()
        //{
        //    return clsDBConnection.SProcTable("ShowAllArtists", new Dictionary<string, object>());
        //}

        //internal async static Task<string> LocateArtistAsync(string prArtistName)
        //{
        //    using (HttpClient lcHttpClient = new HttpClient())
        //        return JsonConvert.DeserializeObject<string>
        //            (await lcHttpClient.GetStringAsync("http://localhost:60064/api/inventory/LocateArtist/?prName=" + prArtistName, "GET"));
        //}

        //internal static DataTable LocateArtist(string prName)
        //{
        //    return clsDBConnection.SProcTable("LocateArtist", new Dictionary<string, object>

        //    { ["prName"] = prName });
        //}


        internal async static Task<string> GetTotalArtistStock(string prArtistName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<string>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/inventory/GetTotalArtistStock/?prName=" + prArtistName));
        }

        //internal static DataTable GetTotalArtistStock(string prName)
        //{
        //    return clsDBConnection.SProcTable("GetTotalArtistStock", new Dictionary<string, object>

        //    { ["prName"] = prName });
        //}

        //internal static void DBConnectionTest()
        //{
        //    clsDBConnection.DbFunction("database", null);
        //}

        internal async static Task<List<clsOrder>> GetAllOrders()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsOrder>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/inventory/GetAllOrders/"));
        }

        //internal static DataTable GetAllOrders()
        //{
        //    return clsDBConnection.SProcTable("GetAllOrders", new Dictionary<string, object>());
        //}

        internal async static Task<string> GetTotalCostOfOrders()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<string>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/inventory/GetTotalCostOfOrders/"));
        }

        //internal static DataTable GetTotalCostOfOrders()
        //{
        //    return clsDBConnection.SProcTable("GetTotalCostOfOrders", new Dictionary<string, object>());
        //}

        internal async static Task<string> InsertNewAlbum(clsAlbum prAlbum)
        {
            return await InsertOrUpdateAsync(prAlbum, "http://localhost:60064/api/inventory/InsertAlbum", "POST");
        }

        //internal static DataTable InsertNewAlbum(clsAlbum prAlbum)
        //{
        //    return clsDBConnection.SProcTable("InsertNewAlbum", new Dictionary<string, object>

        //    {
        //      ["prName"] = prAlbum.Name,
        //      ["prType"] = prAlbum.Type,
        //      ["prArtistName"] = prAlbum.ArtistName,
        //      ["prGenre"] = prAlbum.Genre,
        //      ["prPrice"] = prAlbum.Price,
        //      ["prLastModified"] = prAlbum.LastModified,
        //      ["prTracks"] = prAlbum.Tracks,
        //      ["prStock"] = prAlbum.Stock,
        //      ["prDiscs"] = prAlbum.Discs,
        //      ["prSingle"] = prAlbum.Single,
        //      ["prSides"] = prAlbum.Sides,
        //      ["prLimited"] = prAlbum.Limited,
        //      ["prBoxSet"] = prAlbum.BoxSet
        //    });
        //}

        internal async static Task<List<clsAlbum>> GetArtistsAlbums(string prArtistName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAlbum>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/inventory/GetArtistsAlbums/?prName=" + prArtistName));
        }

        //internal static DataTable GetArtistsAlbums(string prArtistName)
        //{
        //    return clsDBConnection.SProcTable("GetArtistsAlbums", new Dictionary<string, object>

        //    { ["prName"] = prArtistName });
        //}

        internal async static Task<string> UpdateAlbum(clsAlbum prAlbum)
        {
            return await InsertOrUpdateAsync(prAlbum, "http://localhost:60064/api/inventory/UpdateAlbum", "PUT");
        }

        //internal static DataTable UpdateAlbum(clsAlbum prAlbum)
        //{
        //    return clsDBConnection.SProcTable("UpdateAlbum", new Dictionary<string, object>

        //    {
        //        ["prName"] = prAlbum.Name,
        //        ["prType"] = prAlbum.Type,
        //        ["prGenre"] = prAlbum.Genre,
        //        ["prPrice"] = prAlbum.Price,
        //        ["prLastModified"] = prAlbum.LastModified,
        //        ["prTracks"] = prAlbum.Tracks,
        //        ["prStock"] = prAlbum.Stock,
        //        ["prDiscs"] = prAlbum.Discs,
        //        ["prSingle"] = prAlbum.Single,
        //        ["prSides"] = prAlbum.Sides,
        //        ["prLimited"] = prAlbum.Limited,
        //        ["prBoxSet"] = prAlbum.BoxSet
        //    });
        //}

        internal async static Task<string> DeleteOrder(clsOrder prOrder)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
               ($"http://localhost:60064/api/inventory/DeleteOrder?prOrderID={prOrder.ID}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        //internal static DataTable DeleteOrder(clsOrder clsOrder)
        //{
        //    return clsDBConnection.SProcTable("DeleteOrder", new Dictionary<string, object>

        //    { ["prID"] = clsOrder.ID });
        //}

        internal async static Task<clsArtist> GetArtist(string prArtistName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsArtist>
                (await lcHttpClient.GetStringAsync
               ("http://localhost:60064/api/inventory/GetArtist?prName=" + prArtistName));
        }

        //internal static DataTable GetArtist(string prArtistName)
        //{
        //    return clsDBConnection.SProcTable("GetArtist", new Dictionary<string, object>

        //    { ["prName"] = prArtistName });
        //}

        internal async static Task<string> InsertNewArtist(clsArtist prArtist)
        {
            return await InsertOrUpdateAsync(prArtist, "http://localhost:60064/api/inventory/InsertNewArtist", "POST");
        }

        //internal static DataTable InsertNewArtist(string prArtistName, string prArtistLabel)
        //{
        //    return clsDBConnection.SProcTable("InsertNewArtist", new Dictionary<string, object>

        //    { ["prName"] = prArtistName, ["prLabel"] = prArtistLabel });
        //}

        //internal static DataTable LocateOrder(string txtID)
        //{
        //    return clsDBConnection.SProcTable("LocateOrder", new Dictionary<string, object>

        //    { ["prID"] = txtID });
        //}

        internal async static Task<string> UpdateArtist(clsArtist prArtist)
        {
            return await InsertOrUpdateAsync(prArtist, "http://localhost:60064/api/inventory/UpdateArtist", "PUT");

        }

        //internal static DataTable UpdateArtist(string prArtistName, string prArtistLabel)
        //{
        //    return clsDBConnection.SProcTable("UpdateArtist", new Dictionary<string, object>

        //    { ["prName"] = prArtistName, ["prLabel"] = prArtistLabel });
        //}

        internal async static Task<string> DeleteAlbum(clsAlbum prAlbum)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
               ($"http://localhost:60064/api/inventory/DeleteAlbum?prName={prAlbum.Name}&prType={prAlbum.Type}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        //internal static DataTable DeleteAlbum(clsAlbum prAlbum)
        //{
        //    return clsDBConnection.SProcTable("DeleteAlbum", new Dictionary<string, object>

        //    { ["prName"] = prAlbum.Name, ["prType"] = prAlbum.Type });
        //}

        internal async static Task<string> ChangeOrderStatus(clsOrder prOrder, string prOrderStatus)
        {
            prOrder.Status = prOrderStatus;

            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/inventory/ChangeOrderStatus", "PUT");

        }

        //internal static DataTable ChangeOrderStatus(clsOrder prOrder, string prOrderStatus)
        //{
        //    return clsDBConnection.SProcTable("ChangeOrderStatus", new Dictionary<string, object>

        //    { ["prID"] = prOrder.ID, ["prStatus"] = prOrderStatus });
        //}

        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
           new StringContent(JsonConvert.SerializeObject(prItem), Encoding.UTF8, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
    }
}
