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
            rules[0] = new int[3] { 5, 6, 7};
            rules[1] = new int[3] { 7, 5, 6 };
            rules[2] = new int[3] { 6, 7, 5 };
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

        public static void DoWork()
        {
            Controller mainController = Controller.Instance;
            string stringAnswer = "";
            int answer = 0;
            do
            {
             
                    Console.WriteLine();
                    Console.WriteLine("                  MENU");
                    Console.WriteLine("            1. Start Game");
                    Console.WriteLine("            2. Set up your names");
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

                        Console.WriteLine("You chose: Start Game");
                        bool canIPlay = mainController.CanIPlay();
                        if (canIPlay == true)
                        {
                            string result = mainController.StartGame();

                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine("You must set your names, players ");
                        }
                        break;
                    case 2:
                        Console.WriteLine("You chose: Set up names");
                        mainController.ResetListOfPlayers();
                        for (int i = 0; i < 2; i++)
                        {
                            Console.WriteLine("Write your name, Player{0}: ", i+1);
                            string name = Console.ReadLine();
                            mainController.SetName(name);
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
