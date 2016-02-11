namespace Twitter.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        public Tag()
        {
            this.Tweets = new HashSet<Tweet>();
        }
        
        [Key]
        public string Name { get; set; }

        public virtual ICollection<Tweet> Tweets  { get; set; }
    }
}