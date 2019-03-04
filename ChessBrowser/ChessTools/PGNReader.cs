using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTools
{
    /// <summary>
    /// A utility to parse a pgn file containing chess games.
    /// </summary>
    static public class PGNReader
    {
        /// <summary>
        /// Removes the junk (the first len chars and last two chars) and returns the important element of the tag.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        static private string ParseTag(string line, int len)
        {
            string result;
            result = line.Remove(0, len);
            result = result.Remove(result.Length - 2);
            return result;
        }

        /// <summary>
        /// Takes a pgn file and parses it into a list of chess games.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        static public List<ChessGame> ParseFile(string filename)
        {
            List<ChessGame> result = new List<ChessGame>();
            string eName = "", sName = "", eDate = "", date = "", round = "", wPlayer = "", bPlayer = "", wElo = "", 
                bElo = "", game_result = "", moves = "", ECO = "";
            bool text = false, full_game = false;
            foreach (string line in File.ReadLines(filename, Encoding.UTF8))
            {
                if (line.StartsWith("[Event "))
                    eName = ParseTag(line, 8);
                else if (line.StartsWith("[Site "))
                    sName = ParseTag(line, 7);
                else if (line.StartsWith("[Date "))
                    date = ParseTag(line, 7);
                else if (line.StartsWith("[Round "))
                    eName = ParseTag(line, 8);
                else if (line.StartsWith("[White "))
                    wPlayer = ParseTag(line, 8);
                else if (line.StartsWith("[Black "))
                    bPlayer = ParseTag(line, 8);
                else if (line.StartsWith("[WhiteElo "))
                    wElo = ParseTag(line, 11);
                else if (line.StartsWith("[BlackElo "))
                    bElo = ParseTag(line, 11);
                else if (line.StartsWith("[ECO "))
                    ECO = ParseTag(line, 6);
                else if (line.StartsWith("[EventDate "))
                    eDate = ParseTag(line, 12);
                else if (line.StartsWith("[Result "))
                    game_result = ParseTag(line, 9);
                else if (line.StartsWith("[Round "))
                    round = ParseTag(line, 9);
                else if (line.Equals("\n"))
                {
                    if (text)
                    {
                        text = false;
                        full_game = true;
                    }
                    else
                    {
                        text = true;
                        full_game = false;
                    }
                }
                else if (text)
                    moves += line;
                else if (full_game && !text)
                {
                    result.Add(new ChessGame(eName, sName, date, round, wPlayer, bPlayer, game_result, wElo, bElo, ECO, eDate, moves));
                    moves = "";
                }
            }
            return result;
        }
    }
}
