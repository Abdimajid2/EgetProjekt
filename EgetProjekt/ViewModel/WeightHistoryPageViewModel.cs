using EgetProjekt.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgetProjekt.ViewModel
{
    internal class WeightHistoryPageViewModel
    {
        public List<Models.Weight> TheWeights { get; set; }

        public WeightHistoryPageViewModel()
        {
           var task = Task.Run(() => getlatestWeightsAsync());
            task.Wait();
            TheWeights = task.Result;
        }

        public static async Task<List<Models.Weight>> getlatestWeightsAsync()
        {
            Models.User loggedinuser = Models.User.GetLoggedinUser();

            var weightcollection = StartPageViewModel.WeightCollection();

            if (loggedinuser != null)
            {
  
                var latestweight = await weightcollection.Find(w => w.userId == loggedinuser.id)
                              .SortByDescending(w => w.WeightRecorded).ToListAsync();

                return latestweight;
            }
            else
            {
                return null;
            }
        } 
    }
}
