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
    
    public static event Action<GameStates> GameStateEvent;
    public GameStates CurrentState { get; set; }

    private void Update()
    {
        if (CurrentState == GameStates.Start || CurrentState == GameStates.GameOver)
        {
            return;
        }
    }

    public void ChangeState(GameStates newState)
    {
        if (CurrentState != newState)
        {
            CurrentState = newState;
            GameStateEvent?.Invoke(CurrentState);
        }
    }
    
    
}
