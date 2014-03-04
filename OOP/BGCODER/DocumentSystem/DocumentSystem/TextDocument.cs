using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    class TextDocument : Document, IEditable
    {
        public string Charset { get; protected set; }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
