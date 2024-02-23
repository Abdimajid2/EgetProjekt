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
        public Models.User TheUser { get; set; }

        public StartPageViewModel()
        {
          var task = Task.Run(() => TheUser = new Models.User());
            task.Wait();
            this.TheUser = task.Result;
        }

        

        
    }
}
