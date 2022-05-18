using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_launcher : MonoBehaviour
{
    public Sequence_player sequencePlayer;

    public delegate void reloadSceneDelegate();

    public reloadSceneDelegate reloadSceneEvent;

    public void reloadScene()
    {
        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadScene(0);
    }

    public void exitGame()
    {
        Application.Quit();
    }

}
