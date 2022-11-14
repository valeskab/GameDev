using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuBehaviour : MonoBehaviour
{
    public int sceneToLoad;

    public void StartDressGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void StartMiniGame()
    {
        SceneManager.LoadScene(sceneToLoad + 1);
    }
}