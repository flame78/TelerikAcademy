namespace BullsAndCows.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Security.AccessControl;

    public class Guess
    {
        public Guess()
        {
            this.DateMade = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string Number { get; set; }

        public DateTime DateMade { get; private set; }

        [Required]
        public int CowsCount { get; set; }

        [Required]
        public int BullsCount { get; set; }

    }
}
