using EgetProjekt.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgetProjekt.ViewModel
{
    public class StartPageViewModel
    {
        public string Welcomemessage { get; set; }

        public StartPageViewModel()
        {
          
        }

        //Här vill jag kunna updatera firstname baserat på vem som är inloggad
        //public async Task<User> GetLoggenInUser()
        //{
        //    var usercollection = Connection.UserCollection();
        //    User loggedinuser = await usercollection.Find(u => u.Is).FirstOrDefaultAsync();
        //     return loggedinuser;
        //}

        //identfierar användaren som är inloggad
        public async Task<string> GetWelcomeMessage(string loggedinuserId)
        {
            // omvandlar stringen till guid
            if(!Guid.TryParse(loggedinuserId, out Guid userid))
            {
                return null;
            }

            var usercollection = Connection.UserCollection();

            var loggediuser = await usercollection.Find(u => u.id == userid).FirstOrDefaultAsync();

            if(loggediuser != null)
            {
                return $"WELCOME, {loggediuser.FirstName}";
            }
            else
            {
                return string.Empty;
            }
        }

        
    }
}
