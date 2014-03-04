using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    class ExcelDocument : Binary, IOfficeDocument, IEncryptable
    {
        private bool isEncrypted = false;
        public string Rows { get; protected set; }
        public string Cols { get; protected set; }

        public string Version { get; protected set; }

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
        
    }
}
