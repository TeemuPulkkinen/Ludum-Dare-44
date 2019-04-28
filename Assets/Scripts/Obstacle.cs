using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // jos törmääjä on pelaaja, tuhotaan pelaaja
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("DeathMenu");
        }
    }
}
