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
        void MakeChoice(int choice);
    }
}
