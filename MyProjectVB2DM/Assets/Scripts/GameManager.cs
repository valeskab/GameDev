using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    Start,
    Playing,
    GameOver
}

public class GameManager : InstanceBehaviour<GameManager>
{
    
    
    public GameStates CurrentState { get; set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(GameStates.Playing);
        }
    }

    public void ChangeState(GameStates newState)
    {
        if (CurrentState != newState)
        {
            CurrentState = newState;
        }
    }
}
