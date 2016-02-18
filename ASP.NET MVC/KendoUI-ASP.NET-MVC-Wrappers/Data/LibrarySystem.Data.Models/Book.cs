namespace LibrarySystem.Data.Models
{
    using LibrarySystem.Data.Common.Models;

    public class Book : BaseModel<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public string WebSite { get; set; }

        public string Author { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
