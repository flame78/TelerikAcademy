using System;

namespace TodoList.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime LastChange { get; set; }

        public string OwnerID { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}