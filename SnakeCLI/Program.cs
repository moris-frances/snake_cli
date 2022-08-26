using System;
using System.Threading;
using System.Timers;

namespace SnakeCLI
{

    public class GameLoop
    {

        static void Main(string[] args)
        {
            Snake snake = new Snake();
            snake.posx = 1;
            snake.posy = 1;
            int lastKey = 1;
            bool cont = true;

            UpdateScreen(snake, lastKey);

            while (cont == true);
        }

        public static void UpdateScreen(Snake fsnake, int direction)
        {
            System.Timers.Timer movementTimer = new System.Timers.Timer();
            movementTimer.Elapsed += (sender, e) => direction = KeyPressEvent(sender, e, fsnake, direction);
            movementTimer.Interval = 10;
            movementTimer.Start();

            System.Timers.Timer frameTimer = new System.Timers.Timer();

            //timer2.Elapsed += (sender, e) => Console.SetCursorPosition(0, 0);
            frameTimer.Elapsed += (sender, e) => Console.Clear();
            frameTimer.Elapsed += (sender, e) => PrintFrame(fsnake.posx, fsnake.posy);
            frameTimer.Elapsed += (sender, e) => fsnake.move(direction);
            frameTimer.Interval = 600;
            frameTimer.Start();

        }


        public class Snake
        {
            public int posx;
            public int posy;

            public void move(int lastKey) {
                if (lastKey == 1)
                {
                    posx++;
                }
                else if (lastKey == 2)
                {
                    posx--;
                }
                else if (lastKey == 3)
                {
                    posy--;
                }
                else if (lastKey == 4)
                {
                    posy++;
                }
            }
        }
        public class CollisionFunctions
        {
            public static bool is_collision(Snake s, int x2, int y2) {
                
                if (s.posx >= x2 && s.posx < (x2 + 1))
                {
                    if (s.posy >= y2 && s.posy<(y2 +1)){
                        return true;
                    }

                }
                return false;
            }

           


        }

        /*
         class Apple: 
    def __init__(self, parent_screen):
        self.image = pygame.image.load(os.path.join(resdir, 'apple.jpg')).convert()
        self.x = SIZE*3
        self.y = SIZE*3
        self.parent_screen = parent_screen

    def draw(self):
        ##draws the apple on our background ; (obj., pos=x,y )
        self.parent_screen.blit(self.image, (self.x,self.y))
        pygame.display.flip()

    def move(self):
            self.x = random.randint(0,24)*SIZE
            self.y = random.randint(0,14)*SIZE
         */

        static public void PrintFrame(int y, int x)
        {
            for (int i = 0; i < 20; i++)
            {
                if ((i == 0) || (i == 19))
                {
                    for (int j = 0; j < 50; j++)
                    {
                        Console.Write("-");
                    }
                }
                else
                {
                    for (int j = 0; j < 50; j++)
                    {
                        if ((j == 0) || (j == 49))
                        {
                            Console.Write("!");
                        }
                        else
                        {
                            if ((x == i) && (y == j))
                            {
                                Console.Write("X");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                    }
                }
                Console.Write("\n");
            }
        }
        private static int KeyPressEvent(object source, System.Timers.ElapsedEventArgs e, Snake snek, int direction)
        {
            ConsoleKey choice;
            choice = Console.ReadKey(true).Key;

            switch (choice)
            {
                case ConsoleKey.RightArrow:
                    direction = 1;
                    return direction;
                case ConsoleKey.DownArrow:
                    direction = 4;
                    return direction;
                case ConsoleKey.LeftArrow:
                    direction = 2;
                    return direction;
                case ConsoleKey.UpArrow:
                    direction = 3;
                    return direction;
                default:
                    return direction;
            }

            // return direction;


        }
    }
}