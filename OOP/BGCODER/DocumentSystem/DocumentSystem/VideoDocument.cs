using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    class VideoDocument : Binary,  IMultimediaDocument
    {
        public string FrameRate { get; protected set; }
        public string Length { get; protected set; }

        public string LengthInSeconds()
        {
            throw new NotImplementedException();
        }
    }
}
