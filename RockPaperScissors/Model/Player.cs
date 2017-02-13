using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Model
{
    public class Player : Interfaces.IPlayer
    {
        public Player(string Name)
        {
            this.Name = Name;
            GameScore = 0;
            TournamentScore = 0;
        }
        public string Name {get; set;}
        public int LastChoice { get; set; }
        public int GameScore { get; set; }
        public int TournamentScore { get; set; }
        public void MakeChoice()
        {
            int choice = Convert.ToInt32((Console.ReadKey(true).KeyChar.ToString())) - 1;
            LastChoice = choice;
        }
    }
}
