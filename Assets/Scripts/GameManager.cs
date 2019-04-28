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
    private int nextLevel;

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
