using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace VideoGameListApp.Models
{
    class RandomPersonRepository
    {
        private readonly HttpClient _httpClient;
        public RandomPersonRepository()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://randomuser.me/api/") };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public RUser GetSingleDummyUser()
        {
            var user = new RUser();
            HttpResponseMessage response = _httpClient.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                RootObject rObj = JsonConvert.DeserializeObject<RootObject>(content);
                user = rObj.results[0];
            }
            return user;
        }
    }
}


