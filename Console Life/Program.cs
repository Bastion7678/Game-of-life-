using System.CodeDom.Compiler;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
class Program
{
    static int GridWidth = 20;
    static int GridHeight = 20;
    static bool[,] currentGeneration = new bool[GridWidth, GridHeight];
    static bool[,] nextGeneration = new bool[GridWidth, GridHeight];
    static Random random = new Random();

    //Threading
    public static ConsoleKey lastKey;
    public static object Keylock = new object();

    //Ascii variables
    static characterAnimationStates CurrentAnimations = characterAnimationStates.Static;
    static int XLocation = 10;
    static int YLocation = 2;

    private static characterAnimationStates CurrentAnimation { get; set; }

    enum characterAnimationStates
    {
        MovingLeft,
        Static,
        MovingRight,
    }
    
    //this is the display of the main menu
    static void Main(string[] args)
    {

        bool isInMenu = true;
        Console.WriteLine("1 - Game of Life");
        Console.WriteLine("2 - character");
        Console.WriteLine("3 - background");
        Console.WriteLine("4 - Exit");

        ConsoleKey pressedKey = ConsoleKey.None;

        while (isInMenu)
        {
            if (Console.KeyAvailable)
            {
                if(Console.ReadKey(true).Key == ConsoleKey.D1)
                {
                    pressedKey = ConsoleKey.D1;
                    isInMenu = false;
                }
                if (Console.ReadKey(true).Key == ConsoleKey.D2)
                {
                    pressedKey = ConsoleKey.D2;
                    isInMenu = false;
                }
                if (Console.ReadKey(true).Key == ConsoleKey.D3)
                {
                    pressedKey = ConsoleKey.D3;
                    isInMenu = false;
                }
                if (Console.ReadKey(true).Key == ConsoleKey.D4)
                {
                    pressedKey = ConsoleKey.D4;
                    isInMenu = false;
                }
            }
        }
        // this is what is the result of pressing the number keys as it takes you to the different menus
        switch (pressedKey)
        {
            case ConsoleKey.D1:
                GameofLife();

                break;
            case ConsoleKey.D2:
                ascii();
                break;

            case ConsoleKey.D3:
                background();
                break;

            case ConsoleKey.D4:
                Environment.Exit(0);
                break;
        }
  
    }

    static void GameofLife()
    {
        InitializeGrid();
        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            DisplayGrid();
            UpdateGrid();
            System.Threading.Thread.Sleep(100);
        }
    }
    static void InitializeGrid()
    {
        for (int x = 0; x < GridWidth; x++)








        {
             for (int y = 0; y < GridHeight; y++)
            {
                currentGeneration[x, y] = random.Next(2) == 0;
            }
        }
    }
     












    static void DisplayGrid()
    {
        for (int y = 0; y < GridHeight; y++)
        {
            for (int x =0; x < GridWidth; x++)
            {
















                Console.Write(currentGeneration[x, y] ? "█" : " ");
            }
            Console.WriteLine();

        }
    }

    static void UpdateGrid()
    {
        for (int x = 0; x < GridHeight; x++)
        {
            for (int y = 0; y < GridHeight; y++)
            {
                int LiveNeighbors = CountLiveNeighbors(x, y);

                if (currentGeneration[x, y])
                {
                    nextGeneration[x, y] = LiveNeighbors == 2 || LiveNeighbors == 3;
                }
                else
                {
                    nextGeneration[x, y] = LiveNeighbors == 3;

                }
            }
        }
        bool[,] temp = currentGeneration;
        currentGeneration = nextGeneration;
        nextGeneration = temp;
    }

    static int CountLiveNeighbors(int x, int y)
    {
        int count = 0;

        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                if (dx == 0 && dy == 0)
                    continue;

                int nx = x + dx;
                int ny = y + dy;

                if (nx >= 0 && nx < GridWidth && ny >= 0 && ny < GridHeight &&
                    currentGeneration[nx, ny])
                {
                    count++;
                }
            }
        }

        return count;

    }

    static void ascii()
    {
        Console.Clear();
        Character();
        Thread.Sleep(100);

        Console.SetCursorPosition(0, 23);
    }
    static void background()
    {

        Console.Clear();
        Console.WriteLine("████████████████████████████████████");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █"); 
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("█                                  █");
        Console.WriteLine("████████████████████████████████████");

    }
    static void Character()
    {
        //Xlocation
        //YLocation

        if (CurrentAnimation == characterAnimationStates.MovingLeft)
        {
            Console.SetCursorPosition(XLocation, YLocation);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 1);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 2);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 3);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 4);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 5);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 6);
            Console.Write("███████");
        }
        else if (CurrentAnimation == characterAnimationStates.Static)
        {
            Console.SetCursorPosition(XLocation, YLocation);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 1);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 2);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 3);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 4);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 5);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 6);
            Console.Write("███████");
        }
        else if (CurrentAnimation == characterAnimationStates.MovingRight)
        {
            Console.SetCursorPosition(XLocation, YLocation);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 1);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 2);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 3);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 4);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 5);
            Console.Write("███████");
            Console.SetCursorPosition(XLocation, YLocation + 6);
            Console.Write("███████");
        }

        static void inputthreadloop()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    lock (Keylock)
                    {
                        lastKey = Console.ReadKey().Key;

                        if (lastKey == ConsoleKey.LeftArrow || lastKey == ConsoleKey.A)
                        {
                            CurrentAnimation = characterAnimationStates.MovingLeft;
                            XLocation--;
                        }
                        else if (lastKey == ConsoleKey.RightArrow || lastKey == ConsoleKey.D)
                        {
                            CurrentAnimation = characterAnimationStates.MovingLeft;
                            if (XLocation >= 10)
                            {
                                XLocation++;
                            }
                        }
                        else if (lastKey == ConsoleKey.DownArrow || lastKey == ConsoleKey.S)
                        {
                            CurrentAnimation = characterAnimationStates.MovingLeft;
                        }
                        else
                        {
                            CurrentAnimation = characterAnimationStates.Static;
                        }
                    }
                }
            }
        }
    }
}