using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ForTheRecord_Shop
{
    public static class ServiceClient
    {
        /// <summary>
        /// Calls to the InventoryController for the GetArtistNames method
        /// </summary>
        /// <returns></returns>
        internal async static Task<List<string>> GetArtistNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/inventory/GetArtistNames/"));
        }

        /// <summary>
        /// Calls to the InventoryController for the GetTotalArtistStock Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<string> GetTotalArtistStock(string prArtistName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<string>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/inventory/GetTotalArtistStock/?prName=" + prArtistName));
        }

        /// <summary>
        /// Calls to the InventoryController for the GetAllOrders Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<List<clsOrder>> GetAllOrders()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsOrder>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/inventory/GetAllOrders/"));
        }

        /// <summary>
        /// Calls to the InventoryController for the GetTotalCostOfOrders Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<string> GetTotalCostOfOrders()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<string>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/inventory/GetTotalCostOfOrders/"));
        }

        /// <summary>
        /// Calls to the InventoryController for the Insert Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<string> InsertNewAlbum(clsAlbum prAlbum)
        {
            return await InsertOrUpdateAsync(prAlbum, "http://localhost:60064/api/inventory/InsertAlbum", "POST");
        }

        /// <summary>
        /// Calls to the InventoryController for the UpdateAlbumStock Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<string> UpdateAlbumStock(clsAlbum prAlbum)
        {
            return await InsertOrUpdateAsync(prAlbum, "http://localhost:60064/api/inventory/UpdateAlbumStock", "PUT");
        }

        /// <summary>
        /// Calls to the InventoryController for the GetArtist Albums Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<List<clsAlbum>> GetArtistsAlbums(string prArtistName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAlbum>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/inventory/GetArtistsAlbums/?prName=" + prArtistName));
        }

        /// <summary>
        /// Calls to the InventoryController for the UpdateAlbum Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<string> UpdateAlbum(clsAlbum prAlbum)
        {
            return await InsertOrUpdateAsync(prAlbum, "http://localhost:60064/api/inventory/UpdateAlbum", "PUT");
        }

        /// <summary>
        /// Calls to the InventoryController for the DeleteOrder Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<string> DeleteOrder(clsOrder prOrder)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
               ($"http://localhost:60064/api/inventory/DeleteOrder?prOrderID={prOrder.ID}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// Calls to the InventoryController for the GetArtist Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<clsArtist> GetArtist(string prArtistName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsArtist>
                (await lcHttpClient.GetStringAsync
               ("http://localhost:60064/api/inventory/GetArtist?prName=" + prArtistName));
        }

        /// <summary>
        /// Calls to the InventoryController for the GetAlbumDetails Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<clsAlbum> GetAlbumDetails(clsAlbum prAlbum)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsAlbum>
                (await lcHttpClient.GetStringAsync
               ($"http://localhost:60064/api/inventory/GetAlbumDetails?prName={prAlbum.Name}&prType={prAlbum.Type}"));
        }

        /// <summary>
        /// Calls to the InventoryController for the InsertNewArtist Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<string> InsertNewArtist(clsArtist prArtist)
        {
            return await InsertOrUpdateAsync(prArtist, "http://localhost:60064/api/inventory/InsertNewArtist", "POST");
        }

        /// <summary>
        /// Calls to the InventoryController for the UpdateArtist Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<string> UpdateArtist(clsArtist prArtist)
        {
            return await InsertOrUpdateAsync(prArtist, "http://localhost:60064/api/inventory/UpdateArtist", "PUT");

        }

        /// <summary>
        /// Calls to the InventoryController for the DeleteAlbum Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<string> DeleteAlbum(clsAlbum prAlbum)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
               ($"http://localhost:60064/api/inventory/DeleteAlbum?prName={prAlbum.Name}&prType={prAlbum.Type}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// Calls to the InventoryController for the ChangeOrderStatus Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<string> ChangeOrderStatus(clsOrder prOrder, string prOrderStatus)
        {
            prOrder.Status = prOrderStatus;

            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/inventory/ChangeOrderStatus", "PUT");

        }

        /// <summary>
        /// Calls to the InventoryController for the InsertOrUpdateAsync Method
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Calls to the InventoryController for the InsertNewOrder Method
        /// </summary>
        /// <returns></returns>
        internal async static Task<string> InsertNewOrder(clsOrder prOrder)
        {
            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/inventory/InsertNewOrder", "POST");
        }
    }
}
