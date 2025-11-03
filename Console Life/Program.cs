using System.CodeDom.Compiler;

using System;
using System.Diagnostics.CodeAnalysis;
class Program
{
    static int GridWidth = 20;
    static int GridHeight = 20;
    static bool[,] currentGeneration = new bool[GridWidth, GridHeight];
    static bool[,] nextGeneration = new bool[GridWidth, GridHeight];
    static Random random = new Random();
    
    static void Main(string[] args)
    {
        bool isInMenu = true;
        Console.WriteLine("1 - Game of Life");
        Console.WriteLine("2 - character");
        Console.WriteLine("3 - background");

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
            }
        }
        // this is what is the result of pressing the number keys as it takes you to the different menus
        switch (pressedKey)
        {
            case ConsoleKey.D1:
                GameofLife();

                break;
            case ConsoleKey.D2:

                break;

            case ConsoleKey.D3:

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
}