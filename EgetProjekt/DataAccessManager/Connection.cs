using EgetProjekt.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace EgetProjekt.DataAccessManager
{
    public class Connection
    {


        private static MongoClient GetClient()
        {
            string connectionString = "mongodb+srv://Majid:AdminMajid99@weightjourney.lbhjpnb.mongodb.net/?retryWrites=true&w=majority";

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var MongoClient = new MongoClient(settings);
            return MongoClient;
        }
        public static IMongoCollection<User> UserCollection()
        {
            var client = GetClient();

            var database = client.GetDatabase("UserDB");

            var userCollection = database.GetCollection<User>("User");

            return userCollection;
        }
    }
}
