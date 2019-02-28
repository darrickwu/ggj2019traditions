using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void playTheGame()
    {
        LevelTransition.Instance.NextLevel("Scenes/GameLevels/ChristmasLights");
    }

    public void quitGame()
    {
        Debug.Log("I quit");
        Application.Quit();
    }
}