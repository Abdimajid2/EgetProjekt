using EgetProjekt.DataAccessManager;
using EgetProjekt.ViewModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgetProjekt.Logic
{
    public class LogInValidation
    {
        public static async Task<Models.User> CheckLoginInformation(string email, string password)
        {
            var usercollection = Connection.UserCollection();

            var user = await usercollection.Find(u => u.Email == email).FirstOrDefaultAsync();

            if (user != null && user.Password == password)
            {
                Models.User.SetLoggedInUser(user);
                return user;
            }
            else
            {
                return null;
            }

        } 
        
        //public static async Task<List<Models.Weight>> getlatestWeight(string email, string password)
        //{
             
        //    var usercollection = Connection.UserCollection();

        //    var user = await CheckLoginInformation(email, password);

        //    if (user != null )
        //    {
        //        var weightcollection = StartPageViewModel.WeightCollection();
        //        var latestweight = await weightcollection.Find(w => w.userId == user.id)
        //                      .SortByDescending(w => w.WeightRecorded).ToListAsync();
                
        //        return latestweight;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}



        
    }
}
