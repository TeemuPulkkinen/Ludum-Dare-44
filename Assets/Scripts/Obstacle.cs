using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
}
