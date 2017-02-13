using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Model
{
    public class Game
    {
        public Game(Interfaces.IPlayer Player1, Interfaces.IPlayer Player2)
        {
            this.Player1 = Player1;
            this.Player2 = Player2;
            _players = new List<Interfaces.IPlayer>() {Player1,Player2};
        }
        public Interfaces.IPlayer GameWinner { get; private set; }
        public Interfaces.IPlayer Player1{ get; set; }
        public Interfaces.IPlayer Player2 { get; set; }
        private List<Interfaces.IPlayer> _players;

        public void PlayGame(){

            Console.WriteLine("             " + Player1.Name + " VS. " + Player2.Name);
            int roundCount = 1;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
                Console.WriteLine("                 ROUND " + roundCount);
                Round oneRound = new Round(_players);
                oneRound.PlayRound();
                roundCount++;
                Console.WriteLine();
            }//play 5 rounds
            while (_players[0].GameScore == _players[1].GameScore)//play extra rounds until someone wins
            {
                Console.WriteLine();
                Console.WriteLine("                 ROUND " + roundCount);
                Round oneRound = new Round(_players);
                oneRound.PlayRound();
                roundCount++;
                Console.WriteLine();
            }
            GameWinner = _players[GetWinner(_players)]; //set the gamewinner
            _players[GetWinner(_players)].TournamentScore++; //add one point to the winner of the game
            ResetGameScore();//reset the game score for the players of the game

        }

        private int GetWinner(List<Interfaces.IPlayer> _playersList)
        {
            return _playersList[0].GameScore > _playersList[1].GameScore ? 0 : 1;
        }
        private void ResetGameScore()
        {
            foreach (var player in _players)
            {
                player.GameScore = 0;
            }
        }

    }
}
