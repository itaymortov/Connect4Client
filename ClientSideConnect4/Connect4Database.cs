using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSideConnect4
{
    class Connect4Database
    {

        private UsersDataContext dataContext;

        public Connect4Database()
        {
            dataContext = new UsersDataContext();
        }
        public Table<Game> Games => dataContext.GetTable<Game>();
        public Table<Move> Moves => dataContext.GetTable<Move>();

        public void AddGame(int gameId, int playerId)
        {
            var newGame = new Game { GameID = gameId, PlayerID = playerId };
            Games.InsertOnSubmit(newGame);
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }


        }
        public void AddMove(int gameId, int col, int moveNum, bool isPlayer)
        {

            var newMove = new Move { MoveNum = moveNum, Column = col, isPlayer = isPlayer, GameID = gameId };
            Moves.InsertOnSubmit(newMove);
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

        }

        public List<Game> GetGamesByPlayerId(int playerId)
        {
            return Games.Where(game => game.PlayerID == playerId).ToList();
        }
        public List<Move> GetMoveListByGameID(int gameID)
        {
            return Moves.Where(move => move.GameID == gameID)
                .OrderBy(move => move.MoveNum)
                .ToList();
        }
    }
}   