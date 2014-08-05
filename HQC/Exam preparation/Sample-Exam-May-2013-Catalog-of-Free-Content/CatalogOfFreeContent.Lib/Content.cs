namespace CatalogOfFreeContent.Lib
{
    using System;

    using CatalogOfFreeContent.Lib.Enumerations;

    public class Content : IComparable, IContent
    {
        private string url;

        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ContentData.Title];
            this.Author = commandParams[(int)ContentData.Author];
            this.Size = long.Parse(commandParams[(int)ContentData.Size]);
            this.URL = commandParams[(int)ContentData.Url];
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        public ContentType Type { get; set; }

        public string TextRepresentation { get; set; }

        public string URL
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString(); // To update the text representation
            }
        }

        public int CompareTo(object obj)
        {
            if (null == obj)
            {
                return 1;
            }

            var otherContent = obj as Content;
            if (otherContent != null)
            {
                var comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResul;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            var output = string.Format(
                "{0}: {1}; {2}; {3}; {4}", 
                this.Type, 
                this.Title, 
                this.Author, 
                this.Size, 
                this.URL);

            return output;
        }
    }
}