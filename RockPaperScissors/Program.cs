using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RockPaperScissors
{
    public class Constants{
        public static int ROCK = 0;
        public static int PAPER = 1;
        public static int SCISSOR = 2;
        public static int TIE = 5;
        public static int LOSE= 6;
        public static int WIN = 7;
        public static int[][] gameRules;
        public static void LoadRules()
        {
            int[][] rules = new int[3][];
            rules[0] = new int[3] { TIE, LOSE, WIN};
            rules[1] = new int[3] { WIN, TIE, LOSE };
            rules[2] = new int[3] { LOSE, WIN, TIE };
            gameRules = rules;
        }
        
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            Constants.LoadRules();
            DoWork();
        }

        public static void DisplayList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(i + ". " + list[i]);
            }
        }

        public static void DoWork()
        {
            FileController fileController = new FileController();
            GameController mainController = GameController.Instance;
            string stringAnswer = "";
            int answer = 0;
            do
            {
             
                    Console.WriteLine();
                    Console.WriteLine("                  MENU");
                    Console.WriteLine("            1. Play Game");
                    Console.WriteLine("            2. Set up your names");
                    Console.WriteLine("            3. Play tournament");
                    Console.WriteLine("            0. Exit");

                stringAnswer = Console.ReadLine();
                try
                {
                    answer = int.Parse(stringAnswer);
                }
                catch (Exception ex)
                {
                        Console.WriteLine(ex.Message);
                        answer = 99;
                }

                switch (answer)
                {
                    case 1:

                        Console.WriteLine("You chose: Play Game");
                        mainController.ResetListOfPlayers();//reset runtime list of players
                        //1:load the list with names. Show it . Show also a computer player as first choice, before the list
                            //1.1: if there not enough names in the list/not the one a player has the player can enter his name. it will 
                             //be added to the runtime list and to the txt list
                        // runtime list contains only the players who play the game
                        int counter = 2; // 2 players allowed 
                        Console.WriteLine("Play against computer? : y/n");
                        string yesOrNot = Console.ReadLine();
                        bool computerPlayer = (yesOrNot == "y") ? true : false;

                        if (computerPlayer)
                        {
                            //make a computer player and add it to the runtime list 
                            Model.PCPlayer pcPlayer = new Model.PCPlayer("COMPUTER");
                            mainController.AddPlayerToRuntimeList(pcPlayer);
                            counter--;
                        }
                        bool displayListFromFile = false;
                        List<string> listFromFile = new List<string>();
                        listFromFile = fileController.RetrievePlayersFromFile();
                        
                        Console.WriteLine("There are {0} saved players.", listFromFile.Count);
                        for (int i = 0; i < counter; i++)
                        {
                            displayListFromFile = listFromFile.Count > 0 ? true : false;
                            //choose name from list or create name
                            if (displayListFromFile)
                            {
                                Console.WriteLine("If you are one of these players, choose your name..(press number);");
                                DisplayList(listFromFile);
                                Console.WriteLine("Or write down your name:");
                            }
                            else
                            {
                                Console.WriteLine("Write your name, please:");
                            }
                            //read input
                            string playerName;
                            string input = Console.ReadLine();
                            int choiceNumber;
                            bool listChoice = Int32.TryParse(input, out choiceNumber);
                            //handle input
                            if (listChoice) //if player chose his name from the list
                            {
                                playerName = listFromFile[choiceNumber];
                                //remove name from listFromFile if it was chosen(a player cannot play against himself)    
                                listFromFile.Remove(listFromFile[choiceNumber]);
                            }
                            else
                            {
                                playerName = input;
                            }
                            Model.Player newPlayer = new Model.Player(playerName);
                            mainController.AddPlayerToRuntimeList(newPlayer);
                        } // end setting up names
                        
                        //play game

                            mainController.StartGame();
                        break;
                    case 2:
                        Console.WriteLine("You chose: Set up names");//this will just handle names in the txt file
                        Console.WriteLine("Write your name, Player: ");
                        string name = Console.ReadLine();
                        fileController.AddPlayerToFile(name);
                        break;
                    case 3:
                        Console.WriteLine("You chose: Play tournament");
                        mainController.ResetListOfPlayers();
                        Console.WriteLine("Write the number of players: (between 3 and 10 incl.)");
                        int numberOfPlayers = int.Parse(Console.ReadLine());
                        if (numberOfPlayers>2 && numberOfPlayers<11)
                        {
                            int Tcounter = numberOfPlayers;

                            bool displayFileList = false;

                            List<string> fileList = new List<string>();

                            fileList = fileController.RetrievePlayersFromFile();

                            Console.WriteLine("There are {0} saved players.", fileList.Count);
                            for (int i = 0; i < Tcounter; i++)
                            {
                                displayFileList = fileList.Count > 0 ? true : false;
                                //choose name from list or create name
                                if (displayFileList)
                                {
                                    Console.WriteLine("If you are one of these players, choose your name..(press number);");
                                    DisplayList(fileList);
                                    Console.WriteLine("Or write down your name:");
                                }
                                else
                                {
                                    Console.WriteLine("Write your name, please:");
                                }
                                //read input
                                string playerName;
                                string input = Console.ReadLine();
                                int choiceNumber;
                                bool listChoice = Int32.TryParse(input, out choiceNumber);
                                //handle input
                                if (listChoice) //if player chose his name from the list
                                {
                                    playerName = fileList[choiceNumber];
                                    //remove name from listFromFile if it was chosen(a player cannot play against himself)    
                                    fileList.Remove(fileList[choiceNumber]);
                                }
                                else
                                {
                                    playerName = input;
                                }
                                Model.Player newPlayer = new Model.Player(playerName);
                                mainController.AddPlayerToRuntimeList(newPlayer);
                            } // end setting up names

                            //play game

                            mainController.StartGame();
                            mainController.WriteTournamentScoreBoard();
                            //Console.WriteLine(mainController.Stats());    
                        }
                        else
                        {
                            Console.WriteLine("Number not allowed!");
                        }
                        
                        break;
                    case 0:
                        Console.WriteLine("Exiting..");
                        Thread.Sleep(1000);
                        break;
                    default:
                        //the answer is an error or not found in switch. just break. the method will start again since answer is not 0
                        break;
                }

            } while (answer != 0);
        }

    }
}
