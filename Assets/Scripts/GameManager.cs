using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // Pelaajan elämäpisteiden tekstikenttä
    [SerializeField]
    private Text healthText;
    private float currentHealth;
    private float newHealth;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    

    public void UpdateHealth()
    {
        healthText.text = "Testi";
    }
}
