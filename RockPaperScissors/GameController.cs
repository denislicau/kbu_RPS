using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class GameController
    {
        private static readonly GameController instance = new GameController();
        List<Interfaces.IPlayer> _PlayersList;
        static GameController()
        {
            //empty constructor
        }
        private GameController()
        {
            //constructor
            _PlayersList = new List<Interfaces.IPlayer>();
        }

        public static GameController Instance
        {
            get
            {
                return instance;
            }
        }

        
        public void StartGame()
        {
            //play all games, based on the number of players
            for (int i = 0; i < _PlayersList.Count; i++)
            {
                for (int j = 0; j < _PlayersList.Count; j++)
                {
                    if (i<j)
                    {
                        Model.Game oneGame = new Model.Game(_PlayersList[i], _PlayersList[j]);
                        oneGame.PlayGame();

                        Console.WriteLine("The winner is: " + oneGame.GameWinner.Name);
                    }
                }
            }
        }

        
        public void AddPlayerToRuntimeList(Interfaces.IPlayer player)
        {   
            _PlayersList.Add(player);
        }

      
        public void ResetListOfPlayers()
        {
            _PlayersList.Clear();
        }

        public void WriteTournamentScoreBoard()
        {
            Console.WriteLine("                 SCORE BOARD:");
            Console.WriteLine();
            _PlayersList = _PlayersList.OrderByDescending(player => player.TournamentScore).ToList();
            for (int i = 0; i < _PlayersList.Count; i++)
            {
                Console.WriteLine("     "+(i+1)+". "+_PlayersList[i].Name+"     "+_PlayersList[i].TournamentScore);
            }
        }
    }
}
