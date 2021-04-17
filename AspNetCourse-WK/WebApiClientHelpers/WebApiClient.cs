﻿using EntityHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebApiClientHelpers
{
    public class WebApiClient<T> where T: Entity
    {
        private readonly string concreteAddress;
        public HttpClient Client;
        public WebApiClient(string baseAddress, string concreteAddress)
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
            this.concreteAddress = concreteAddress;
        }
        public async Task<T> GetAsync(int id)
        {
            try
            {
                var response = await Client.GetAsync($"{concreteAddress}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content);
                }
                throw new Exception(response.StatusCode.ToString());

            }
            catch (Exception)
            {
                //log error
                throw;
            }
        }
        public async Task<List<T>> GetListAsync()
        {
            try
            {
                var response = await Client.GetAsync(concreteAddress);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<T>>(content);
                }
                throw new Exception(response.StatusCode.ToString());

            }
            catch (Exception)
            {
                //log error
                throw;
            }
        }
        public async Task<T> AddAsync(T item)
        {
            try
            {
                var response = await Client.PostAsJsonAsync(concreteAddress, item);
                if (response.IsSuccessStatusCode)
                {
                    //TODO get Id for item
                    var content = await response.Content.ReadAsStringAsync();
                    var newItem = JsonConvert.DeserializeObject<T>(content);
                    return item;
                }
                throw new Exception(response.StatusCode.ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> UpdateAsync(T item)
        {
            try
            {
                var response = await Client.PutAsJsonAsync($"{concreteAddress}/{item.Id}", item);
                if (response.IsSuccessStatusCode)
                {
                    //TODO get Id for item
                    return true;
                }
                throw new Exception(response.StatusCode.ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await Client.DeleteAsync($"{concreteAddress}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    //TODO get Id for item
                    return true;
                }
                throw new Exception(response.StatusCode.ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
