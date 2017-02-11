using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class Controller
    {
        private static readonly Controller instance = new Controller();
        List<Interfaces.IPlayer> _PlayersList;
        static Controller()
        {
            //empty constructor
        }
        private Controller()
        {
            //constructor
            _PlayersList = new List<Interfaces.IPlayer>();
        }

        public static Controller Instance
        {
            get
            {
                return instance;
            }
        }

        public string StartGame()
        {
            string returnVariable = "";
            Model.Player Winner;
            foreach (Model.Player player in _PlayersList)
            {
                Console.WriteLine(player.Name + ", choose: 1 - rocks, 2 - paper, 3 - scissors");
                int answer = Convert.ToInt32((Console.ReadKey(true).KeyChar.ToString())) - 1;
               
                player.MakeChoice(answer);
            }
            //logic

            int result = Constants.gameRules[_PlayersList[0].LastChoice][_PlayersList[1].LastChoice];
            if (result ==Constants.TIE)
            {
                returnVariable = "It's a tie!";
            }
            else if (result == Constants.LOSE)
            {
                Winner = (Model.Player)_PlayersList[1];
                returnVariable = Winner.Name + " wins. Congrats!";
            }
            else if (result == Constants.WIN)
            {
                Winner = (Model.Player)_PlayersList[0];
                returnVariable = Winner.Name + " wins. Congrats!";
            }
            //logic
            //if (_PlayersList[0].LastChoice == Constants.ROCK)
            //{
            //    if (_PlayersList[1].LastChoice == Constants.PAPER)
            //    {
            //        Winner = (Model.Player)_PlayersList[1];
            //        returnVariable = Winner.Name + " wins. Congrats!";
            //    }
            //    else if (_PlayersList[1].LastChoice == Constants.SCISSOR)
            //    {
            //        Winner = (Model.Player)_PlayersList[0];
            //        returnVariable = Winner.Name + " wins. Congrats!";
            //    }
            //    else if (_PlayersList[1].LastChoice == Constants.ROCK)
            //    {
            //        returnVariable = "It's a tie!";
            //    }  
            //}
            //else if (_PlayersList[0].LastChoice == Constants.PAPER)
            //{
            //    if (_PlayersList[1].LastChoice == Constants.PAPER)
            //    {
            //        returnVariable = "It's a tie!";
            //    }
            //    else if (_PlayersList[1].LastChoice == Constants.SCISSOR)
            //    {
            //        Winner = (Model.Player)_PlayersList[1];
            //        returnVariable = Winner.Name + " wins. Congrats!";
            //    }
            //    else if (_PlayersList[1].LastChoice == Constants.ROCK)
            //    {
            //        Winner = (Model.Player)_PlayersList[0];
            //        returnVariable = Winner.Name + " wins. Congrats!";
            //    }
            //}
            //else if (_PlayersList[0].LastChoice == Constants.SCISSOR)
            //{
            //    if (_PlayersList[1].LastChoice == Constants.PAPER)
            //    {
            //        Winner = (Model.Player)_PlayersList[0];
            //        returnVariable = Winner.Name + " wins. Congrats!";
            //    }
            //    else if (_PlayersList[1].LastChoice == Constants.SCISSOR)
            //    {
            //        returnVariable = "It's a tie!";
                    
            //    }
            //    else if (_PlayersList[1].LastChoice == Constants.ROCK)
            //    {
            //        Winner = (Model.Player)_PlayersList[1];
            //        returnVariable = Winner.Name + " wins. Congrats!";
            //    }
            //}
            return returnVariable;

            
        }
        public void SetName(string Name)
        {
            CreatePlayer(Name);
        }
        private void CreatePlayer(string Name)
        {
            Model.Player player = new Model.Player(Name);

            _PlayersList.Add(player);
        }

        public bool CanIPlay()
        {
            return (_PlayersList.Count == 2)? true: false;
        }

        public void ResetListOfPlayers()
        {
            _PlayersList.Clear();
        }
    }
}
