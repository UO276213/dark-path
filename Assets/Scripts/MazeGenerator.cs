using System;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    private static string PATH_MAZE_WALL = "Prefabs/MazeWall";
    private static string PATH_MAZE_PLANE = "Prefabs/MazeGround";
    private static string PATH_AWARD = "Prefabs/Award";
    
    public int width = 10;
    public int height = 10;
    public int seed = 0;
    public bool debug = false; 

    private Vector3 _endPosition = Vector3.negativeInfinity;
    private Vector3 _startPosition = Vector3.negativeInfinity;


    private void Start()
    {
        GenerateMaze();
    }

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
        Maze.TypeCell[,] maze = Maze.GenerateMaze(width, height, seed);

        //check neightbour cells to get the next cell
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 position = transform.position + new Vector3(x * 5, 0, -y * 5);

                GameObject obj;
                GameObject resource = null;

                switch (maze[y, x])
                {
                    case Maze.TypeCell.Full:
                        resource = Resources.Load<GameObject>(PATH_MAZE_WALL);
                        break;
                    case Maze.TypeCell.End:
                        _endPosition = new Vector3(x * 5, 0, -y * 5);
                        position = transform.position + new Vector3(x * 5, 2, -y * 5);
                        resource = Resources.Load<GameObject>(PATH_AWARD);
                        break;
                    case Maze.TypeCell.Start:
                        _startPosition = new Vector3(x * 5, 0, -y * 5);
                        break;
                }

                if (resource != null)
                {
                    obj = Instantiate(resource, position, Quaternion.identity);
                    obj.transform.parent = transform;
                }

                
            }
        }

        // MazeDisplay.DrawMaze(maze);
    }

    private void Update()
    {
        if (debug && _endPosition != Vector3.negativeInfinity)
        {
            Debug.DrawLine(_endPosition, _endPosition + Vector3.up * 100, Color.blue);
            Debug.DrawLine(_startPosition, _startPosition + Vector3.up * 100, Color.green);
        }
    }
}