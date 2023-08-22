using UnityEngine;

public class Maze
{
    public static bool[,] GenerateMaze(int width, int height, int maxLength, int seed)
    {
        bool[,] maze = new bool[height, width];
        
        // always start from 0,0
        maze[0, 0] = true;
        
        Random.InitState(seed);

        int startX = 0;
        int startY = 0;
        
        // create the maze
        DepthFirstSearch(ref maze, startX, startY, 0, maxLength);
        
        return maze;
    }

    /**
     * Check if the cell with coord x and y is valid
     */
    static bool IsValidCell(ref bool[,] maze, int x, int y)
    {
        int height = maze.GetLength(0);
        int width = maze.GetLength(1);

        // Check cell is inside limits
        if (x < 0 || x >= width)
            return false;
        if (y < 0 || y >= height)
            return false;
        
        // Cell not empty
        if (maze[y, x])
            return false;

        // Check the number of neighbours
        int numberOfNeighbours = 0;
        if ((x - 1) >= 0 && maze[y, x - 1])
            numberOfNeighbours++;
        if (x + 1 < width && maze[y, x + 1])
            numberOfNeighbours++;
        if (y - 1 >= 0 && maze[y - 1, x])
            numberOfNeighbours++;
        if (y + 1 < height && maze[y + 1, x])
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
    static void DepthFirstSearch(ref bool[,] maze, int x, int y, int length, int maxLength)
    {
        if (length >= maxLength)
            return;

        float randomValue = Random.value;

        // This index determines the four directions we can go
        int indexDirection = (int)(randomValue * 4);
        
        for (int i = 0; i < 4; i++)
        {
            if (indexDirection % 4 == 0) // left
            {
                // check if the left cell is valid to go
                if (IsValidCell(ref maze, x - 1, y))
                {
                    // if it's valid then we set the cell to true and we continue from
                    // that cell
                    maze[y, --x] = true;
                    DepthFirstSearch(ref maze, x, y, ++length, maxLength);
                }
            }
            else if (indexDirection % 4 == 1) // right
            {
                if (IsValidCell(ref maze, x + 1, y))
                {
                    maze[y, ++x] = true;
                    DepthFirstSearch(ref maze, x, y, ++length, maxLength);

                }
            }
            else if (indexDirection % 4 == 2) // up
            {
                if (IsValidCell(ref maze, x, y - 1))
                {
                    maze[--y, x ] = true;
                    DepthFirstSearch(ref maze, x, y, ++length, maxLength);

                }
            }
            else if (indexDirection % 4 == 3)// down
            {
                if (IsValidCell(ref maze, x, y + 1))
                {
                    maze[++y, x] = true;
                    DepthFirstSearch(ref maze, x, y, ++length, maxLength);
                }
            }

            indexDirection++;
        }
    }
}