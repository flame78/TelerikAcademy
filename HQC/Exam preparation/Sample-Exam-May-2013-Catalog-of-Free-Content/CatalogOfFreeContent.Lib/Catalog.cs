namespace CatalogOfFreeContent.Lib
{
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class Catalog : ICatalog
    {
        private readonly OrderedMultiDictionary<string, IContent> title;

        private readonly MultiDictionary<string, IContent> url;

        public Catalog()
        {
            var allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            var contentToList = from c in this.title[title] select c;

            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string old, string newUrl)
        {
            var theElements = 0;

            var contentToList = this.url[old].ToList();

            foreach (Content content in contentToList)
            {
                this.title.Remove(content.Title, content);
                theElements++; // increase updatedElements
            }

            this.url.Remove(old);

            foreach (var content in contentToList)
            {
                content.URL = newUrl;
            }

            // again
            foreach (var content in contentToList)
            {
                this.title.Add(content.Title, content);
                this.url.Add(content.URL, content);
            }

            return theElements;
        }
    }
}