using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCows.Service.DataModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using BullsAndCows.Models;

    using Microsoft.Ajax.Utilities;

    public class GuessViewModel
    {

      
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int GameId { get; set; }

        public string Number { get; set; }

        public DateTime DateCreated { get; private set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }

        public static Expression<Func<Guess, GuessViewModel>> FromGuessAsExpression
        {
            get
            {
                return
                    g =>
                    new GuessViewModel
                    {
                        Id = g.Id,
                        UserId = g.UserId,
                        UserName = g.User.UserName,
                        GameId = g.GameId,
                        Number = g.Number,
                        DateCreated = g.DateMade,
                        CowsCount = g.CowsCount,
                        BullsCount = g.BullsCount
                    };
            }
        }

        public static GuessViewModel FromGuess(Guess g)
        {
            return new GuessViewModel
                    {
                        Id = g.Id,
                        UserId = g.UserId,
                        UserName = g.User.UserName,
                        GameId = g.GameId,
                        Number = g.Number,
                        DateCreated = g.DateMade,
                        CowsCount = g.CowsCount,
                        BullsCount = g.BullsCount
                    };
        }
    }
}