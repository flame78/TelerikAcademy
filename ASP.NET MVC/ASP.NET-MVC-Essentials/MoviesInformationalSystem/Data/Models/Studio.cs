using System.ComponentModel.DataAnnotations;

namespace MoviesInformationalSystem.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Studio
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Index("IX_Name", 1, IsUnique = true)]
        [DisplayName("Studio name")]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}