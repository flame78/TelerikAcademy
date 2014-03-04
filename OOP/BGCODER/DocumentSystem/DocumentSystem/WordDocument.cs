using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    class WordDocument : Binary, IOfficeDocument, IEncryptable, IEditable
    {
        public string Chars { get; protected set; }
        public string Version { get; protected set; }
       
        private bool isEncrypted = false;


        string IOfficeDocument.Version()
        {
            throw new NotImplementedException();
        }
        public bool IsEncrypted
        {
            get { return this.isEncrypted; }
        }

        public void Encrypt()
        {
            this.isEncrypted = true;
        }

        public void Decrypt()
        {
            
            this.isEncrypted = false;
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
