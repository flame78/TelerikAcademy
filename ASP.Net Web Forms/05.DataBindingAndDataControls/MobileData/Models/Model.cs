using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileData.Models
{
    public class Model
    {
        public string Name { get; set; }

        public EngineType Engine { get; set; }

        public List<Extra> Features { get; set; }

        public int BasePrice { get; set; }
    }
}
