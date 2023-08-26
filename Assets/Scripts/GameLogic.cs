using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLogic : MonoBehaviour
{
    private float range;

    private GameState _gameState;
    private string example;
    public string Example 
    {
        get { return example; }
        private set { example = value; }
    }
    public GameState gameState
    {
        get { return _gameState; }
        private set { _gameState = value; }
    }

    public enum GameState
    {
        Playing, Completed
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(GameState state)
    {
        switch (state)
        {
            case GameState.Completed:
                state = GameState.Completed;
                Debug.Log(String.Format("Game completed in {0}", Time.timeSinceLevelLoad));
                break;
            default:
                state = GameState.Playing;
                break;
        }
        this.gameState = state;
    }
}
