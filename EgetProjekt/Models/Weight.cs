using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgetProjekt.Models
{
    public class Weight
    {
        public Guid id { get; set; }

        public Guid userId { get; set; }

        public int NewWeight { get; set; }

        public DateTime WeightRecorded { get; set; }
    }
}
