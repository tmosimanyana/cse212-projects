namespace MazeSolver
{
    public class Maze
    {
        private int[,] _mazeArray;
        public int Width { get; }
        public int Height { get; }

        public Maze(int[,] mazeArray)
        {
            _mazeArray = mazeArray;
            Width = mazeArray.GetLength(1);  // Width corresponds to the number of columns
            Height = mazeArray.GetLength(0); // Height corresponds to the number of rows
        }

        public int this[int x, int y] 
        {
            get => _mazeArray[x, y];
            set => _mazeArray[x, y] = value;
        }

        // Optional methods to retrieve dimensions
        public int GetWidth() => Width;
        public int GetHeight() => Height;
    }
}
