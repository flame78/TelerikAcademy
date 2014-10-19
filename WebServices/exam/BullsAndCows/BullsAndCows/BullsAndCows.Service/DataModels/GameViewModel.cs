using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCows.Service.DataModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq.Expressions;

    using BullsAndCows.Models;

    using Microsoft.Ajax.Utilities;

    public class GameViewModel
    {

        public static Expression<Func<Game, GameViewModel>> FromGameAsExpression
        {
            get
            {
                return
                    game =>
                    new GameViewModel
                        {
                            Id = game.Id,
                            Name = game.Name,
                            Blue = game.BluePlayer != null ? game.BluePlayer.UserName : "No blue player yet",
                            Red = game.RedPlayer.UserName,
                            GameState = game.GameState.ToString(),
                            DateCreated = game.DateCreated
                        };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; private set; }

        public static GameViewModel FromGame(Game game)
        {
            return new GameViewModel
                       {
                           Id = game.Id,
                           Name = game.Name,
                           Blue = game.BluePlayer!=null ? game.BluePlayer.UserName : "No blue player yet",
                           Red = game.RedPlayer.UserName,
                           GameState =  game.GameState.ToString(),
                           DateCreated = game.DateCreated
                       };
        }
    }
}