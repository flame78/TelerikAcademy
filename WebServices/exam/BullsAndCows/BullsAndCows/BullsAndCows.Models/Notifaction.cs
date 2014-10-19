using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Models
{
    using System.CodeDom;
    using System.IO;

    public class Notifaction
    {
        public Notifaction()
        {
            this.Readed = false;
        }

        public int Id { get; set; }

    public string Content { get; set; }

        public bool Readed { get; set; }
    }
}
