using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgetProjekt.Models
{
   public class User
    {
        public Guid id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime BirthYear { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }


    }

       
}
