using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    class PDFDocument : Binary, IEncryptable
    {
        public string Pages { get; protected set; }

        private bool isEncrypted = false;
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
    }
}
