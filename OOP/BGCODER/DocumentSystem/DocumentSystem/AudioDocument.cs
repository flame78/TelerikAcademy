using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    class AudioDocument : Binary, IMultimediaDocument
    {
        public string SampleRate { get; protected set; }
        public string Length{get; protected set;}
        public string LengthInSeconds()
        {
            return this.Length;
        }

        
       //public AudioDocument(string name) : base(name) { }
        
    }
}
