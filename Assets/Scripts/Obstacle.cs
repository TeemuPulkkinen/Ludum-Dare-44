using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private HealthController healthController;

    private void Start()
    {
        healthController = FindObjectOfType<HealthController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // jos törmääjä on pelaaja, tuhotaan pelaaja
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("DeathMenu");
        }
    }
}
