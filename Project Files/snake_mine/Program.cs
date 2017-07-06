using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace snake_mine
{
    class Program
    {
        static void Main(string[] args)
        {
            game:
            {
                Console.CursorVisible = (false);
                Console.SetWindowSize(46, 26);
                new Settings();
                List<steric> snake = new List<steric>();
                steric head = new steric();
                head.X = 25;
                head.Y = 19;
                snake.Add(head);
                steric food = new steric();
                Random random = new Random();
                food.X = random.Next(1, 45);
                food.Y = random.Next(1, 25);
                int sleep = 50;
                while (!Settings.gameover)
                {

                     for (int i = snake.Count-1; i >=0; i--)
                    {
                        if (i == 0)
                        {
                            if (Settings.direction == directions.down)
                            {
                                snake[i].Y++;
                            }
                            else if (Settings.direction == directions.up)
                            {
                                snake[i].Y--;
                            }
                            else if (Settings.direction == directions.right)
                            {
                                snake[i].X++;
                            }
                            else if (Settings.direction == directions.left)
                            {
                                snake[i].X--;
                            }
                        }
                        else
                        {
                            snake[i].X = snake[i - 1].X;
                            snake[i].Y = snake[i - 1].Y;
                        }
                        Console.SetCursorPosition(snake[i].X, snake[i].Y);
                        Console.Write(snake[i].Steric);
                        if (food.X == snake[0].X && food.Y == snake[0].Y)
                        {
                            sleep += sleep;
                            steric tail = new steric()
                            {
                                X = snake[snake.Count - 1].X,
                                Y = snake[snake.Count - 1].Y,
                                Steric = '*'
                            };
                            snake.Add(tail);
                            food.X = random.Next(1, 45);
                            food.Y = random.Next(1, 25);
                            Settings.score += Settings.points;
                        }
                    }
                    Thread.Sleep(50);
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keys = Console.ReadKey(true);
                        switch (keys.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (Settings.direction != directions.down)
                                {
                                    Settings.direction = directions.up;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (Settings.direction != directions.up)
                                {
                                    Settings.direction = directions.down;
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (Settings.direction != directions.left)
                                {
                                    Settings.direction = directions.right;
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (Settings.direction != directions.right)
                                {
                                    Settings.direction = directions.left;
                                }
                                break;
                        }
                    }

                    if (snake[0].X <= 0 || snake[0].X >= 46 || snake[0].Y <= 0 || snake[0].Y >= 26)
                        Settings.gameover = true;
                    Thread.Sleep(50);
                    Console.Clear();
                    Console.SetCursorPosition(food.X, food.Y);
                    Console.Write(food.Steric);
                }
                Console.Clear();
                Console.WriteLine("Game Over\n" + "Your score is " + Settings.score + "\nPress Y to try again");
                ConsoleKeyInfo enter = Console.ReadKey(true);
                if (enter.Key == ConsoleKey.Enter)
                {
                    Settings.gameover = false;
                    goto game;
                }
            }
        }
    }
}
