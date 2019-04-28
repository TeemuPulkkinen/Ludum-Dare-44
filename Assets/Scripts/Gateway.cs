using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gateway : MonoBehaviour
{
    public GameManager gameManager;
    public string levelToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager.lastLevel)
            {
                gameManager.LoadLevel("VictoryScreen");
            }
            else
            {
                //PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
                gameManager.LoadLevel(levelToLoad);
            }
            
        }
    }
}
