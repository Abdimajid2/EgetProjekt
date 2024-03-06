using EgetProjekt.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EgetProjekt.ViewModel
{
    public class StartPageViewModel
    {
        public Models.User TheUser { get; set; }

        public StartPageViewModel()
        {
            var task = Task.Run(() => TheUser = new Models.User());
            task.Wait();
            this.TheUser = task.Result;
        }


        private static MongoClient GetWeights()
        {
            string connectionString = "mongodb+srv://Majid:AdminMajid99@weightjourney.lbhjpnb.mongodb.net/?retryWrites=true&w=majority";

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var MongoClient = new MongoClient(settings);
            return MongoClient;
        }

        public static IMongoCollection<Weight> WeightCollection()
        {
            var client = GetWeights();

            var database = client.GetDatabase("WeightRecord");

            var weightCollection = database.GetCollection<Weight>("Weights");

            return weightCollection;
        }


        public static async Task<List<Models.QuotesApi>> GetQuotes()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-key", "pMoFBo38AoYqb6c2CFIB8g==fN7OdvT6YTG6odWq");


            List<Models.QuotesApi> Quotes = null;

            HttpResponseMessage response = await client.GetAsync("v1/quotes?category=fitness");

            if (response.IsSuccessStatusCode)
            {
                string responsestring = await response.Content.ReadAsStringAsync();
                Quotes = JsonSerializer.Deserialize<List<QuotesApi>>(responsestring);


            }
            return Quotes;

        }

        public static async Task<Models.Weight> getlatestWeight()
        {
            Models.User loggedinuser = Models.User.GetLoggedinUser();

            var weightcollection = WeightCollection();

            if (loggedinuser != null)
            {

                var latestweight = await weightcollection.Find(w => w.userId == loggedinuser.id)
                              .SortByDescending(w => w.WeightRecorded).FirstOrDefaultAsync();

                return latestweight;
            }
            else
            {
                return null;
            }
        }
    }
}
