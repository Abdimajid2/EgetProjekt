using EgetProjekt.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
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
        public static IMongoCollection<Weight>WeightCollection()
        {
            var client = GetWeights();

            var database = client.GetDatabase("WeightRecord");

            var weightCollection = database.GetCollection<Weight>("Weights");

            return weightCollection;
        }

    }
}
