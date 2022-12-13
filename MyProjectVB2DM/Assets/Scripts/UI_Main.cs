using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sequences;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Main : MonoBehaviour
{
    [SerializeField] private GameObject menuTabStart;
    [SerializeField] private GameObject menuTabGameOver;
    public void SwitchMenuTo(GameObject uiMenu)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        uiMenu.SetActive(true);
    }
    public void GameOver()
    {
        menuTabGameOver.SetActive(true);
        GameManager.Instance.ChangeState((GameStates.GameOver));
    }

    public void PlayStart()
    {
        menuTabStart.SetActive(false);
        GameManager.Instance.ChangeState(GameStates.Playing);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ChangeStateReturn(GameStates newState)
    {
        if (newState == GameStates.GameOver)
        {
            GameOver();
        }
    }

    private void OnEnable()
    {
        GameManager.GameStateEvent += ChangeStateReturn;
    }

    private void OnDisable()
    {
        GameManager.GameStateEvent -= ChangeStateReturn;
    }
}
