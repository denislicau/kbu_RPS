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
        }
        public string Name {get; set;}
        public int LastChoice { get; set; }
        public void MakeChoice(int choice)
        {
            LastChoice = choice;
        }
    }
}
