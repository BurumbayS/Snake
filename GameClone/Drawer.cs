using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Example3.Models
{
    [Serializable]
    public class Drawer

    {
        public ConsoleColor color;
        public char sign;
        public List<Point> body = new List<Point>();
        public void Draw()
        {
            Console.ForegroundColor = color;

            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }

        public Drawer()
        {

        }

        public void Save()
        {
            string fileName = "";

            switch (sign)
            {
                case '#':
                    fileName = "wall.xml";
                    break;
                case '$':
                    fileName = "food.xml";
                    break;
                case 'o':
                    fileName = "snake.xml";
                    break;
            }
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(GetType());
            xs.Serialize(fs, this);
            fs.Close();

            /*BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(fs, fileName);
            fs.Close();*/
        }

        public void Resume()
        {
            string fileName = "";

            switch (sign)
            {
                case '#':
                    fileName = "wall.xml";
                    break;
                case '$':
                    fileName = "food.xml";
                    break;
                case 'o':
                    fileName = "snake.xml";
                    break;
            }
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryFormatter bin = new BinaryFormatter();



            switch (sign)
            {
                case '#':
                    Game.wall.body.Clear();
                    Game.wall = bin.Deserialize(fs) as Wall;
                    break;
                case '$':
                    Game.food.body.Clear();
                    Game.food = bin.Deserialize(fs) as Food;
                    break;
                case 'o':
                    Game.snake.body.Clear();
                    Game.snake = bin.Deserialize(fs) as Snake;
                    break;
            }

            fs.Close();


        }
    }

}
