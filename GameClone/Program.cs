using Example3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameClone
{
    class Program
    {
        public static int TimeCnt;
        public static string Dir;
        static void DoIt (Object state)// the timer
        {

          
            TimeCnt++;


            if (Console.KeyAvailable)
            {
                
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        Dir = "up";
                        break;
                    case ConsoleKey.DownArrow:
                        Dir = "Down";
                        break;
                    case ConsoleKey.LeftArrow:
                        Dir = "Left";
                        break;
                    case ConsoleKey.RightArrow:
                        Dir = "Right";
                        break;
                    case ConsoleKey.Escape:
                        Game.inGame = false;
                        break;
                    case ConsoleKey.F2:
                        Game.Save();
                        break;
                    case ConsoleKey.F3:
                        Game.Resume();
                        break;
                }
            }


            switch (Dir)
            {
                case "up":
                    Game.snake.Move(0, -1);
                    break;
                case "Down":
                    Game.snake.Move(0, 1);
                    break;
                case "Left":
                    Game.snake.Move(-1, 0);
                    break;
                case "Right":
                    Game.snake.Move(1, 0);
                    break;
            }
            
            if (Game.inGame)
            {
                Game.Redraw();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("GAME OVER!!!");
            }

        }
        static void Main(string[] args)
        {
            Game.inGame = true;

            Game.LoadLevel(1);
            Game.Init();

            Console.SetWindowSize(48, 48);
            System.Threading.Timer Tn = new System.Threading.Timer(new TimerCallback(DoIt));//
            Tn.Change(1000, 50);
          //  int dueTime = int.MaxValue;

            //DateTime nextCheck = DateTime.Now.AddMilliseconds(1);
            
            //int d = 1;
            Game.wall.Draw();
            while (Game.inGame)
            {
                
            }

            Console.ReadKey();
        }
    }
}
