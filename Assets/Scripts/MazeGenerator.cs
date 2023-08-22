using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    private static string PATH_MAZE_CORNER = "Prefabs/MazeCorner"; // right to up rotation by default 
    private static string PATH_MAZE_END = "Prefabs/MazeEnd";
    private static string PATH_MAZE_HALL = "Prefabs/MazeHall";
    private static string PATH_MAZE_TSHAPE = "Prefabs/MazeTShape";
    private static string PATH_MAZE_CROSS = "Prefabs/MazeCross";
    private static string PATH_MAZE_BLOCK = "Prefabs/MazeWall";
    private static string PATH_MAZE_PLANE = "Prefabs/MazeGround";

    private enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }

    public struct Coords
    {
        public int X;
        public int Y;

        public Coords(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public int width = 10;
    public int height = 10;
    public int maxLength = 100;
    public int seed = 0;


    /*
     * ^              UP
     * |            _|__|_
     * y axis  LEFT _|__|_ RIGHT
     *              _|__|_
     *               |  |
     *               DOWN
     *          x axis ->>
     */
    public void GenerateMaze()
    {
        bool[,] maze = Maze.GenerateMaze(width, height, maxLength, seed);

        //check neightbour cells to get the next cell
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 position = transform.position + new Vector3(x * 5, 0, -y * 5);

                if (!maze[y, x])
                {
                    GameObject mazeBlock = Resources.Load<GameObject>(PATH_MAZE_BLOCK);
                    Instantiate(mazeBlock, position, Quaternion.identity);
                }
                else
                {
                    GameObject mazePlane = Resources.Load<GameObject>(PATH_MAZE_PLANE);
                    Instantiate(mazePlane, position, Quaternion.identity);
                }

                // if (maze[y, x])
                // {
                //     List<Coords> neightbourCells = GetNeightbourCells(maze, x, y);
                //     position = transform.position + new Vector3(x * 5, 0, y * 5);
                //
                //     
                //     if (neightbourCells.Count == 4)
                //     {
                //         GameObject mazeCorner = Resources.Load<GameObject>(PATH_MAZE_CROSS);
                //         Instantiate(mazeCorner, position, Quaternion.identity);
                //     }
                //     else if (neightbourCells.Count == 3)
                //     {
                //         GameObject mazeCorner = Resources.Load<GameObject>(PATH_MAZE_TSHAPE);
                //         Instantiate(mazeCorner, position, Quaternion.identity);
                //     }
                //     else if (neightbourCells.Count == 2)
                //     {
                //         var firstCell = neightbourCells[0];
                //         var secondCell = neightbourCells[1];
                //         
                //         GameObject mazeCorner = Resources.Load<GameObject>(PATH_MAZE_HALL);
                //         Instantiate(mazeCorner, position, Quaternion.identity);
                //         
                //         Direction fromDirection = GetDirectionForStep(x, y, firstCell.X, firstCell.Y);
                //         Direction nextDirection = GetDirectionForStep(x, y, secondCell.X, secondCell.Y);
                //         if (fromDirection == Direction.Right && nextDirection == Direction.Right ||
                //             fromDirection == Direction.Left && nextDirection == Direction.Left)
                //         {
                //             GameObject mazeCorner = Resources.Load<GameObject>(PATH_MAZE_HALL);
                //             Instantiate(mazeCorner, position, Quaternion.identity);
                //         }
                //         
                //         else if (fromDirection == Direction.Up && nextDirection == Direction.Up ||
                //                 fromDirection == Direction.Down && nextDirection == Direction.Down)
                //         {
                //             GameObject mazeCorner = Resources.Load<GameObject>(PATH_MAZE_HALL);
                //             Instantiate(mazeCorner, position, Quaternion.identity);
                //         }
                //         
                //         
                //         else if (fromDirection == Direction.Right && nextDirection == Direction.Up ||
                //                 fromDirection == Direction.Down && nextDirection == Direction.Left)
                //         {
                //             GameObject mazeCorner = Resources.Load<GameObject>(PATH_MAZE_CORNER);
                //             Instantiate(mazeCorner, position, Quaternion.AngleAxis(90, Vector3.up));
                //         }
                //         
                //         else if (fromDirection == Direction.Down && nextDirection == Direction.Right ||
                //                 fromDirection == Direction.Left && nextDirection == Direction.Up)
                //         {
                //             GameObject mazeCorner = Resources.Load<GameObject>(PATH_MAZE_CORNER);
                //             Instantiate(mazeCorner, position, Quaternion.AngleAxis(90, Vector3.up));
                //         }
                //         
                //         
                //         else if (fromDirection == Direction.Up && nextDirection == Direction.Right ||
                //                 fromDirection == Direction.Left && nextDirection == Direction.Down)
                //         {
                //             GameObject mazeCorner = Resources.Load<GameObject>(PATH_MAZE_CORNER);
                //             Instantiate(mazeCorner, position, Quaternion.AngleAxis(180, Vector3.up));
                //         }
                //         
                //         else if (fromDirection == Direction.Right && nextDirection == Direction.Down ||
                //                 fromDirection == Direction.Up && nextDirection == Direction.Left)
                //         {
                //             GameObject mazeCorner = Resources.Load<GameObject>(PATH_MAZE_CORNER);
                //             Instantiate(mazeCorner, position, Quaternion.AngleAxis(270, Vector3.up));
                //         }
                //     }
                //     else
                //     {
                //         Coords nextCell = neightbourCells[0];
                //         
                //         Direction fromDirection = GetDirectionForStep(x, y, nextCell.X, nextCell.Y);
                //
                //         GameObject mazeEnd = Resources.Load<GameObject>(PATH_MAZE_END);
                //         
                //         if (fromDirection == Direction.Down)
                //         {
                //             Instantiate(mazeEnd, Vector3.zero, Quaternion.Euler(0, -90, 0));
                //         }
                //     }
            }
        }

        // MazeDisplay.DrawMaze(maze);
        
    }

    // List<Coords> GetNeightbourCells(bool[,] maze, int x, int y)
    // {
    //     int height = maze.GetLength(0);
    //     int width = maze.GetLength(1);
    //
    //     List<Coords> neighbours = new List<Coords>();
    //
    //     if (y - 1 >= 0 && maze[y - 1, x]) //check up
    //         neighbours.Add(new Coords(x, y - 1));
    //     if (y + 1 < height && maze[y + 1, x]) // down
    //         neighbours.Add(new Coords(x, y + 1));
    //     if (x - 1 >= 0 && maze[y, x - 1]) // left
    //         neighbours.Add(new Coords(x - 1, y));
    //     if (x + 1 < width && maze[y, x + 1]) // right
    //         neighbours.Add(new  Coords(x + 1, y));
    //     
    //     return neighbours;
    // }

    // /*
    //  * Returns the direction to the next cell
    //  * Can only go up, down, left and right
    //  */
    // (Direction, Direction) GetDirections(Coords cell, Coords[] neighbours)
    // {
    //     var fromCell = neighbours[0];
    //     var toCell = neighbours[1];
    //
    //     return (GetDirectionForStep(cell.X, cell.Y, fromCell.X, fromCell.Y),
    //         GetDirectionForStep(cell.X, cell.Y, toCell.X, toCell.Y));
    // }
    //
    //
    // Direction GetDirectionForStep(int currentX, int currentY, int nextX, int nextY)
    // {
    //     // if (currentX == nextX && currentY == nextY)
    //     //     throw new ArgumentException("Current cell and next one are the same");
    //
    //     if (nextX - currentX < 0) // left
    //         return Direction.Left;
    //     if (nextX - currentX > 0) // right
    //         return Direction.Right;
    //     if (nextY - currentY < 0) // up
    //         return Direction.Up;
    //
    //     return Direction.Down; // down
    // }
}