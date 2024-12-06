namespace Snake
{
    public class Obstacle
    {
        public int XPos { get; set; }

        public int YPos { get; set; }

        public ConsoleColor ScreenColor { get; set; }

        public string Character { get; set; } = string.Empty;
    }
}