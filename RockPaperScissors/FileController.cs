using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class FileController
    {
        private string FileLocation; 
        public FileController()
        {
            FileLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Players.txt";
        }

        public void AddPlayerToFile(Model.Player player){
            System.IO.StreamWriter stream = new System.IO.StreamWriter(FileLocation, true);
            stream.WriteLine(player.Name);
            stream.Flush();
            stream.Close();
        }

        public List<Model.Player> RetrievePlayersFromFile()
        {
            List<Model.Player> allPlayers = new List<Model.Player>();
            string[] allPlayersRaw = System.IO.File.ReadAllLines(FileLocation);
            foreach (string player in allPlayersRaw)
            {
                Model.Player newPlayer = new Model.Player(player);
            }
            return allPlayers;
        }
    }
}
