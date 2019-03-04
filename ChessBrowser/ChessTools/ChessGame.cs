using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTools
{
    /// <summary>
    /// A representation of a chess game.
    /// </summary>
    public class ChessGame
    {
        public ChessGame(string eName, string sName, string date, string round, string wPlayer, string bPlayer, 
            string game_result, string wElo, string bElo, string ECO, string eDate, string text)
        {
            this.EventName = eName;
            this.SiteName = sName;
            this.Date = date;
            this.Round = round;
            this.WhitePlayer = wPlayer;
            this.BlackPlayer = bPlayer;
            this.Result = game_result;
            this.WhiteElo = wElo;
            this.BlackElo = bElo;
            this.ECO = ECO;
            this.EventDate = eDate;
            this.Moves = text;
        }

        /// <summary>
        /// The name of the event.
        /// </summary>
        public string EventName { get; private set; }

        /// <summary>
        /// The name of the site where the event is held.
        /// </summary>
        public string SiteName { get; private set; }

        /// <summary>
        /// The other date.
        /// </summary>
        public string Date { get; private set; }

        /// <summary>
        /// The round.
        /// </summary>
        public string Round { get; private set; }

        /// <summary>
        /// The name of the player playing as white.
        /// </summary>
        public string WhitePlayer { get; private set; }

        /// <summary>
        /// The name of the player playing as black.
        /// </summary>
        public string BlackPlayer { get; private set; }

        /// <summary>
        /// The result of the game.
        /// </summary>
        public string Result { get; private set; }

        /// <summary>
        /// The elo rating of the player playing as white.
        /// </summary>
        public string WhiteElo { get; private set; }

        /// <summary>
        /// The elo rating of the player playing as black.
        /// </summary>
        public string BlackElo { get; private set; }

        /// <summary>
        /// The ECO.
        /// </summary>
        public string ECO { get; private set; }

        /// <summary>
        /// The date the event is held.
        /// </summary>
        public string EventDate { get; private set; }

        /// <summary>
        /// The moves made in the game.
        /// </summary>
        public string Moves { get; private set; }
    }
}
