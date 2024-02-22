using EgetProjekt.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgetProjekt.ViewModel
{
   public  class LogInValidation
    {
        public async Task<Models.User> CheckLoginInformation(string email, string password)
        {
            var usercollection = Connection.UserCollection();

            var user = await usercollection.Find(u => u.Email == email).FirstOrDefaultAsync();

            if(user != null && user.Password == password)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
