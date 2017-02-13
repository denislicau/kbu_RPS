using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        int LastChoice { get; set; }
        int GameScore { get; set; }
        int TournamentScore { get; set; }
        void MakeChoice();
    }
}
