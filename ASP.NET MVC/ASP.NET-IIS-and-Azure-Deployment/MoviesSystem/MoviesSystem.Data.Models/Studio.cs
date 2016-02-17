namespace MoviesSystem.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Studio
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Index(IsUnique = true)]
        [DisplayName("Studio name")]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}