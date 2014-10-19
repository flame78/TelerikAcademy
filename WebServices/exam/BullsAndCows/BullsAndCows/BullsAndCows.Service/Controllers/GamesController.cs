using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BullsAndCows.Service.Controllers
{
    using BullsAndCows.Models;
    using BullsAndCows.Service.DataModels;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class GamesController : BaseApiController
    {
        private const int PageSize = 10;


        [HttpPost]
        public IHttpActionResult Guess(int id, NumberModel guess)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("number is incorrect");
            }

            string number = guess.Number;

            if (this.NumberIsNotValid(number))
            {
                return this.BadRequest("number is incorrect");
            }

            var game = this.Data.Games.All().FirstOrDefault(g => g.Id == id);

            if (game == null)
            {
                return this.BadRequest("Game Not Found");
            }

            if (game.GameState == GameState.Finished)
            {
                return this.BadRequest("Game is finished");
            }

            if (game.GameState == GameState.WaitingForOpponent)
            {
                return this.BadRequest("Game not started");
            }

            if (game.RedPlayerId != userId && game.BluePlayerId !=userId)
            {
                return this.BadRequest("You not a part of the game");
            }

            // Red Player in turn
            if (game.GameState == GameState.RedInTurn && game.RedPlayerId==userId)
            {
                
                var result = CountBullsAndCows(game.BluePlayerNumber, number);
                var newGuess = new Guess
                                   {
                                       GameId = game.Id, Number = number, UserId = userId, User = user,
                                       BullsCount = result[0],
                                       CowsCount = result[1]
                                   };

                this.Data.Guesses.Add(newGuess);
                var oponent = this.Data.Users.Find(game.BluePlayerId);
                // if find 4 bulls game finish
                if (result[0] == 4)
                {
                    game.GameState = GameState.Finished;
                    user.Wons = user.Wons + 1;
                    oponent.Loses = oponent.Loses + 1;
                    oponent.Notifications.Add(new Notifaction
                    {
                        Content = "Your lose game with ID" + game.Id,
                    });
                    user.Notifications.Add(new Notifaction { Content = "Your win game with ID" + game.Id });
                }
                else
                {
                    game.GameState = GameState.BlueInTurn;
                    oponent.Notifications.Add(new Notifaction
                    {
                        Content = "Is your turn in game with ID" + game.Id,
                    });
                }

                this.Data.Users.Update(user);
                this.Data.Users.Update(oponent);
                this.Data.Games.Update(game);
                
                this.Data.SaveChanges();

                return this.Ok(GuessViewModel.FromGuess(newGuess));
            } 
                // Blue Player in turn
            else  if (game.GameState == GameState.BlueInTurn && game.BluePlayerId==userId)
            {
                
                var result = CountBullsAndCows(game.RedPlayerNumber, number);
                var newGuess = new Guess
                                   {
                                       GameId = game.Id, Number = number, UserId = userId, User = user,
                                       BullsCount = result[0],
                                       CowsCount = result[1]
                                   };

                this.Data.Guesses.Add(newGuess);
                var oponent = this.Data.Users.Find(game.RedPlayerId);
                // if find 4 bulls game finish
                if (result[0] == 4)
                {
                    game.GameState = GameState.Finished;
                    user.Wons = user.Wons + 1;
                    oponent.Loses = oponent.Loses + 1;
                    oponent.Notifications.Add(new Notifaction
                    {
                        Content = "Your lose game with ID" + game.Id,
                    });
                    user.Notifications.Add(new Notifaction { Content = "Your win game with ID" + game.Id });
                }
                else
                {
                    game.GameState = GameState.RedInTurn;
                    oponent.Notifications.Add(new Notifaction
                    {
                        Content = "Is your turn in game with ID" + game.Id,
                    });
                }

                this.Data.Users.Update(user);
                this.Data.Users.Update(oponent);
                this.Data.Games.Update(game);
                
                this.Data.SaveChanges();

                return this.Ok(GuessViewModel.FromGuess(newGuess));
            }
            return this.BadRequest("Is not your turn");
        }
       
        [HttpPut]
        public IHttpActionResult WithId(int id, NumberModel gameJoinModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("number is incorrect");
            }

            string number = gameJoinModel.Number;

            var game = this.Data.Games.All().FirstOrDefault(g => g.Id == id);

            if (game == null)
            {
                return this.BadRequest("Game Not Found");
            }

            if (game.RedPlayerId == this.User.Identity.GetUserId())
            {
                return this.BadRequest("Cant join this game your are red player");
            }
            if (this.NumberIsNotValid(number))
            {
                return this.BadRequest("number is incorrect");
            }

            if (game.GameState != GameState.WaitingForOpponent)
            {
                return this.BadRequest("Game not waiting for opponent");
            }

            game.BluePlayer = this.Data.Users.Find(this.User.Identity.GetUserId());
            game.BluePlayerId = this.User.Identity.GetUserId();
            game.BluePlayerNumber = number;
            game.GameState = GameState.RedInTurn;

            this.Data.Games.Update(game);
            this.Data.SaveChanges();

            return this.Ok(
                new { result = "You joined game \"" + game.Name + "\"" });
        }

        [HttpGet]
        public IHttpActionResult WithId(int id)
        {
            var userId = this.User.Identity.GetUserId();

            var game = this.Data.Games.All().FirstOrDefault(g => g.Id == id);

            if (game == null) return this.BadRequest("Game Not Found");

            if (game.BluePlayerId != userId && game.RedPlayerId != userId)
            {
                return this.BadRequest("You not part of this game");
            }

            string oponentId;
            string yourNumber;
            string yourColor;
            if (userId == game.RedPlayerId)
            {
                oponentId = game.BluePlayerId;
                yourNumber = game.RedPlayerNumber;
                yourColor = "red";
            }
            else
            {
                oponentId = game.RedPlayerId;
                yourNumber = game.BluePlayerNumber;
                yourColor = "blue";
            }

            var view =
                new
                    {
                        Id = game.Id,
                        Name = game.Name,
                        DateCreated = game.DateCreated,
                        Red = game.RedPlayer.UserName,
                        Blue = game.BluePlayer != null ? game.BluePlayer.UserName : "No blue player yet",
                        YourNumber = yourNumber,
                        YourGuesses =
                            this.Data.Guesses.All()
                                .Where(g => g.GameId == game.Id && g.UserId == userId)
                                .OrderBy(g => g.DateMade)
                                .Select(GuessViewModel.FromGuessAsExpression),
                        OpponentGuesses =
                            (oponentId == null
                                 ? null
                                 : this.Data.Guesses.All()
                                       .Where(g => g.GameId == game.Id && g.UserId == oponentId)
                                       .OrderBy(g => g.DateMade)
                                       .Select(GuessViewModel.FromGuessAsExpression)),
                        YourColor = yourColor,
                        GameState = game.GameState.ToString(),

                    };
            return this.Ok(view);
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.GetByPage(0);
            }
            return GetByPageAnonymous(0);
        }

        //api/games?page=P
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Get(int page)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.GetByPage(page);
            }
            return GetByPageAnonymous(page);
        }

        [HttpPost]
        public IHttpActionResult Post(GameCreateModel gameCreateModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (NumberIsNotValid(gameCreateModel.Number))
            {
                return this.BadRequest("Invalid Number");
            }

            var user = this.Data.Users.Find(this.User.Identity.GetUserId());

            var newGame = new Game
                                       {
                                           Name = gameCreateModel.Name,
                                           GameState = GameState.WaitingForOpponent,
                                           RedPlayerNumber = gameCreateModel.Number,
                                           RedPlayer = user,
                                           RedPlayerId = user.Id
                                       };
            this.Data.Games.Add(newGame);
            this.Data.SaveChanges();

            return this.Created("", GameViewModel.FromGame(newGame));
        }

        private static int[] CountBullsAndCows(string number, string guess)
        {
            var result = new int[]{0,0}; // [0] bulls, [1] cows
            var digitsNumber = new bool[10];
            var digitsGuess = new bool[10];

            // CheckForBulls
            for (int i = 0; i < 4; i++)
            {
                if (number[i] == guess[i])
                {
                    result[0]++;
                }
                else
                {
                // if not Bull mark digit to check for cows
                var n = number[i] - 48;
                var g = guess[i] - 48;
                digitsNumber[n] = true;
                digitsGuess[g] = true;
                }

            }

            // Check for Cows
            for (int i = 0; i < 10; i++)
            {
                if (digitsGuess[i] == true && digitsNumber[i] == true) result[1]++;
            }

            return result;
        }

        private IHttpActionResult GetByPage(int page)
        {
            var userId = this.User.Identity.GetUserId();

            return this.Ok(
                this.Data.Games
                .All()
                .Where(g => g.RedPlayerId == userId || g.BluePlayerId == userId || g.GameState == GameState.WaitingForOpponent)
                .Where(g => g.GameState != GameState.Finished)
                .OrderBy(g => g.GameState)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName)
                .Skip(page * PageSize)
                .Take(PageSize)
                .Select(GameViewModel.FromGameAsExpression));
        }

        private IHttpActionResult GetByPageAnonymous(int page)
        {
            return this.Ok(
                   this.Data.Games
                   .All()
                   .Where(g => g.GameState == GameState.WaitingForOpponent)
                   .OrderBy(g => g.Name)
                   .ThenBy(g => g.DateCreated)
                   .ThenBy(g => g.RedPlayer.UserName)
                   .Skip(page * PageSize)
                   .Take(PageSize)
                   .Select(GameViewModel.FromGameAsExpression));
        }

        private bool NumberIsNotValid(string number)
        {
            if (number.Trim().Length != 4) return true;

            var digits = new bool[10];


            for (int i = 0; i < 4; i++)
            {
                var a = number[i] - 48;
                if (digits[a] == true) return true;
                digits[a] = true;
            }
            return false;
        }
    }
}
