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
    

    private void Awake()
    {
        currentLevel = SceneManager.GetActiveScene().name;
    }

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
