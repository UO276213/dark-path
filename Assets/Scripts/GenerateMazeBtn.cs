using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    [CustomEditor(typeof(MazeGenerator))]
    public class GenerateMazeBtn : Editor
    {
        public override void OnInspectorGUI()
        {
            MazeGenerator mazeGenerator = (MazeGenerator) target;
            DrawDefaultInspector();
            if (GUILayout.Button("Generate"))
            {
                mazeGenerator.GenerateMaze();
            }
            base.OnInspectorGUI();
            
        }
    }
}