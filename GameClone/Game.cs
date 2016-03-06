using GameClone;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3.Models
{
    public class Game
    {
        public static int foodEaten = 0;
        public static bool inGame;
        public static Snake snake = new Snake();
        public static Wall wall = new Wall();
        public static Food food = new Food();
        public static int timer;
        public static void Redraw()
        {
            //Console.Clear();
            snake.Draw();
            food.Draw();
            //wall.Draw();
            Console.SetCursorPosition(24, 29);
            Console.WriteLine("Points:" + Game.foodEaten);// showing how many points
            //Console.WriteLine("Points:" + Game.foodEaten);
            //Console.WriteLine(timer / 10 + ":" + (timer - 10 * (timer / 10)) + "s");
            Console.WriteLine("Timer: " + Program.TimeCnt + " ms");
        }

        public static void LoadLevel(int i)
        {
            FileStream fs = new FileStream(string.Format(@"C:\Users\admin\Desktop\Sanzhar\SnakeSanzhar\GameClone2\GameClone\Levels\LevelWall{0}.txt", i), FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamReader reader = new StreamReader(fs);

            Game.wall.body.Clear();

            string line;
            int row = -1;
            int col = 0;

            while ((line = reader.ReadLine()) != null)
            {
                row++;
                col = -1;
                foreach (char c in line)
                {
                    col++;
                    if (c == '#')
                    {
                        Game.wall.body.Add(new Point { x = col, y = row });
                    }
                }
            }

            fs.Close();
        }

        public static void Resume()
        {
            wall.Resume();
            food.Resume();
            snake.Resume();
        }

        public static void Save()
        {
            wall.Save();
            food.Save();
            snake.Save();
        }

        public static void Init()
        {
            snake.body.Add(new Point { x = 10, y = 10 });
            food.body.Add(new Point { x = 20, y = 10 });
        }
    }

}
