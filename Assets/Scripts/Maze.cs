using System;
using Random = UnityEngine.Random;

public class Maze
{
    public enum TypeCell
    {
        Empty,
        Full,
        Start,
        End
    }

    public static TypeCell[,] GenerateMaze(int width, int height, int seed)
    {
        TypeCell[,] maze = InitializeMaze(width, height, seed);
        
        int startX = 0;
        int startY = 0;
        
        // always start from 0,0
        maze[startY, startX] = TypeCell.Start;
        
        // create the maze
        DepthFirstSearch(ref maze, startX, startY);

        return maze;
    }

    /**
     * Check if the cell with coord x and y is valid
     */
    static bool IsValidCell(ref TypeCell[,] maze, int x, int y)
    {
        int height = maze.GetLength(0);
        int width = maze.GetLength(1);

        // Check cell is inside limits
        if (x < 0 || x >= width)
            return false;
        if (y < 0 || y >= height)
            return false;

        // Cell not empty
        if (maze[y, x] == TypeCell.Empty)
            return false;

        // Check the number of neighbours
        int numberOfNeighbours = 0;
        if ((x - 1) >= 0 && maze[y, x - 1] == TypeCell.Empty)
            numberOfNeighbours++;
        if (x + 1 < width && maze[y, x + 1] == TypeCell.Empty)
            numberOfNeighbours++;
        if (y - 1 >= 0 && maze[y - 1, x] == TypeCell.Empty)
            numberOfNeighbours++;
        if (y + 1 < height && maze[y + 1, x] == TypeCell.Empty)
            numberOfNeighbours++;

        // if more than one neightoburs means it is limiting with another path so
        // its not valid because it has to be at least one cell to false between paths
        if (numberOfNeighbours > 1)
            return false;

        return true;
    }

    /*
     * Depth-First algorith to build the maze.
     * MaxLength determines the limit of the corredors.
     */
    static void DepthFirstSearch(ref TypeCell[,] maze, int x, int y)
    {
        if (maze[y, x] == TypeCell.End)
            return;

        // This index determines the four directions we can go
        int indexDirection = (int)(Random.value * 4);

        for (int i = 0; i < 4; i++)
        {
            if (indexDirection % 4 == 0) // left
            {
                // check if the left cell is valid to go
                if (IsValidCell(ref maze, x - 1, y))
                {
                    // if it's valid then we set the cell to true and we continue from
                    // that cell
                    maze[y, --x] = TypeCell.Empty;
                    DepthFirstSearch(ref maze, x, y);
                }
            }
            else if (indexDirection % 4 == 1) // right
            {
                if (IsValidCell(ref maze, x + 1, y))
                {
                    maze[y, ++x] = TypeCell.Empty;
                    DepthFirstSearch(ref maze, x, y);
                }
            }
            else if (indexDirection % 4 == 2) // up
            {
                if (IsValidCell(ref maze, x, y - 1))
                {
                    maze[--y, x] = TypeCell.Empty;
                    DepthFirstSearch(ref maze, x, y);
                }
            }
            else if (indexDirection % 4 == 3) // down
            {
                if (IsValidCell(ref maze, x, y + 1))
                {
                    maze[++y, x] = TypeCell.Empty;
                    DepthFirstSearch(ref maze, x, y);
                }
            }

            indexDirection++;
        }
    }

    static TypeCell[,] InitializeMaze(int width, int height, int seed)
    {
        TypeCell[,] maze = new TypeCell[height, width];
        
        // initiailize all cells to full 
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                maze[y, x] = TypeCell.Full;
            }
        }

        Random.InitState(seed);
        
        // random end
        int xRandom = Random.Range(1, width);
        int yRandom = Random.Range(1, height);
        
        maze[yRandom, xRandom] = TypeCell.End;
        
        return maze;
    }
}