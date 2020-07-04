using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using CatchMe.Models;

namespace CatchMe.Services
{
    public class DataStore : IDataStore<Item>
    {
        // TODO in case of "Trust anchor for certification path not found." issue check this https://stackoverflow.com/a/55108710
        HttpClient client;
        IEnumerable<Item> items;

        public DataStore()
        {
            var clientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    //bypass
                    return true;
                },
            };
            client = new HttpClient(clientHandler, false);
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<Item>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"api/item");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item>>(json));
            }

            return items;
        }

        public async Task<Item> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Item>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            if (item == null || item.Id == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/item/{item.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
