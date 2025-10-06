namespace Drawing_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DrawSquare();
        }
        static void DrawSquare()
        {
            for (int x = 0; x <= 5; x++)
            {
                for (int y = 0; y <= 5; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.Green;
                }


            }
        }
    }  
}
               