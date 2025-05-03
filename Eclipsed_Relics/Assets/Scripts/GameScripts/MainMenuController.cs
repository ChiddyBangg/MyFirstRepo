using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync(1); // 0 = MainMenuScene, 1 = SampleScene
    }
    public void Exit()
    {
        Application.Quit();

    }

}
