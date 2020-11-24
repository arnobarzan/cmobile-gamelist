using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace VideoGameListApp.Models
{
    public class MyAppRepository
    {
        private readonly HttpClient _httpClient;
        public MyAppRepository()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://10.0.2.2:52700/") };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public List<Gebruiker> GetGebruikers()
        {
            List<Gebruiker> gebruikers = new List<Gebruiker>();
            HttpResponseMessage response = _httpClient.GetAsync("WpfGebruiker/GetGebruikers").Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                gebruikers = JsonConvert.DeserializeObject<List<Gebruiker>>(content);
            }
            return gebruikers;
        }
    }
}
