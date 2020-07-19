using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CatchMe.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace CatchMe.Services
{
    public class FriendDataStore : IDataStore<Friend>
    {
        // TODO in case of "Trust anchor for certification path not found." issue check this https://stackoverflow.com/a/55108710
        HttpClient client;
        IEnumerable<Friend> friends;

        public FriendDataStore()
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

            friends = new List<Friend>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<Friend>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"api/friends");
                friends = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Friend>>(json));
            }

            return friends;
        }

        public async Task<Friend> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Friend>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Friend item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Friend friend)
        {
            if (friend == null || friend.FriendSessionId == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(friend);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/friends/{friend.FriendSessionId}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/friends/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
