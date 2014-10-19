namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.AccessControl;

    public class Game
    {

        //private ICollection<Article> articles;

        public Game()
        {
            this.DateCreated = DateTime.Now;
        }

        //"Id": 5,
        //"Name": "Battle of the titans",
        //"Blue": "No blue player yet",
        //"Red": "doncho@minkov.it",
        //"GameState": "WaitingForOpponent",
        //"DateCreated": "2014-09-22T14:31:51.067"

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string RedPlayerId { get; set; }

        public virtual  User RedPlayer { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        public string RedPlayerNumber { get; set; }

        public string BluePlayerId { get; set; }

        public virtual User BluePlayer { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        public string BluePlayerNumber { get; set; }

        public DateTime DateCreated { get; private set; }

        public GameState GameState { get; set; }

        //public string StateToString()
        //{
        //    var states = new string[] { "WaitingForOpponent", "Finished", "RedPlayerTurn", "BluePlayerTurn" };

        //    return states[(int)this.GameState];
        //}
        //public virtual ICollection<Article> Articles
        //{
        //    get
        //    {
        //        return this.articles;
        //    }
        //    set
        //    {
        //        this.articles = value;
        //    }
        //}
    }
}
