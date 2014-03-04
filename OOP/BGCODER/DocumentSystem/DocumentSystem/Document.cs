using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    abstract class Document : IDocument
    {
        private string name;
        public string Content { get; protected set; }
        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (this.name == null || this.name == "")
                    this.name = value;
            }
        }
        public void LoadProperty(string key, string value)
        {
            foreach (var item in this.GetType().GetProperties())
            {
                if (item.Name.ToString().ToLower() == key)
                    item.SetValue(this, value);
            }
        }


        //public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        //{
        //    throw new NotImplementedException();
        //}
        public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            foreach (var property in this.GetType().GetProperties())
            {
                output.Add(new KeyValuePair<string, object>(property.Name.ToLowerInvariant(), property));
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            bool notEncrypted = true;

            result.Append(this.GetType().Name);
            result.Append('[');

            var properties = this.GetType().GetProperties().OrderBy(x => x.Name.ToString());

            if (this is IEncryptable)
            {
                var doc = this as IEncryptable;
                if (doc.IsEncrypted)
                {
                    result.Append("encrypted");
                    result.Append(']');
                    notEncrypted=false;
                }

            }
            
            if (notEncrypted)
                foreach (var item in properties)
                {

                    if (item.GetValue(this) != null)
                        if (!(item.GetValue(this) is Boolean))
                        {
                            result.Append(item.Name.ToString().ToLower());
                            result.Append('=');
                            result.Append(item.GetValue(this).ToString());
                            result.Append(';');
                        }

                }

                result[result.Length - 1] = ']';
            

            return result.ToString();
        }
    }
}
