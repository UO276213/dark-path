using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class MazeDisplay : MonoBehaviour
    {
        public Color color;

        public Texture2D texture;
        // public int textureWidth = 256;
        // public int textureHeight = 256;
        // public int scale = 1;

        public static void DrawMaze(bool[,] maze)
        {
            int mazeHeight = maze.GetLength(0);
            int mazeWidth = maze.GetLength(1);
            var texture = new Texture2D(mazeWidth, mazeHeight);

            Color[] colors = new Color[mazeWidth * mazeHeight];

            for (int i = 0; i < mazeHeight; i++)
            {
                for (int j = 0; j < mazeWidth; j++)
                {
                    if (maze[i, j])
                    {
                        colors[i * mazeWidth + j] = Color.red;
                    }
                       
                }
            }
            
            texture.SetPixels(colors);
            texture.Apply();
            AssetDatabase.CreateAsset(texture, "Assets/MyMaterial.renderTexture");
        }
    }
}