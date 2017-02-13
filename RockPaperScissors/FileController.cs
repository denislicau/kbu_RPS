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
            System.IO.StreamWriter initFile = new System.IO.StreamWriter(FileLocation, true);
            initFile.Close();
        }

        public void AddPlayerToFile(string playerName){
            System.IO.StreamWriter stream = new System.IO.StreamWriter(FileLocation, true);
            stream.WriteLine(playerName);
            stream.Flush();
            stream.Close();
        }

        public List<string> RetrievePlayersFromFile()
        {
            List<string> allPlayers = new List<string>();
            string[] allPlayersRaw = System.IO.File.ReadAllLines(FileLocation);
            foreach (string player in allPlayersRaw)
            {
                allPlayers.Add(player);
            }
            return allPlayers;
        }
    }
}
