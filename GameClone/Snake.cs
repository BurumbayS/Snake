using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3.Models
{
    public class Snake : Drawer
    {
        Point head = new Point();
        public void Eat() { }
        public Snake()
        {
            color = ConsoleColor.Yellow;
            sign = 'o';
        }

        public void Move(int dx, int dy)
        {
            int xcl, ycl;
            xcl = body[body.Count - 1].x;
            ycl = body[body.Count - 1].y;
            Console.SetCursorPosition(xcl, ycl);
            Console.Write(" ");

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            if (body[0].x + dx < 0) dx = dx + 48;//Task 1
            if (body[0].y + dy < 0) dy = dy + 48;//Task 1
            if (body[0].x + dx > 48) dx = dx - 48;//Task 1
            if (body[0].y + dy > 48) dy = dy - 48;//Task 1 manipulations of borders



            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

            //проверка, можем ли скушать
            for (int i = 0; i < Game.food.body.Count; ++i)
            {
                if (Game.snake.body[0].x == Game.food.body[i].x && Game.snake.body[0].y == Game.food.body[i].y)
                {
                    //добавил к змейке новую точку. прирост
                    Game.snake.body.Add(new Point { x = Game.food.body[i].x, y = Game.food.body[i].y });
                    // переместил еду на новую позицию 
                    /*NEW */
                    int tx = 0, ty = 0;
                    bool success = false;
                    while (!success)
                    {
                        tx = new Random().Next(0, 30);// Task 2 method of generating food in a random place;

                        ty = new Random().Next(0, 30);
                        success = true;
                        for (int j = 0; j < Game.wall.body.Count; ++j)
                        {
                            if (tx == Game.wall.body[j].x &&
                                ty == Game.wall.body[j].y)
                            {
                                success = false;
                                break;
                            }
                        }
                        for (int j = 0; j < Game.snake.body.Count; ++j)
                        {
                            if (tx == Game.snake.body[j].x &&
                                ty == Game.snake.body[j].y)
                            {
                                success = false;
                                break;
                            }

                        }
                        Game.food.body[i].x = tx;
                        Game.food.body[i].y = ty;

                        Game.foodEaten++;
                        
                        
                        if (Game.foodEaten % 4 == 0)//  Task 3 checking if snake has enough points/size/length for level promotion;
                        {
                            Console.Clear();
                            Game.LoadLevel(Game.foodEaten / 4 + 1);//
                            Game.Init();
                            Game.wall.Draw();
                        }
                    }

                    
                }
                
                /*END*/
            }
            //проверка, есть ли столкновение со стеной
            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.snake.body[0].x == Game.wall.body[i].x && Game.snake.body[0].y == Game.wall.body[i].y)
                {
                    Console.Clear();
                    Console.SetCursorPosition(35, 15);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over!");
                    Game.inGame = false;
                }
            }
        }
    }
}