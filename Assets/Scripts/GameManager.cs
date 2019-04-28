using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    public bool lastLevel;
    public string currentLevel;
    public static string PreviousScene = "";


    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != "DeathMenu")
        {
            PreviousScene = SceneManager.GetActiveScene().name;
        }
        currentLevel = SceneManager.GetActiveScene().name;

    }

    public void LoadLevel(string levelName)
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(levelName);
    }

    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(PreviousScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
