using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadArScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitApp()
    {
        Application.Quit();
        Debug.Log("Exited.");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
