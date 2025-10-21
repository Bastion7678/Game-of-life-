using System.CodeDom.Compiler;

using System;
class Program
{
    static int GridWidth = 20;
    static int GridHeight = 20;
    static bool[,] currentGeneration = new bool[GridWidth, GridHeight];
    static bool[,] nextGeneration = new bool[GridWidth, GridHeight];
    static Random random = new Random();
    
    static void Main(string[] args)
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
            }
        }
    }
}